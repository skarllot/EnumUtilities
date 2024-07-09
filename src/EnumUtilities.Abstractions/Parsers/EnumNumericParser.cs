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
#if !NETSTANDARD2_0
        return byte.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
#else
        return byte.TryParse(value.ToString(), EnumNumberStyle, s_numberFormat, out result);
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out sbyte result)
    {
#if !NETSTANDARD2_0
        return sbyte.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
#else
        return sbyte.TryParse(value.ToString(), EnumNumberStyle, s_numberFormat, out result);
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out short result)
    {
#if !NETSTANDARD2_0
        return short.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
#else
        return short.TryParse(value.ToString(), EnumNumberStyle, s_numberFormat, out result);
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out ushort result)
    {
#if !NETSTANDARD2_0
        return ushort.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
#else
        return ushort.TryParse(value.ToString(), EnumNumberStyle, s_numberFormat, out result);
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out int result)
    {
#if !NETSTANDARD2_0
        return int.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
#else
        return int.TryParse(value.ToString(), EnumNumberStyle, s_numberFormat, out result);
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out uint result)
    {
#if !NETSTANDARD2_0
        return uint.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
#else
        return uint.TryParse(value.ToString(), EnumNumberStyle, s_numberFormat, out result);
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out long result)
    {
#if !NETSTANDARD2_0
        return long.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
#else
        return long.TryParse(value.ToString(), EnumNumberStyle, s_numberFormat, out result);
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> value, out ulong result)
    {
#if !NETSTANDARD2_0
        return ulong.TryParse(value, EnumNumberStyle, s_numberFormat, out result);
#else
        return ulong.TryParse(value.ToString(), EnumNumberStyle, s_numberFormat, out result);
#endif
    }
}
