using System.Collections;
using System.Numerics;
using LamdaPractice.Models;

namespace LamdaPractice;

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
}