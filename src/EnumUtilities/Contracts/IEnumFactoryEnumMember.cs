using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Raiqub.Generators.EnumUtilities.Contracts;

/// <summary>
/// Defines factory methods for parsing <see cref="EnumMemberAttribute"/> values into enumeration values.
/// Each member is matched against its <see cref="EnumMemberAttribute"/> value if the attribute is defined,
/// otherwise the member name is used.
/// </summary>
/// <typeparam name="TEnum">The enumeration type.</typeparam>
public interface IEnumFactoryEnumMember<TEnum>
    where TEnum : struct, Enum
{
    /// <summary>
    /// Converts the string representation of an <see cref="EnumMemberAttribute"/> value
    /// to the equivalent enumeration value.
    /// Each member is matched against its <see cref="EnumMemberAttribute"/> value if the attribute is defined,
    /// otherwise the member name is used.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to consider case.</param>
    /// <returns>The enumeration value represented by <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not correspond to a defined member.</exception>
    TEnum ParseFromEnumMemberValue(string value, bool ignoreCase = false);

    /// <summary>
    /// Converts the character span representation of an <see cref="EnumMemberAttribute"/> value
    /// to the equivalent enumeration value.
    /// Each member is matched against its <see cref="EnumMemberAttribute"/> value if the attribute is defined,
    /// otherwise the member name is used.
    /// </summary>
    /// <param name="value">The character span to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to consider case.</param>
    /// <returns>The enumeration value represented by <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not correspond to a defined member.</exception>
    TEnum ParseFromEnumMemberValue(ReadOnlySpan<char> value, bool ignoreCase = false);

    /// <summary>
    /// Converts the string representation of an <see cref="EnumMemberAttribute"/> value
    /// to the equivalent enumeration value, returning <see langword="null"/> when the input is <see langword="null"/>.
    /// Each member is matched against its <see cref="EnumMemberAttribute"/> value if the attribute is defined,
    /// otherwise the member name is used.
    /// </summary>
    /// <param name="value">The string to convert, or <see langword="null"/>.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to consider case.</param>
    /// <returns>
    /// The enumeration value represented by <paramref name="value"/>,
    /// or <see langword="null"/> if <paramref name="value"/> is <see langword="null"/>.
    /// </returns>
    /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not correspond to a defined member.</exception>
    [return: NotNullIfNotNull("value")]
    TEnum? ParseFromEnumMemberValueOrNull(string? value, bool ignoreCase = false);

    /// <summary>
    /// Tries to convert the string representation of an <see cref="EnumMemberAttribute"/> value
    /// to the equivalent enumeration value, and returns a value indicating whether the conversion succeeded.
    /// Each member is matched against its <see cref="EnumMemberAttribute"/> value if the attribute is defined,
    /// otherwise the member name is used.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to consider case.</param>
    /// <param name="result">
    /// When this method returns <see langword="true"/>, contains the enumeration value represented by <paramref name="value"/>.
    /// When this method returns <see langword="false"/>, contains the default value of the underlying type.
    /// </param>
    /// <returns><see langword="true"/> if <paramref name="value"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    bool TryParseFromEnumMemberValue([NotNullWhen(true)] string? value, bool ignoreCase, out TEnum result);

    /// <summary>
    /// Tries to convert the string representation of an <see cref="EnumMemberAttribute"/> value
    /// to the equivalent enumeration value, and returns a value indicating whether the conversion succeeded.
    /// Each member is matched against its <see cref="EnumMemberAttribute"/> value if the attribute is defined,
    /// otherwise the member name is used.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <param name="result">
    /// When this method returns <see langword="true"/>, contains the enumeration value represented by <paramref name="value"/>.
    /// When this method returns <see langword="false"/>, contains the default value of the underlying type.
    /// </param>
    /// <returns><see langword="true"/> if <paramref name="value"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    bool TryParseFromEnumMemberValue([NotNullWhen(true)] string? value, out TEnum result);

    /// <summary>
    /// Tries to convert the string representation of an <see cref="EnumMemberAttribute"/> value
    /// to the equivalent enumeration value, returning <see langword="null"/> when the conversion fails.
    /// Each member is matched against its <see cref="EnumMemberAttribute"/> value if the attribute is defined,
    /// otherwise the member name is used.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to consider case.</param>
    /// <returns>
    /// The enumeration value represented by <paramref name="value"/> if the conversion succeeds;
    /// otherwise, <see langword="null"/>.
    /// </returns>
    TEnum? TryParseFromEnumMemberValue(string? value, bool ignoreCase = false);

    /// <summary>
    /// Tries to convert the character span representation of an <see cref="EnumMemberAttribute"/> value
    /// to the equivalent enumeration value, and returns a value indicating whether the conversion succeeded.
    /// Each member is matched against its <see cref="EnumMemberAttribute"/> value if the attribute is defined,
    /// otherwise the member name is used.
    /// </summary>
    /// <param name="value">The character span to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to consider case.</param>
    /// <param name="result">
    /// When this method returns <see langword="true"/>, contains the enumeration value represented by <paramref name="value"/>.
    /// When this method returns <see langword="false"/>, contains the default value of the underlying type.
    /// </param>
    /// <returns><see langword="true"/> if <paramref name="value"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    bool TryParseFromEnumMemberValue(ReadOnlySpan<char> value, bool ignoreCase, out TEnum result);

    /// <summary>
    /// Tries to convert the character span representation of an <see cref="EnumMemberAttribute"/> value
    /// to the equivalent enumeration value, and returns a value indicating whether the conversion succeeded.
    /// Each member is matched against its <see cref="EnumMemberAttribute"/> value if the attribute is defined,
    /// otherwise the member name is used.
    /// </summary>
    /// <param name="value">The character span to convert.</param>
    /// <param name="result">
    /// When this method returns <see langword="true"/>, contains the enumeration value represented by <paramref name="value"/>.
    /// When this method returns <see langword="false"/>, contains the default value of the underlying type.
    /// </param>
    /// <returns><see langword="true"/> if <paramref name="value"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    bool TryParseFromEnumMemberValue(ReadOnlySpan<char> value, out TEnum result);

    /// <summary>
    /// Tries to convert the character span representation of an <see cref="EnumMemberAttribute"/> value
    /// to the equivalent enumeration value, returning <see langword="null"/> when the conversion fails.
    /// Each member is matched against its <see cref="EnumMemberAttribute"/> value if the attribute is defined,
    /// otherwise the member name is used.
    /// </summary>
    /// <param name="value">The character span to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to consider case.</param>
    /// <returns>
    /// The enumeration value represented by <paramref name="value"/> if the conversion succeeds;
    /// otherwise, <see langword="null"/>.
    /// </returns>
    TEnum? TryParseFromEnumMemberValue(ReadOnlySpan<char> value, bool ignoreCase = false);
}
