using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.CompilerServices;

public static class Math2
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Clamp(uint value, uint min, uint max)
    {
        if (min > max)
        {
            ThrowMinMaxException(min, max);
        }

        if (value < min)
        {
            return min;
        }
        else if (value > max)
        {
            return max;
        }

        return value;
    }

    [DoesNotReturn]
    private static void ThrowMinMaxException<T>(T min, T max)
    {
        throw new ArgumentException(string.Format(SR.Argument_MinMaxValue, min, max));
    }
}
