using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Raiqub.Generators.EnumUtilities.Parsers;

/// <summary>Parser for enumerations represented as a numeric text.</summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public static class EnumNumericParser
{
    private const NumberStyles EnumNumberStyle = NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingWhite;
    private static readonly NumberFormatInfo s_numberFormat = CultureInfo.InvariantCulture.NumberFormat;

    /// <summary>Tries to parse the specified value as a byte.</summary>
    /// <param name="value">The span containing the characters to parse.</param>
    /// <param name="result">When this method returns, contains the parsed value if successful; otherwise, the default value.</param>
    /// <returns><see langword="true"/> if the value was successfully parsed; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out byte result)
    {
        return byte.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
    }

    /// <summary>Tries to parse the specified value as a signed byte.</summary>
    /// <param name="value">The span containing the characters to parse.</param>
    /// <param name="result">When this method returns, contains the parsed value if successful; otherwise, the default value.</param>
    /// <returns><see langword="true"/> if the value was successfully parsed; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out sbyte result)
    {
        return sbyte.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
    }

    /// <summary>Tries to parse the specified value as a 16-bit signed integer.</summary>
    /// <param name="value">The span containing the characters to parse.</param>
    /// <param name="result">When this method returns, contains the parsed value if successful; otherwise, the default value.</param>
    /// <returns><see langword="true"/> if the value was successfully parsed; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out short result)
    {
        return short.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
    }

    /// <summary>Tries to parse the specified value as a 16-bit unsigned integer.</summary>
    /// <param name="value">The span containing the characters to parse.</param>
    /// <param name="result">When this method returns, contains the parsed value if successful; otherwise, the default value.</param>
    /// <returns><see langword="true"/> if the value was successfully parsed; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out ushort result)
    {
        return ushort.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
    }

    /// <summary>Tries to parse the specified value as a 32-bit signed integer.</summary>
    /// <param name="value">The span containing the characters to parse.</param>
    /// <param name="result">When this method returns, contains the parsed value if successful; otherwise, the default value.</param>
    /// <returns><see langword="true"/> if the value was successfully parsed; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out int result)
    {
        return int.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
    }

    /// <summary>Tries to parse the specified value as a 32-bit unsigned integer.</summary>
    /// <param name="value">The span containing the characters to parse.</param>
    /// <param name="result">When this method returns, contains the parsed value if successful; otherwise, the default value.</param>
    /// <returns><see langword="true"/> if the value was successfully parsed; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out uint result)
    {
        return uint.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
    }

    /// <summary>Tries to parse the specified value as a 64-bit signed integer.</summary>
    /// <param name="value">The span containing the characters to parse.</param>
    /// <param name="result">When this method returns, contains the parsed value if successful; otherwise, the default value.</param>
    /// <returns><see langword="true"/> if the value was successfully parsed; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out long result)
    {
        return long.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
    }

    /// <summary>Tries to parse the specified value as a 64-bit unsigned integer.</summary>
    /// <param name="value">The span containing the characters to parse.</param>
    /// <param name="result">When this method returns, contains the parsed value if successful; otherwise, the default value.</param>
    /// <returns><see langword="true"/> if the value was successfully parsed; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out ulong result)
    {
        return ulong.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
    }
}
