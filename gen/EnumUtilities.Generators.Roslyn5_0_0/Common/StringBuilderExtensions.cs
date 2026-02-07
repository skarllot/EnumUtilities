using System.Runtime.CompilerServices;
using System.Text;

namespace Raiqub.Generators.EnumUtilities.Common;

internal static class StringBuilderExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AppendInterpolated(
        this StringBuilder target,
        [InterpolatedStringHandlerArgument("target")] ref AppendInterpolatedStringHandler handler
    )
    {
        Polyfill.Append(target, ref handler);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AppendUnixLine(this StringBuilder target, char value)
    {
        target.Append(value);
        target.Append('\n');
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AppendUnixLine(this StringBuilder target, string value)
    {
        target.Append(value);
        target.Append('\n');
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AppendUnixLine(
        this StringBuilder target,
        [InterpolatedStringHandlerArgument("target")] ref AppendInterpolatedStringHandler handler
    )
    {
        Polyfill.Append(target, ref handler);
        target.Append('\n');
    }
}
