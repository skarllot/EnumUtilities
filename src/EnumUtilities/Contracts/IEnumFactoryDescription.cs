using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Raiqub.Generators.EnumUtilities.Contracts;

/// <summary>
/// Defines factory methods for parsing <see cref="DescriptionAttribute"/> values into enumeration values.
/// </summary>
/// <typeparam name="TEnum">The enumeration type.</typeparam>
public interface IEnumFactoryDescription<TEnum>
    where TEnum : struct, Enum
{
    /// <summary>
    /// Converts the string representation of a <see cref="DescriptionAttribute"/> value
    /// to the equivalent enumeration value.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns>The enumeration value whose <see cref="DescriptionAttribute"/> value is represented by <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not correspond to a defined member.</exception>
    TEnum CreateFromDescription(string value, StringComparison comparisonType = StringComparison.Ordinal);

    /// <summary>
    /// Converts the character span representation of a <see cref="DescriptionAttribute"/> value
    /// to the equivalent enumeration value.
    /// </summary>
    /// <param name="value">The character span to convert.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns>The enumeration value whose <see cref="DescriptionAttribute"/> value is represented by <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not correspond to a defined member.</exception>
    TEnum CreateFromDescription(ReadOnlySpan<char> value, StringComparison comparisonType = StringComparison.Ordinal);

    /// <summary>
    /// Converts the string representation of a <see cref="DescriptionAttribute"/> value
    /// to the equivalent enumeration value, returning <see langword="null"/> when the input is <see langword="null"/>.
    /// </summary>
    /// <param name="value">The string to convert, or <see langword="null"/>.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns>
    /// The enumeration value whose <see cref="DescriptionAttribute"/> value is represented
    /// by <paramref name="value"/>, or <see langword="null"/> if <paramref name="value"/> is <see langword="null"/>.
    /// </returns>
    /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not correspond to a defined member.</exception>
    [return: NotNullIfNotNull("value")]
    TEnum? CreateFromDescriptionOrNull(string? value, StringComparison comparisonType = StringComparison.Ordinal);

    /// <summary>
    /// Tries to convert the string representation of a <see cref="DescriptionAttribute"/> value
    /// to the equivalent enumeration value, and returns a value indicating whether the conversion succeeded.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <param name="result">
    /// When this method returns <see langword="true"/>, contains the enumeration value represented by <paramref name="value"/>.
    /// When this method returns <see langword="false"/>, contains the default value of the underlying type.
    /// </param>
    /// <returns><see langword="true"/> if <paramref name="value"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    bool TryCreateFromDescription([NotNullWhen(true)] string? value, StringComparison comparisonType, out TEnum result);

    /// <summary>
    /// Tries to convert the string representation of a <see cref="DescriptionAttribute"/> value
    /// to the equivalent enumeration value, and returns a value indicating whether the conversion succeeded.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <param name="result">
    /// When this method returns <see langword="true"/>, contains the enumeration value represented by <paramref name="value"/>.
    /// When this method returns <see langword="false"/>, contains the default value of the underlying type.
    /// </param>
    /// <returns><see langword="true"/> if <paramref name="value"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    bool TryCreateFromDescription([NotNullWhen(true)] string? value, out TEnum result);

    /// <summary>
    /// Tries to convert the string representation of a <see cref="DescriptionAttribute"/> value
    /// to the equivalent enumeration value, returning <see langword="null"/> when the conversion fails.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns>
    /// The enumeration value represented by <paramref name="value"/> if the conversion succeeds;
    /// otherwise, <see langword="null"/>.
    /// </returns>
    TEnum? TryCreateFromDescription(string? value, StringComparison comparisonType = StringComparison.Ordinal);

    /// <summary>
    /// Tries to convert the character span representation of a <see cref="DescriptionAttribute"/> value
    /// to the equivalent enumeration value, and returns a value indicating whether the conversion succeeded.
    /// </summary>
    /// <param name="value">The character span to convert.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <param name="result">
    /// When this method returns <see langword="true"/>, contains the enumeration value represented by <paramref name="value"/>.
    /// When this method returns <see langword="false"/>, contains the default value of the underlying type.
    /// </param>
    /// <returns><see langword="true"/> if <paramref name="value"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    bool TryCreateFromDescription(ReadOnlySpan<char> value, StringComparison comparisonType, out TEnum result);

    /// <summary>
    /// Tries to convert the character span representation of a <see cref="DescriptionAttribute"/> value
    /// to the equivalent enumeration value, and returns a value indicating whether the conversion succeeded.
    /// </summary>
    /// <param name="value">The character span to convert.</param>
    /// <param name="result">
    /// When this method returns <see langword="true"/>, contains the enumeration value represented by <paramref name="value"/>.
    /// When this method returns <see langword="false"/>, contains the default value of the underlying type.
    /// </param>
    /// <returns><see langword="true"/> if <paramref name="value"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    bool TryCreateFromDescription(ReadOnlySpan<char> value, out TEnum result);

    /// <summary>
    /// Tries to convert the character span representation of a <see cref="DescriptionAttribute"/> value
    /// to the equivalent enumeration value, returning <see langword="null"/> when the conversion fails.
    /// </summary>
    /// <param name="value">The character span to convert.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns>
    /// The enumeration value represented by <paramref name="value"/> if the conversion succeeds;
    /// otherwise, <see langword="null"/>.
    /// </returns>
    TEnum? TryCreateFromDescription(
        ReadOnlySpan<char> value,
        StringComparison comparisonType = StringComparison.Ordinal
    );
}
