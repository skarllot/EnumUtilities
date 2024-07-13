using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Raiqub.Generators.EnumUtilities.Parsers;

/// <summary>
/// A <see langword="ref"/> <see langword="struct"/> that tokenizes a given span of characters for bit flags enum.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
internal ref struct FlagsEnumTokenizer
{
    /// <summary>Character used to separate flag enum values when formatted in a list.</summary>
    private const char EnumSeparatorChar = ',';

    private readonly ReadOnlySpan<char> _span;
    private int _start;
    private int _end;

    /// <summary>Initializes a new instance of the <see cref="FlagsEnumTokenizer"/> struct.</summary>
    /// <param name="span">The source <see cref="ReadOnlySpan{T}"/> instance.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlagsEnumTokenizer(ReadOnlySpan<char> span)
    {
        _span = span;
        _start = 0;
        _end = -1;
    }

    /// <summary>Returns an enumerator that iterates through the span of characters.</summary>
    /// <returns>An <see cref="FlagsEnumTokenizer"/> instance targeting the current <see cref="ReadOnlySpan{T}"/> value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly FlagsEnumTokenizer GetEnumerator() => this;

    /// <summary>Advances the enumerator to the next element of the collection.</summary>
    /// <returns><see langword="true"/> whether a new element is available, <see langword="false"/> otherwise</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        int newEnd = _end + 1;
        int length = _span.Length;

        // Additional check if the separator is not the last character
        if (newEnd <= length)
        {
            _start = newEnd;
            int index = _span.Slice(newEnd).IndexOf(EnumSeparatorChar);

            // Extract the current subsequence
            if (index >= 0)
            {
                _end = newEnd + index;
                return true;
            }

            _end = length;
            return true;
        }

        return false;
    }

    /// <summary>Gets the element in the span at the current position of the enumerator.</summary>
    public readonly ReadOnlySpan<char> Current
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _span.Slice(_start, _end - _start).Trim();
    }
}
