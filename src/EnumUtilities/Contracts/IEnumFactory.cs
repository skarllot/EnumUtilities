using System.Diagnostics.CodeAnalysis;

namespace Raiqub.Generators.EnumUtilities.Contracts;

/// <summary>
/// Defines factory methods for parsing string and character span representations into enumeration values.
/// </summary>
/// <typeparam name="TEnum">The enumeration type.</typeparam>
public interface IEnumFactory<TEnum>
    where TEnum : struct, Enum
{
    /// <summary>
    /// Converts the string representation of the name or numeric value of an enumeration constant
    /// to the equivalent enumeration value.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to consider case.</param>
    /// <returns>The enumeration value whose name or numeric value is represented by <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not correspond to a defined member.</exception>
    TEnum Parse(string value, bool ignoreCase = false);

    /// <summary>
    /// Converts the character span representation of the name or numeric value of an enumeration constant
    /// to the equivalent enumeration value.
    /// </summary>
    /// <param name="value">The character span to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to consider case.</param>
    /// <returns>The enumeration value whose name or numeric value is represented by <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not correspond to a defined member.</exception>
    TEnum Parse(ReadOnlySpan<char> value, bool ignoreCase = false);

    /// <summary>
    /// Converts the string representation of the name or numeric value of an enumeration constant
    /// to the equivalent enumeration value, returning <see langword="null"/> when the input is <see langword="null"/>.
    /// </summary>
    /// <param name="value">The string to convert, or <see langword="null"/>.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to consider case.</param>
    /// <returns>
    /// The enumeration value whose name or numeric value is represented by <paramref name="value"/>,
    /// or <see langword="null"/> if <paramref name="value"/> is <see langword="null"/>.
    /// </returns>
    /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not correspond to a defined member.</exception>
    [return: NotNullIfNotNull("value")]
    TEnum? ParseOrNull(string? value, bool ignoreCase = false);

    /// <summary>
    /// Tries to convert the string representation of the name or numeric value of an enumeration constant
    /// to the equivalent enumeration value, and returns a value indicating whether the conversion succeeded.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to consider case.</param>
    /// <param name="result">
    /// When this method returns <see langword="true"/>, contains the enumeration value represented by <paramref name="value"/>.
    /// When this method returns <see langword="false"/>, contains the default value of the underlying type.
    /// </param>
    /// <returns><see langword="true"/> if <paramref name="value"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    bool TryParse([NotNullWhen(true)] string? value, bool ignoreCase, out TEnum result);

    /// <summary>
    /// Tries to convert the string representation of the name or numeric value of an enumeration constant
    /// to the equivalent enumeration value, and returns a value indicating whether the conversion succeeded.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <param name="result">
    /// When this method returns <see langword="true"/>, contains the enumeration value represented by <paramref name="value"/>.
    /// When this method returns <see langword="false"/>, contains the default value of the underlying type.
    /// </param>
    /// <returns><see langword="true"/> if <paramref name="value"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    bool TryParse([NotNullWhen(true)] string? value, out TEnum result);

    /// <summary>
    /// Tries to convert the string representation of the name or numeric value of an enumeration constant
    /// to the equivalent enumeration value, returning <see langword="null"/> when the conversion fails.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to consider case.</param>
    /// <returns>
    /// The enumeration value represented by <paramref name="value"/> if the conversion succeeds;
    /// otherwise, <see langword="null"/>.
    /// </returns>
    TEnum? TryParse(string? value, bool ignoreCase = false);

    /// <summary>
    /// Tries to convert the character span representation of the name or numeric value of an enumeration constant
    /// to the equivalent enumeration value, and returns a value indicating whether the conversion succeeded.
    /// </summary>
    /// <param name="value">The character span to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to consider case.</param>
    /// <param name="result">
    /// When this method returns <see langword="true"/>, contains the enumeration value represented by <paramref name="value"/>.
    /// When this method returns <see langword="false"/>, contains the default value of the underlying type.
    /// </param>
    /// <returns><see langword="true"/> if <paramref name="value"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    bool TryParse(ReadOnlySpan<char> value, bool ignoreCase, out TEnum result);

    /// <summary>
    /// Tries to convert the character span representation of the name or numeric value of an enumeration constant
    /// to the equivalent enumeration value, and returns a value indicating whether the conversion succeeded.
    /// </summary>
    /// <param name="value">The character span to convert.</param>
    /// <param name="result">
    /// When this method returns <see langword="true"/>, contains the enumeration value represented by <paramref name="value"/>.
    /// When this method returns <see langword="false"/>, contains the default value of the underlying type.
    /// </param>
    /// <returns><see langword="true"/> if <paramref name="value"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    bool TryParse(ReadOnlySpan<char> value, out TEnum result);

    /// <summary>
    /// Tries to convert the character span representation of the name or numeric value of an enumeration constant
    /// to the equivalent enumeration value, returning <see langword="null"/> when the conversion fails.
    /// </summary>
    /// <param name="value">The character span to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to consider case.</param>
    /// <returns>
    /// The enumeration value represented by <paramref name="value"/> if the conversion succeeds;
    /// otherwise, <see langword="null"/>.
    /// </returns>
    TEnum? TryParse(ReadOnlySpan<char> value, bool ignoreCase = false);
}
