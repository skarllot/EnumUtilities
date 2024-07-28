using Raiqub.Generators.EnumUtilities.Common;

namespace Raiqub.Generators.EnumUtilities.Generators.Tests.Common;

public class BitOperationsTest
{
    [Theory]
    [InlineData(0u, 32)]
    [InlineData(0b1u, 31)]
    [InlineData(0b10u, 30)]
    [InlineData(0b100u, 29)]
    [InlineData(0b1000u, 28)]
    [InlineData(0b10000u, 27)]
    [InlineData(0b100000u, 26)]
    [InlineData(0b1000000u, 25)]
    [InlineData(byte.MaxValue << 17, 32 - 8 - 17)]
    [InlineData(byte.MaxValue << 9, 32 - 8 - 9)]
    [InlineData(ushort.MaxValue << 11, 32 - 16 - 11)]
    [InlineData(ushort.MaxValue << 2, 32 - 16 - 2)]
    [InlineData(5 << 7, 32 - 3 - 7)]
    [InlineData(uint.MaxValue, 0)]
    public static void BitOpsLeadingZeroCountUInt32(uint n, int expected)
    {
        int actual = BitOperations.LeadingZeroCount(n);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0ul, 64)]
    [InlineData(0b1ul, 63)]
    [InlineData(0b10ul, 62)]
    [InlineData(0b100ul, 61)]
    [InlineData(0b1000ul, 60)]
    [InlineData(0b10000ul, 59)]
    [InlineData(0b100000ul, 58)]
    [InlineData(0b1000000ul, 57)]
    [InlineData((ulong)byte.MaxValue << 41, 64 - 8 - 41)]
    [InlineData((ulong)byte.MaxValue << 53, 64 - 8 - 53)]
    [InlineData((ulong)ushort.MaxValue << 31, 64 - 16 - 31)]
    [InlineData((ulong)ushort.MaxValue << 15, 64 - 16 - 15)]
    [InlineData(ulong.MaxValue >> 5, 5)]
    [InlineData(1ul << 63, 0)]
    [InlineData(1ul << 62, 1)]
    [InlineData(ulong.MaxValue, 0)]
    public static void BitOpsLeadingZeroCountUInt64(ulong n, int expected)
    {
        int actual = BitOperations.LeadingZeroCount(n);
        Assert.Equal(expected, actual);
    }
}
