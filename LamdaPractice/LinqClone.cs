namespace LamdaPractice;

public static class LinqClone
{
    public static IEnumerable<T> WhereClone<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<T> SelectClone<T>(this IEnumerable<T> source, Func<T, T> selector)
    {
        foreach (var item in source)
        {
            yield return selector(item);
        }
    }
}