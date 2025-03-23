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
        var strlen = checked(count + (separatorStringLength * (foundItemsCount - 1)));

#if NET9_0_OR_GREATER
        var result = string.Create(
            length: strlen,
            state: new FlagsNamesStringCreationContext(names, foundItems, foundItemsCount),
            action: FlagsNamesStringCreationContext.Fill);
#elif NET6_0_OR_GREATER
        var result = string.Create(strlen, 0, static (_, _) => { });
        FlagsNamesStringCreationContext.Fill(
            MemoryMarshal.CreateSpan(ref MemoryMarshal.GetReference(result.AsSpan()), strlen),
            names,
            foundItems,
            foundItemsCount);
#else
        var result = new string('\0', strlen);
        fixed (char* ptr = result)
        {
            FlagsNamesStringCreationContext.Fill(
                new Span<char>(ptr, strlen),
                names,
                foundItems,
                foundItemsCount);
        }
#endif

        return result;
    }

    private readonly ref struct FlagsNamesStringCreationContext
    {
        private readonly ReadOnlySpan<string> _names;
        private readonly Span<int> _foundItems;
        private readonly int _foundItemsCount;

        public FlagsNamesStringCreationContext(ReadOnlySpan<string> names, Span<int> foundItems, int foundItemsCount)
        {
            _names = names;
            _foundItems = foundItems;
            _foundItemsCount = foundItemsCount;
        }

#if NET9_0_OR_GREATER
        public static void Fill(Span<char> destination, FlagsNamesStringCreationContext context)
        {
            context.Fill(destination);
        }
#else
        public static void Fill(
            Span<char> destination,
            ReadOnlySpan<string> names,
            Span<int> foundItems,
            int foundItemsCount)
        {
            new FlagsNamesStringCreationContext(names, foundItems, foundItemsCount).Fill(destination);
        }
#endif

        private void Fill(Span<char> destination)
        {
            var foundItemsCount = _foundItemsCount;
            var name = _names[_foundItems[--foundItemsCount]];
            name.AsSpan().CopyTo(destination);
            destination = destination.Slice(name.Length);
            while (--foundItemsCount >= 0)
            {
                destination[0] = ',';
                destination[1] = ' ';
                destination = destination.Slice(2);

                name = _names[_foundItems[foundItemsCount]];
                name.AsSpan().CopyTo(destination);
                destination = destination.Slice(name.Length);
            }
        }
    }
}
