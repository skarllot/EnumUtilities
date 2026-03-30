using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Raiqub.Generators.EnumUtilities.Contracts;

/// <summary>
/// Defines factory methods for parsing JSON string values into enumeration values.
/// Each member is matched against its <see cref="JsonPropertyNameAttribute"/> value if defined,
/// otherwise its <see cref="EnumMemberAttribute"/> value if defined, otherwise the member name.
/// </summary>
/// <typeparam name="TEnum">The enumeration type.</typeparam>
public interface IEnumFactoryJson<TEnum>
    where TEnum : struct, Enum
{
    /// <summary>
    /// Converts the string representation of a JSON string value to the equivalent enumeration value.
    /// Each member is matched against its <see cref="JsonPropertyNameAttribute"/> value if defined,
    /// otherwise its <see cref="EnumMemberAttribute"/> value if defined, otherwise the member name.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns>The enumeration value represented by <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not correspond to a defined member.</exception>
    TEnum ParseJsonString(string value, StringComparison comparisonType = StringComparison.Ordinal);

    /// <summary>
    /// Converts the character span representation of a JSON string value to the equivalent enumeration value.
    /// Each member is matched against its <see cref="JsonPropertyNameAttribute"/> value if defined,
    /// otherwise its <see cref="EnumMemberAttribute"/> value if defined, otherwise the member name.
    /// </summary>
    /// <param name="value">The character span to convert.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns>The enumeration value represented by <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not correspond to a defined member.</exception>
    TEnum ParseJsonString(ReadOnlySpan<char> value, StringComparison comparisonType = StringComparison.Ordinal);

    /// <summary>
    /// Converts the string representation of a JSON string value to the equivalent enumeration value,
    /// returning <see langword="null"/> when the input is <see langword="null"/>.
    /// Each member is matched against its <see cref="JsonPropertyNameAttribute"/> value if defined,
    /// otherwise its <see cref="EnumMemberAttribute"/> value if defined, otherwise the member name.
    /// </summary>
    /// <param name="value">The string to convert, or <see langword="null"/>.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns>
    /// The enumeration value represented by <paramref name="value"/>,
    /// or <see langword="null"/> if <paramref name="value"/> is <see langword="null"/>.
    /// </returns>
    /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not correspond to a defined member.</exception>
    [return: NotNullIfNotNull("value")]
    TEnum? ParseJsonStringOrNull(string? value, StringComparison comparisonType = StringComparison.Ordinal);

    /// <summary>
    /// Tries to convert the string representation of a JSON string value to the equivalent enumeration value,
    /// and returns a value indicating whether the conversion succeeded.
    /// Each member is matched against its <see cref="JsonPropertyNameAttribute"/> value if defined,
    /// otherwise its <see cref="EnumMemberAttribute"/> value if defined, otherwise the member name.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <param name="result">
    /// When this method returns <see langword="true"/>, contains the enumeration value represented by <paramref name="value"/>.
    /// When this method returns <see langword="false"/>, contains the default value of the underlying type.
    /// </param>
    /// <returns><see langword="true"/> if <paramref name="value"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    bool TryParseJsonString([NotNullWhen(true)] string? value, StringComparison comparisonType, out TEnum result);

    /// <summary>
    /// Tries to convert the string representation of a JSON string value to the equivalent enumeration value,
    /// and returns a value indicating whether the conversion succeeded.
    /// Each member is matched against its <see cref="JsonPropertyNameAttribute"/> value if defined,
    /// otherwise its <see cref="EnumMemberAttribute"/> value if defined, otherwise the member name.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <param name="result">
    /// When this method returns <see langword="true"/>, contains the enumeration value represented by <paramref name="value"/>.
    /// When this method returns <see langword="false"/>, contains the default value of the underlying type.
    /// </param>
    /// <returns><see langword="true"/> if <paramref name="value"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    bool TryParseJsonString([NotNullWhen(true)] string? value, out TEnum result);

    /// <summary>
    /// Tries to convert the string representation of a JSON string value to the equivalent enumeration value,
    /// returning <see langword="null"/> when the conversion fails.
    /// Each member is matched against its <see cref="JsonPropertyNameAttribute"/> value if defined,
    /// otherwise its <see cref="EnumMemberAttribute"/> value if defined, otherwise the member name.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns>
    /// The enumeration value represented by <paramref name="value"/> if the conversion succeeds;
    /// otherwise, <see langword="null"/>.
    /// </returns>
    TEnum? TryParseJsonString(string? value, StringComparison comparisonType = StringComparison.Ordinal);

    /// <summary>
    /// Tries to convert the character span representation of a JSON string value to the equivalent enumeration value,
    /// and returns a value indicating whether the conversion succeeded.
    /// Each member is matched against its <see cref="JsonPropertyNameAttribute"/> value if defined,
    /// otherwise its <see cref="EnumMemberAttribute"/> value if defined, otherwise the member name.
    /// </summary>
    /// <param name="value">The character span to convert.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <param name="result">
    /// When this method returns <see langword="true"/>, contains the enumeration value represented by <paramref name="value"/>.
    /// When this method returns <see langword="false"/>, contains the default value of the underlying type.
    /// </param>
    /// <returns><see langword="true"/> if <paramref name="value"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    bool TryParseJsonString(ReadOnlySpan<char> value, StringComparison comparisonType, out TEnum result);

    /// <summary>
    /// Tries to convert the character span representation of a JSON string value to the equivalent enumeration value,
    /// and returns a value indicating whether the conversion succeeded.
    /// Each member is matched against its <see cref="JsonPropertyNameAttribute"/> value if defined,
    /// otherwise its <see cref="EnumMemberAttribute"/> value if defined, otherwise the member name.
    /// </summary>
    /// <param name="value">The character span to convert.</param>
    /// <param name="result">
    /// When this method returns <see langword="true"/>, contains the enumeration value represented by <paramref name="value"/>.
    /// When this method returns <see langword="false"/>, contains the default value of the underlying type.
    /// </param>
    /// <returns><see langword="true"/> if <paramref name="value"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    bool TryParseJsonString(ReadOnlySpan<char> value, out TEnum result);

    /// <summary>
    /// Tries to convert the character span representation of a JSON string value to the equivalent enumeration value,
    /// returning <see langword="null"/> when the conversion fails.
    /// Each member is matched against its <see cref="JsonPropertyNameAttribute"/> value if defined,
    /// otherwise its <see cref="EnumMemberAttribute"/> value if defined, otherwise the member name.
    /// </summary>
    /// <param name="value">The character span to convert.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns>
    /// The enumeration value represented by <paramref name="value"/> if the conversion succeeds;
    /// otherwise, <see langword="null"/>.
    /// </returns>
    TEnum? TryParseJsonString(ReadOnlySpan<char> value, StringComparison comparisonType = StringComparison.Ordinal);
}
