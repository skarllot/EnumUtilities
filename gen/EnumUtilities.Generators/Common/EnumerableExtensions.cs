namespace Raiqub.Generators.EnumUtilities.Common;

public static class EnumerableExtensions
{
    public static string JoinToString(this byte[] source)
    {
        Span<char> result = stackalloc char[source.Sum(GetStringLength) + (2 * (source.Length - 1))];
        var span = result;

        string str = source[0].ToString();
        str.AsSpan().CopyTo(span);
        span = span.Slice(str.Length);

        foreach (byte item in source.Skip(1))
        {
            span[0] = ',';
            span[1] = ' ';
            span = span.Slice(2);

            str = item.ToString();
            str.AsSpan().CopyTo(span);
            span = span.Slice(str.Length);
        }

        return result.ToString();
    }

    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source)
    {
        return source.Where(static it => it is not null)!;
    }

    private static int GetStringLength(byte value) =>
        value switch
        {
            // Max = 255
            > 99 => 3,
            > 9 => 2,
            _ => 1,
        };
}
