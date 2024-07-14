using System.Runtime.CompilerServices;

namespace Raiqub.Generators.EnumUtilities.Parsers;

/// <summary>Represents a generic interface for parsing and manipulating enum values.</summary>
/// <typeparam name="T">The underlying type of enum.</typeparam>
public interface IEnumParser<T>
{
    /// <summary>Computes the bitwise OR of two enum values.</summary>
    /// <param name="value1">The first enum value.</param>
    /// <param name="value2">The second enum value.</param>
    /// <returns>The result of the bitwise OR operation.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    T BitwiseOr(T value1, T value2);

    /// <summary>Tries to parse an enum value from a numeric representation.</summary>
    /// <param name="value">The numeric representation as a character span.</param>
    /// <param name="result">When this method returns, contains the parsed enum value if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    bool TryParseNumber(ReadOnlySpan<char> value, out T result);

    /// <summary>Tries to parse an enum value from a single name.</summary>
    /// <param name="value">The name of the enum value as a character span.</param>
    /// <param name="ignoreCase">Indicates whether the parsing should be case-insensitive.</param>
    /// <param name="result">When this method returns, contains the parsed enum value if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    bool TryParseSingleName(ReadOnlySpan<char> value, bool ignoreCase, out T result);
}
