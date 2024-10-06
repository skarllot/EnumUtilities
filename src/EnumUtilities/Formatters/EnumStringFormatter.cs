using System.Runtime.InteropServices;

namespace Raiqub.Generators.EnumUtilities.Formatters;

/// <summary>Provides utility methods for formatting enumerations as strings.</summary>
public static class EnumStringFormatter
{
    /// <summary>
    /// Writes the names of multiple found flags into a single string, separated by commas.
    /// </summary>
    /// <param name="names">A span containing all enumeration names.</param>
    /// <param name="foundItems">A span containing the string of found enum values.</param>
    /// <param name="foundItemsCount">The number of enum values found.</param>
    /// <param name="count">The total length of the resulting string, excluding separators.</param>
    /// <returns>A string that represents the names of the found flags, separated by commas.</returns>
    /// <exception cref="OverflowException">Thrown if the computed string length exceeds the capacity of an <see cref="int"/>.</exception>
    public static unsafe string WriteMultipleFoundFlagsNames(
        ReadOnlySpan<string> names,
        Span<int> foundItems,
        int foundItemsCount,
        int count)
    {
        const int separatorStringLength = 2;
        int strlen = checked(count + (separatorStringLength * (foundItemsCount - 1)));

#if NET6_0_OR_GREATER
        var result = string.Create(strlen, 0, static (_, _) => { });
        var span = MemoryMarshal.CreateSpan(ref MemoryMarshal.GetReference(result.AsSpan()), strlen);
        {
#else
        var result = new string('\0', strlen);
        fixed (char* ptr = result)
        {
            var span = new Span<char>(ptr, strlen);
#endif

            string name = names[foundItems[--foundItemsCount]];
            name.AsSpan().CopyTo(span);
            span = span.Slice(name.Length);
            while (--foundItemsCount >= 0)
            {
                span[0] = ',';
                span[1] = ' ';
                span = span.Slice(2);

                name = names[foundItems[foundItemsCount]];
                name.AsSpan().CopyTo(span);
                span = span.Slice(name.Length);
            }
        }

        return result;
    }
}
