using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Raiqub.Generators.EnumUtilities.Formatters;

/// <summary>Provides utility methods for formatting enumerations as strings.</summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public static class EnumStringFormatter
{
    /// <summary>
    /// Writes the names of multiple found flags into a single string, separated by commas.
    /// </summary>
    /// <param name="singleNames">A span containing the names of single (non-composite) enumeration members.</param>
    /// <param name="compositeNames">A span containing the names of composite enumeration members.</param>
    /// <param name="foundItems">A span containing the found members, each indicating whether it is composite and its index within the respective names span.</param>
    /// <param name="stringLength">The total length of the resulting string, excluding separators.</param>
    /// <returns>A string that represents the names of the found flags, separated by commas.</returns>
    /// <exception cref="OverflowException">Thrown if the computed string length exceeds the capacity of an <see cref="int"/>.</exception>
    public static string WriteMultipleFoundFlagsNames(
        ReadOnlySpan<string?> singleNames,
        ReadOnlySpan<string> compositeNames,
        ReadOnlySpan<FoundMember> foundItems,
        int stringLength
    )
    {
        Debug.Assert(!foundItems.IsEmpty, "foundItems must not be empty");
        Debug.Assert(stringLength > 0, "stringLength must be greater than zero");

        if (foundItems.Length == 1)
        {
            var item = foundItems[0];
            return item.IsComposite ? compositeNames[item.MemberIndex] : singleNames[item.MemberIndex]!;
        }

        const int separatorStringLength = 2;
        var strlen = checked(stringLength + (separatorStringLength * (foundItems.Length - 1)));

#if NET9_0_OR_GREATER
        var result = string.Create(
            length: strlen,
            state: new FlagsNamesStringCreationContext(singleNames, compositeNames, foundItems),
            action: FlagsNamesStringCreationContext.Fill
        );
#else
        var result = string.Create(strlen, 0, static (_, _) => { });
        FlagsNamesStringCreationContext.Fill(
            MemoryMarshal.CreateSpan(ref MemoryMarshal.GetReference(result.AsSpan()), strlen),
            singleNames,
            compositeNames,
            foundItems
        );
#endif

        return result;
    }

    private readonly ref struct FlagsNamesStringCreationContext(
        ReadOnlySpan<string?> singleNames,
        ReadOnlySpan<string> compositeNames,
        ReadOnlySpan<FoundMember> foundItems
    )
    {
        private readonly ReadOnlySpan<string?> _singleNames = singleNames;
        private readonly ReadOnlySpan<string> _compositeNames = compositeNames;
        private readonly ReadOnlySpan<FoundMember> _foundItems = foundItems;

#if NET9_0_OR_GREATER
        public static void Fill(Span<char> destination, FlagsNamesStringCreationContext context)
        {
            context.Fill(destination);
        }
#else
        public static void Fill(
            Span<char> destination,
            ReadOnlySpan<string?> singleNames,
            ReadOnlySpan<string> compositeNames,
            ReadOnlySpan<FoundMember> foundItems
        )
        {
            new FlagsNamesStringCreationContext(singleNames, compositeNames, foundItems).Fill(destination);
        }
#endif

        private void Fill(Span<char> destination)
        {
            var foundItemsCount = _foundItems.Length;
            var item = _foundItems[--foundItemsCount];
            var name = item.IsComposite ? _compositeNames[item.MemberIndex] : _singleNames[item.MemberIndex]!;
            name.AsSpan().CopyTo(destination);
            destination = destination.Slice(name.Length);
            while (--foundItemsCount >= 0)
            {
                destination[0] = ',';
                destination[1] = ' ';
                destination = destination.Slice(2);

                item = _foundItems[foundItemsCount];
                name = item.IsComposite ? _compositeNames[item.MemberIndex] : _singleNames[item.MemberIndex]!;
                name.AsSpan().CopyTo(destination);
                destination = destination.Slice(name.Length);
            }
        }
    }
}
