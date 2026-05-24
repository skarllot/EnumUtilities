namespace Raiqub.Generators.EnumUtilities.Contracts;

/// <summary>Defines fast, reflection-free extension operations for a specific enum type.</summary>
/// <typeparam name="TEnum">The enum type this instance operates on.</typeparam>
public interface IEnumExtensions<TEnum>
    where TEnum : struct, Enum
{
    /// <summary>Converts the value of this instance to its equivalent string representation.</summary>
    /// <param name="value">The enum value to convert.</param>
    /// <returns>The string representation of the value of this instance.</returns>
    string ToStringFast(TEnum value);

    /// <summary>Calculates the number of characters produced by converting the specified value to string.</summary>
    /// <param name="value">The value to calculate the number of characters.</param>
    /// <returns>The number of characters produced by converting the specified value to string.</returns>
    int GetStringLength(TEnum value);

    /// <summary>Gets the <see cref="System.Runtime.Serialization.EnumMemberAttribute"/> value for the specified enum value, or its string representation if no attribute is defined.</summary>
    /// <param name="value">The enum value to convert.</param>
    /// <returns>The enum member value string associated with the enum value.</returns>
    string ToEnumMemberValue(TEnum value);

    /// <summary>Calculates the number of characters produced by converting the specified value to its enum member value string.</summary>
    /// <param name="value">The value to calculate the number of characters.</param>
    /// <returns>The number of characters produced by converting the specified value to its enum member value string.</returns>
    int GetEnumMemberValueStringLength(TEnum value);

    /// <summary>Gets the JSON string representation of the specified enum value, or <see langword="null"/> if the value has no JSON mapping.</summary>
    /// <param name="value">The enum value to convert.</param>
    /// <returns>The JSON string associated with the enum value, or <see langword="null"/> if no mapping exists.</returns>
    string? ToJsonString(TEnum value);

    /// <summary>Calculates the number of characters produced by converting the specified value to its JSON string representation, or <see langword="null"/> if the value has no JSON mapping.</summary>
    /// <param name="value">The value to calculate the number of characters.</param>
    /// <returns>The number of characters produced by converting the specified value to its JSON string, or <see langword="null"/> if no mapping exists.</returns>
    int? GetJsonStringLength(TEnum value);
}
