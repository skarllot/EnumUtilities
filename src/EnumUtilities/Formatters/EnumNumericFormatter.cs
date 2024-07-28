using System.ComponentModel;

namespace Raiqub.Generators.EnumUtilities.Formatters;

/// <summary>Formatter to represent enumerations as numeric text.</summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public static class EnumNumericFormatter
{
    /// <summary>
    /// Gets the string length required to represent an 8-bit signed integer value as numeric text.
    /// </summary>
    /// <param name="value">The number to count digits.</param>
    /// <returns>The length of the string representation of the value.</returns>
    public static int GetStringLength(sbyte value) =>
        (value < 0 ? -value : value) switch
        {
            // Max = 127
            > 99 => 3,
            > 9 => 2,
            _ => 1,
        } + (value < 0 ? 1 : 0);

    /// <summary>
    /// Gets the string length required to represent an 8-bit unsigned integer value as numeric text.
    /// </summary>
    /// <param name="value">The number to count digits.</param>
    /// <returns>The length of the string representation of the value.</returns>
    public static int GetStringLength(byte value) =>
        value switch
        {
            // Max = 255
            > 99 => 3,
            > 9 => 2,
            _ => 1,
        };

    /// <summary>
    /// Gets the string length required to represent an 16-bit signed integer value as numeric text.
    /// </summary>
    /// <param name="value">The number to count digits.</param>
    /// <returns>The length of the string representation of the value.</returns>
    public static int GetStringLength(short value) =>
        (value < 0 ? -value : value) switch
        {
            // Max = 32_767
            > 9_999 => 5,
            > 999 => 4,
            > 99 => 3,
            > 9 => 2,
            _ => 1,
        } + (value < 0 ? 1 : 0);

    /// <summary>
    /// Gets the string length required to represent an 16-bit unsigned integer value as numeric text.
    /// </summary>
    /// <param name="value">The number to count digits.</param>
    /// <returns>The length of the string representation of the value.</returns>
    public static int GetStringLength(ushort value) =>
        value switch
        {
            // Max = 65_535
            > 9_999 => 5,
            > 999 => 4,
            > 99 => 3,
            > 9 => 2,
            _ => 1,
        };

    /// <summary>
    /// Gets the string length required to represent an 32-bit signed integer value as numeric text.
    /// </summary>
    /// <param name="value">The number to count digits.</param>
    /// <returns>The length of the string representation of the value.</returns>
    public static int GetStringLength(int value) =>
        value == int.MinValue
            ? 11
            : (value < 0 ? -value : value) switch
            {
                // Max = 2_147_483_647
                > 999_999_999 => 10,
                > 99_999_999 => 9,
                > 9_999_999 => 8,
                > 999_999 => 7,
                > 99_999 => 6,
                > 9_999 => 5,
                > 999 => 4,
                > 99 => 3,
                > 9 => 2,
                _ => 1,
            } + (value < 0 ? 1 : 0);

    /// <summary>
    /// Gets the string length required to represent an 32-bit unsigned integer value as numeric text.
    /// </summary>
    /// <param name="value">The number to count digits.</param>
    /// <returns>The length of the string representation of the value.</returns>
    public static int GetStringLength(uint value) =>
        value switch
        {
            // Max = 4_294_967_295
            > 999_999_999U => 10,
            > 99_999_999U => 9,
            > 9_999_999U => 8,
            > 999_999U => 7,
            > 99_999U => 6,
            > 9_999U => 5,
            > 999U => 4,
            > 99U => 3,
            > 9U => 2,
            _ => 1,
        };

    /// <summary>
    /// Gets the string length required to represent an 64-bit signed integer value as numeric text.
    /// </summary>
    /// <param name="value">The number to count digits.</param>
    /// <returns>The length of the string representation of the value.</returns>
    public static int GetStringLength(long value) =>
        value == long.MinValue
            ? 20
            : (value < 0 ? -value : value) switch
            {
                // Max = 9_223_372_036_854_775_807
                > 999_999_999_999_999_999L => 19,
                > 99_999_999_999_999_999L => 18,
                > 9_999_999_999_999_999L => 17,
                > 999_999_999_999_999L => 16,
                > 99_999_999_999_999L => 15,
                > 9_999_999_999_999L => 14,
                > 999_999_999_999L => 13,
                > 99_999_999_999L => 12,
                > 9_999_999_999L => 11,
                > 999_999_999L => 10,
                > 99_999_999L => 9,
                > 9_999_999L => 8,
                > 999_999L => 7,
                > 99_999L => 6,
                > 9_999L => 5,
                > 999L => 4,
                > 99L => 3,
                > 9L => 2,
                _ => 1,
            } + (value < 0 ? 1 : 0);

    /// <summary>
    /// Gets the string length required to represent an 64-bit unsigned integer value as numeric text.
    /// </summary>
    /// <param name="value">The number to count digits.</param>
    /// <returns>The length of the string representation of the value.</returns>
    public static int GetStringLength(ulong value) =>
        value switch
        {
            // Max = 18_446_744_073_709_551_615
            > 9_999_999_999_999_999_999UL => 20,
            > 999_999_999_999_999_999UL => 19,
            > 99_999_999_999_999_999UL => 18,
            > 9_999_999_999_999_999UL => 17,
            > 999_999_999_999_999UL => 16,
            > 99_999_999_999_999UL => 15,
            > 9_999_999_999_999UL => 14,
            > 999_999_999_999UL => 13,
            > 99_999_999_999UL => 12,
            > 9_999_999_999UL => 11,
            > 999_999_999UL => 10,
            > 99_999_999UL => 9,
            > 9_999_999UL => 8,
            > 999_999UL => 7,
            > 99_999UL => 6,
            > 9_999UL => 5,
            > 999UL => 4,
            > 99UL => 3,
            > 9UL => 2,
            _ => 1,
        };
}
