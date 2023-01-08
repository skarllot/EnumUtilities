namespace Raiqub.Generators.EnumUtilities;

public static class EnumerableExtensions
{
    public static IEnumerable<TSource> DistinctBy<TSource, TKey>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        IEqualityComparer<TKey>? comparer = null)
    {
        var hashSet = new HashSet<TKey>(comparer);
        foreach (var item in source)
        {
            if (hashSet.Add(keySelector(item)))
                yield return item;
        }
    }
}