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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out byte result)
    {
        return byte.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out sbyte result)
    {
        return sbyte.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out short result)
    {
        return short.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out ushort result)
    {
        return ushort.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out int result)
    {
        return int.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out uint result)
    {
        return uint.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out long result)
    {
        return long.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out ulong result)
    {
        return ulong.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
    }
}
