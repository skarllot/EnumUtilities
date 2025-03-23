#if NET8_0_OR_GREATER

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using FluentAssertions;
using Raiqub.Generators.EnumUtilities.Parsers;

namespace Raiqub.Generators.EnumUtilities.Tests.Parsers;

[SuppressMessage("Design", "CA1000:Do not declare static members on generic types")]
public class EnumNumericParserTest
{
    public static class SignedRange<T> where T : IMinMaxValue<T>, IBinaryInteger<T>, ISignedNumber<T>
    {
        public static IEnumerable<string> GetRange() =>
            Enumerable.Range(0, T.AllBitsSet.GetByteCount() * 8)
                .Select(x => T.One << x)
                .SelectMany<T, T>(x => [x, T.CopySign(x, T.NegativeOne)])
                .Concat([T.Zero, T.MinValue, T.MaxValue])
                .Distinct()
                .Select(x => x.ToString("D", CultureInfo.InvariantCulture));
    }

    public static class UnsignedRange<T> where T : IMinMaxValue<T>, IBinaryInteger<T>
    {
        public static IEnumerable<string> GetRange() =>
            Enumerable.Range(0, T.AllBitsSet.GetByteCount() * 8)
                .Select(x => T.One << x)
                .Concat([T.Zero, T.MinValue, T.MaxValue])
                .Distinct()
                .Select(x => x.ToString("D", CultureInfo.InvariantCulture));
    }

    [Theory]
    [CombinatorialData]
    public void TryParseSByte(
        [CombinatorialMemberData(nameof(SignedRange<int>.GetRange), MemberType = typeof(SignedRange<sbyte>))]
        string value)
    {
        bool success = EnumNumericParser.TryParse(value, out sbyte result);
        success.Should().BeTrue();
        result.Should().Be(sbyte.Parse(value, CultureInfo.InvariantCulture));
    }

    [Theory]
    [CombinatorialData]
    public void TryParseByte(
        [CombinatorialMemberData(nameof(UnsignedRange<int>.GetRange), MemberType = typeof(UnsignedRange<byte>))]
        string value)
    {
        bool success = EnumNumericParser.TryParse(value, out byte result);
        success.Should().BeTrue();
        result.Should().Be(byte.Parse(value, CultureInfo.InvariantCulture));
    }

    [Theory]
    [CombinatorialData]
    public void TryParseInt16(
        [CombinatorialMemberData(nameof(SignedRange<int>.GetRange), MemberType = typeof(SignedRange<short>))]
        string value)
    {
        bool success = EnumNumericParser.TryParse(value, out short result);
        success.Should().BeTrue();
        result.Should().Be(short.Parse(value, CultureInfo.InvariantCulture));
    }

    [Theory]
    [CombinatorialData]
    public void TryParseUInt16(
        [CombinatorialMemberData(nameof(UnsignedRange<int>.GetRange), MemberType = typeof(UnsignedRange<ushort>))]
        string value)
    {
        bool success = EnumNumericParser.TryParse(value, out ushort result);
        success.Should().BeTrue();
        result.Should().Be(ushort.Parse(value, CultureInfo.InvariantCulture));
    }

    [Theory]
    [CombinatorialData]
    public void TryParseInt32(
        [CombinatorialMemberData(nameof(SignedRange<int>.GetRange), MemberType = typeof(SignedRange<int>))]
        string value)
    {
        bool success = EnumNumericParser.TryParse(value, out int result);
        success.Should().BeTrue();
        result.Should().Be(int.Parse(value, CultureInfo.InvariantCulture));
    }

    [Theory]
    [CombinatorialData]
    public void TryParseUInt32(
        [CombinatorialMemberData(nameof(UnsignedRange<int>.GetRange), MemberType = typeof(UnsignedRange<uint>))]
        string value)
    {
        bool success = EnumNumericParser.TryParse(value, out uint result);
        success.Should().BeTrue();
        result.Should().Be(uint.Parse(value, CultureInfo.InvariantCulture));
    }

    [Theory]
    [CombinatorialData]
    public void TryParseInt64(
        [CombinatorialMemberData(nameof(SignedRange<int>.GetRange), MemberType = typeof(SignedRange<long>))]
        string value)
    {
        bool success = EnumNumericParser.TryParse(value, out long result);
        success.Should().BeTrue();
        result.Should().Be(long.Parse(value, CultureInfo.InvariantCulture));
    }

    [Theory]
    [CombinatorialData]
    public void TryParseUInt64(
        [CombinatorialMemberData(nameof(UnsignedRange<int>.GetRange), MemberType = typeof(UnsignedRange<ulong>))]
        string value)
    {
        bool success = EnumNumericParser.TryParse(value, out ulong result);
        success.Should().BeTrue();
        result.Should().Be(ulong.Parse(value, CultureInfo.InvariantCulture));
    }
}

#endif
