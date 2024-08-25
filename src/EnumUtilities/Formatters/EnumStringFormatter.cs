namespace Raiqub.Generators.EnumUtilities.Formatters;

/// <summary>Provides utility methods for formatting enumerations as strings.</summary>
public static class EnumStringFormatter
{
    /// <summary>Gets the number of characters required to represent the given value using the specified formatter.</summary>
    /// <typeparam name="TFormatter">The type of the formatter.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="value">The value to format.</param>
    /// <param name="enumFormatter">The formatter to use.</param>
    /// <returns>The length of the string representation of the value.</returns>
    public static int GetStringLength<TFormatter, TNumber>(
        TNumber value,
        TFormatter enumFormatter)
        where TFormatter : IEnumFormatter<TNumber>
        where TNumber : struct
    {
        return enumFormatter.TryGetStringLengthForMember(value) ?? enumFormatter.GetStringLengthForNumber(value);
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

    /// <summary>
    /// Writes the names of multiple found flags into a single string, separated by commas.
    /// </summary>
    /// <typeparam name="TFormatter">The type of the formatter used to get string representations of the flags.</typeparam>
    /// <typeparam name="TNumber">The underlying type of the enumeration values.</typeparam>
    /// <param name="enumFormatter">The formatter used to convert enum values to their string representations.</param>
    /// <param name="count">The total length of the resulting string, excluding separators.</param>
    /// <param name="foundItemsCount">The number of enum values found.</param>
    /// <param name="foundItems">A span containing the found enum values.</param>
    /// <returns>A string that represents the names of the found flags, separated by commas.</returns>
    /// <exception cref="OverflowException">Thrown if the computed string length exceeds the capacity of an <see cref="int"/>.</exception>
    public static string WriteMultipleFoundFlagsNames<TFormatter, TNumber>(
        TFormatter enumFormatter,
        int count,
        int foundItemsCount,
        Span<TNumber> foundItems)
        where TFormatter : IEnumFlagsFormatter<TNumber>
        where TNumber : struct
    {
        const int separatorStringLength = 2;
        const char enumSeparatorChar = ',';
        int strlen = checked(count + (separatorStringLength * (foundItemsCount - 1)));
        Span<char> result = strlen <= 128
            ? stackalloc char[128].Slice(0, strlen)
            : new char[strlen];
        var span = result;

        string name = enumFormatter.GetStringForSingleMember(foundItems[--foundItemsCount]);
        name.AsSpan().CopyTo(span);
        span = span.Slice(name.Length);
        while (--foundItemsCount >= 0)
        {
            span[0] = enumSeparatorChar;
            span[1] = ' ';
            span = span.Slice(2);

            name = enumFormatter.GetStringForSingleMember(foundItems[foundItemsCount]);
            name.AsSpan().CopyTo(span);
            span = span.Slice(name.Length);
        }

        return result.ToString();
    }
}
