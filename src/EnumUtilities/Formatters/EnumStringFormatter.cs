﻿namespace Raiqub.Generators.EnumUtilities.Formatters;

/// <summary>Provides utility methods for formatting enumerations as strings.</summary>
public static class EnumStringFormatter
{
    /// <summary>Gets the string count required to represent the given value using the specified formatter.</summary>
    /// <typeparam name="TFormatter">The type of the formatter.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="value">The value to format.</param>
    /// <param name="enumFormatter">The formatter to use.</param>
    /// <returns>The count of the string representation of the value.</returns>
    public static int GetStringCount<TFormatter, TNumber>(
        TNumber value,
        TFormatter enumFormatter)
        where TFormatter : IEnumFormatter<TNumber>
        where TNumber : struct
    {
        return enumFormatter.TryGetStringCountForMember(value) ?? enumFormatter.GetStringCountForNumber(value);
    }

    /// <summary>Gets the string representation of the given value using the specified formatter.</summary>
    /// <typeparam name="TFormatter">The type of the formatter.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="value">The value to format.</param>
    /// <param name="enumFormatter">The formatter to use.</param>
    /// <returns>The string representation of the value.</returns>
    public static string GetString<TFormatter, TNumber>(
        TNumber value,
        TFormatter enumFormatter)
        where TFormatter : IEnumFormatter<TNumber>
        where TNumber : struct
    {
        return enumFormatter.TryGetStringForMember(value) ?? enumFormatter.GetStringForNumber(value);
    }
}
