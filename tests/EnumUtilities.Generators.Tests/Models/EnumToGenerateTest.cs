using Raiqub.Generators.EnumUtilities.Generators.Tests.Common;
using Raiqub.Generators.EnumUtilities.Models;

namespace Raiqub.Generators.EnumUtilities.Generators.Tests.Models;

public class EnumToGenerateTest
{
    [Fact]
    public void IsFlags_WithFlagsAttribute_ShouldBeTrue()
    {
        const string source = """
            using System;
            using Raiqub.Generators.EnumUtilities;

            [Flags]
            [EnumGenerator]
            public enum Permissions
            {
                Read = 1,
                Write = 2,
                Execute = 4
            }
            """;

        var symbol = CompilationSymbolFactory.GetEnumSymbol(source);
        var result = EnumToGenerate.FromSymbol(symbol);

        Assert.NotNull(result);
        Assert.True(result.IsFlags);
    }

    [Fact]
    public void OrderedValues_WithSignedEnum_ShouldOrderBySignedValue()
    {
        const string source = """
            using Raiqub.Generators.EnumUtilities;

            [EnumGenerator]
            public enum Temperature : int
            {
                FreezingCold = -20,
                Cold = -5,
                Cool = 10,
                Warm = 25,
                Hot = 40
            }
            """;

        var symbol = CompilationSymbolFactory.GetEnumSymbol(source);
        var result = EnumToGenerate.FromSymbol(symbol);

        Assert.NotNull(result);
        Assert.False(result.IsUnsigned);

        var orderedValues = result.OrderedValues.ToList();

        Assert.Equal(5, orderedValues.Count);
        Assert.Equal("FreezingCold", orderedValues[0].MemberName);
        Assert.Equal("Cold", orderedValues[1].MemberName);
        Assert.Equal("Cool", orderedValues[2].MemberName);
        Assert.Equal("Warm", orderedValues[3].MemberName);
        Assert.Equal("Hot", orderedValues[4].MemberName);

        // Verify signed values are in ascending order
        Assert.Equal(-20, orderedValues[0].RealMemberSignedValue);
        Assert.Equal(-5, orderedValues[1].RealMemberSignedValue);
        Assert.Equal(10, orderedValues[2].RealMemberSignedValue);
        Assert.Equal(25, orderedValues[3].RealMemberSignedValue);
        Assert.Equal(40, orderedValues[4].RealMemberSignedValue);
    }

    [Fact]
    public void OrderedValues_WithUnsignedEnum_ShouldOrderByUnsignedValue()
    {
        const string source = """
            using Raiqub.Generators.EnumUtilities;

            [EnumGenerator]
            public enum Priority : uint
            {
                Low = 100,
                Medium = 500,
                High = 1000,
                Critical = 5000,
                Emergency = uint.MaxValue
            }
            """;

        var symbol = CompilationSymbolFactory.GetEnumSymbol(source);
        var result = EnumToGenerate.FromSymbol(symbol);

        Assert.NotNull(result);
        Assert.True(result.IsUnsigned);

        var orderedValues = result.OrderedValues.ToList();

        Assert.Equal(5, orderedValues.Count);
        Assert.Equal("Low", orderedValues[0].MemberName);
        Assert.Equal("Medium", orderedValues[1].MemberName);
        Assert.Equal("High", orderedValues[2].MemberName);
        Assert.Equal("Critical", orderedValues[3].MemberName);
        Assert.Equal("Emergency", orderedValues[4].MemberName);

        // Verify unsigned values are in ascending order
        Assert.Equal(100UL, orderedValues[0].RealMemberValue);
        Assert.Equal(500UL, orderedValues[1].RealMemberValue);
        Assert.Equal(1000UL, orderedValues[2].RealMemberValue);
        Assert.Equal(5000UL, orderedValues[3].RealMemberValue);
        Assert.Equal(uint.MaxValue, orderedValues[4].RealMemberValue);
    }
}
