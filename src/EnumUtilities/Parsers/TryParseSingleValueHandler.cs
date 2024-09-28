namespace Raiqub.Generators.EnumUtilities.Parsers;

/// <summary>
/// Represents a method that attempts to parse an enumeration value from a string, using a specified comparison type
/// and returns a result.
/// The <typeparamref name="TNumber"/> generic parameter must be of an unmanaged numeric type.
/// </summary>
/// <typeparam name="TNumber">The type of the number.</typeparam>
/// <param name="value">A <see cref="ReadOnlySpan{T}"/> representing the string to parse.</param>
/// <param name="comparisonType">An enumeration value that determines how enumeration values are compared.</param>
/// <param name="result">
/// When this method returns, contains the parsed enumeration value if the parsing succeeded.
/// If the parsing fails, result is zero.
/// </param>
/// <returns>true if the parsing was successful; otherwise, false.</returns>
public delegate bool TryParseSingleValueHandler<TNumber>(
    ReadOnlySpan<char> value,
    StringComparison comparisonType,
    out TNumber result)
    where TNumber : unmanaged;
