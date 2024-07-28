using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using FluentAssertions;
using Raiqub.Generators.EnumUtilities.Formatters;

namespace Raiqub.Generators.EnumUtilities.Tests.Formatters;

[SuppressMessage("Design", "CA1000:Do not declare static members on generic types")]
public class EnumNumericFormatterTest
{
    public static class SignedRange<T> where T : IMinMaxValue<T>, IBinaryInteger<T>, ISignedNumber<T>
    {
        public static IEnumerable<T> GetRange() =>
            Enumerable.Range(0, Math.Max(T.MinValue.ToString()!.Length, T.MaxValue.ToString()!.Length)-1)
                .Select(x => T.Parse("1" + new string('0', x), CultureInfo.InvariantCulture))
                .SelectMany<T, T>(x => [x, x >> 1, T.CopySign(x, T.NegativeOne), T.CopySign(x >> 1, T.NegativeOne)])
                .Concat([T.Zero, T.MinValue, T.MaxValue])
                .Distinct();
    }

    public static class UnsignedRange<T> where T : IMinMaxValue<T>, IBinaryInteger<T>
    {
        public static IEnumerable<T> GetRange() =>
            Enumerable.Range(0, Math.Max(T.MinValue.ToString()!.Length, T.MaxValue.ToString()!.Length))
                .Select(x => T.Parse("1" + new string('0', x), CultureInfo.InvariantCulture))
                .SelectMany<T, T>(x => [x, x >> 1])
                .Concat([T.Zero, T.MinValue, T.MaxValue])
                .Distinct();
    }

    [Theory]
    [CombinatorialData]
    public void GetStringLengthSByte(
        [CombinatorialMemberData(nameof(SignedRange<int>.GetRange), MemberType = typeof(SignedRange<sbyte>))]
        sbyte value)
    {
        EnumNumericFormatter.GetStringLength(value)
            .Should().Be(value.ToString(CultureInfo.InvariantCulture).Length);
    }

    [Theory]
    [CombinatorialData]
    public void GetStringLengthByte(
        [CombinatorialMemberData(nameof(UnsignedRange<int>.GetRange), MemberType = typeof(UnsignedRange<byte>))]
        byte value)
    {
        EnumNumericFormatter.GetStringLength(value)
            .Should().Be(value.ToString(CultureInfo.InvariantCulture).Length);
    }

    [Theory]
    [CombinatorialData]
    public void GetStringLengthInt16(
        [CombinatorialMemberData(nameof(SignedRange<int>.GetRange), MemberType = typeof(SignedRange<short>))]
        short value)
    {
        EnumNumericFormatter.GetStringLength(value)
            .Should().Be(value.ToString(CultureInfo.InvariantCulture).Length);
    }

    [Theory]
    [CombinatorialData]
    public void GetStringLengthUInt16(
        [CombinatorialMemberData(nameof(UnsignedRange<int>.GetRange), MemberType = typeof(UnsignedRange<ushort>))]
        ushort value)
    {
        EnumNumericFormatter.GetStringLength(value)
            .Should().Be(value.ToString(CultureInfo.InvariantCulture).Length);
    }

    [Theory]
    [CombinatorialData]
    public void GetStringLengthInt32(
        [CombinatorialMemberData(nameof(SignedRange<int>.GetRange), MemberType = typeof(SignedRange<int>))]
        int value)
    {
        EnumNumericFormatter.GetStringLength(value)
            .Should().Be(value.ToString(CultureInfo.InvariantCulture).Length);
    }

    [Theory]
    [CombinatorialData]
    public void GetStringLengthUInt32(
        [CombinatorialMemberData(nameof(UnsignedRange<int>.GetRange), MemberType = typeof(UnsignedRange<uint>))]
        uint value)
    {
        EnumNumericFormatter.GetStringLength(value)
            .Should().Be(value.ToString(CultureInfo.InvariantCulture).Length);
    }

    [Theory]
    [CombinatorialData]
    public void GetStringLengthInt64(
        [CombinatorialMemberData(nameof(SignedRange<int>.GetRange), MemberType = typeof(SignedRange<long>))]
        long value)
    {
        EnumNumericFormatter.GetStringLength(value)
            .Should().Be(value.ToString(CultureInfo.InvariantCulture).Length);
    }

    [Theory]
    [CombinatorialData]
    public void GetStringLengthUInt64(
        [CombinatorialMemberData(nameof(UnsignedRange<int>.GetRange), MemberType = typeof(UnsignedRange<ulong>))]
        ulong value)
    {
        EnumNumericFormatter.GetStringLength(value)
            .Should().Be(value.ToString(CultureInfo.InvariantCulture).Length);
    }
}
