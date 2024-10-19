using System.Collections;
using System.Numerics;
using LambdaPractice.Models;

namespace LambdaPractice;

public static class LinqClone
{
    public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<TResult> MySelect<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
    {
        foreach (var item in source)
        {
            yield return selector(item);
        }
    }

    public static T MyFirst<T>(this IEnumerable<T> source)
    {
        var sourceEnumerator =  source.GetEnumerator();
        if (sourceEnumerator.MoveNext())
        {
            return sourceEnumerator.Current;
        }
        
        throw new InvalidOperationException("Sequence contains no elements");
    }

    public static T MyFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
            {
                return item;
            }
        }
        
        throw new InvalidOperationException("Sequence contains no elements");
    }

    public static T MyLast<T>(this IEnumerable<T> source)
    {
        var enumerator = source.GetEnumerator();
        var result = default(T);
        while (enumerator.MoveNext())
        {
            result = enumerator.Current;
        }

        return result;
    }

    public static T MyLast<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        var result = default(T);
        foreach (var item in source)
        {
            result = predicate(item) ? item : default(T);
        }

        return result;
    }

    public static bool MyAll<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (!predicate(item))
            {
                return false;
            }
        }

        return true;
    }

    public static bool MyAny<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)    
        {
            if (predicate(item))
            {
                return true;
            }
        }

        return false;
    }

    public static int MySum<T>(this IEnumerable<T> source, Func<T, int> selector) => MySum<T, int>(source, selector);

    private static TResult MySum<T, TResult>(IEnumerable<T> source, Func<T, TResult> selector)
    where TResult : struct, INumber<TResult>
    {
        TResult result = TResult.Zero;
        foreach (var item in source)
        {
            result += selector(item);
        }

        return result;
    }

    public static double MyAverage<T>(this IEnumerable<T> source, Func<T, double> selector) => MyAverage<T, double> (source, selector);

    private static TResult MyAverage<T, TResult>(IEnumerable<T> source, Func<T, TResult> selector)
    where TResult : struct, INumber<TResult>
    {
        TResult result = TResult.Zero;
        TResult count = TResult.Zero;
        foreach (var item in source)
        {
            result += selector(item);
            count++;
        }

        return result / count;
    }

    public static IEnumerable<T> MyDistinct<T>(this IEnumerable<T> source)
    {
        var set = new HashSet<T>();

        foreach (var item in source)
        {
            if (set.Add(item))
            {
                yield return item;
            }
        }
    }
    
    public static bool MyContains<T>(this IEnumerable<T> source, T value) => MyContains(source, value, null);
    public static bool MyContains<T>(this IEnumerable<T> source, T value, IEqualityComparer<T>? comparer)
    {
        if (comparer is null)
        {
            foreach (var item in source)
            {
                if (EqualityComparer<T>.Default.Equals(value, item))
                {
                    return true;
                }
            }
        }
        else
        {
            foreach (var item in source)
            {
                if (comparer.Equals(item, value))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static int MyCount<T>(this IEnumerable<T> source)
    {
        var counter = 0;
        using var enumerator = source.GetEnumerator();

        if (enumerator.MoveNext())
        {
            counter++;
            while (enumerator.MoveNext())
            {
                counter++;
            }
        }

        return counter;
    }

    public static IEnumerable<T> MySkip<T>(this IEnumerable<T> source, int count)
    {
        int skipCounter = 0;
        foreach (var item in source)
        {
            if (count > skipCounter)
            {
                skipCounter++;
            }else
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<T> MyTake<T>(this IEnumerable<T> source, int count)
    {
        var counter = 0;

        foreach (var item in source)
        {
            if (count > counter)
            {
                counter++;
                yield return item;
            }
            else
            {
                break;
            }
        }
    }

    public static IEnumerable<IEnumerable<T>> MyChunk<T>(this IEnumerable<T> source, int chunkSize)
    {
        var chunk = new T[chunkSize];
        int chunkPos = 0;

        foreach (var item in source)
        {
            if (chunkPos == chunkSize - 1)
            {
                chunkPos = 0;
                yield return chunk;
            }
            else
            {
                chunk[chunkPos++] = item;
            }
        }

        if (chunkPos < chunkSize - 1 && chunkPos != 0)
        {
            Array.Resize(ref chunk, chunkPos);
            yield return chunk;
        }
    }
}