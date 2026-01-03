using System.Diagnostics;
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
    /// <param name="count">The total length of the resulting string, excluding separators.</param>
    /// <returns>A string that represents the names of the found flags, separated by commas.</returns>
    /// <exception cref="OverflowException">Thrown if the computed string length exceeds the capacity of an <see cref="int"/>.</exception>
    public static string WriteMultipleFoundFlagsNames(
        ReadOnlySpan<string> names,
        ReadOnlySpan<int> foundItems,
        int count)
    {
        Debug.Assert(!foundItems.IsEmpty, "foundItems must not be empty");
        Debug.Assert(count > 0, "count must be greater than zero");

        const int separatorStringLength = 2;
        var strlen = checked(count + (separatorStringLength * (foundItems.Length - 1)));

#if NET9_0_OR_GREATER
        var result = string.Create(
            length: strlen,
            state: new FlagsNamesStringCreationContext(names, foundItems),
            action: FlagsNamesStringCreationContext.Fill);
#else
        var result = string.Create(strlen, 0, static (_, _) => { });
        FlagsNamesStringCreationContext.Fill(
            MemoryMarshal.CreateSpan(ref MemoryMarshal.GetReference(result.AsSpan()), strlen),
            names,
            foundItems);
#endif

        return result;
    }

    private readonly ref struct FlagsNamesStringCreationContext
    {
        private readonly ReadOnlySpan<string> _names;
        private readonly ReadOnlySpan<int> _foundItems;

        public FlagsNamesStringCreationContext(
            ReadOnlySpan<string> names,
            ReadOnlySpan<int> foundItems)
        {
            _names = names;
            _foundItems = foundItems;
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
            ReadOnlySpan<int> foundItems)
        {
            new FlagsNamesStringCreationContext(names, foundItems).Fill(destination);
        }
#endif

        private void Fill(Span<char> destination)
        {
            var foundItemsCount = _foundItems.Length;
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
