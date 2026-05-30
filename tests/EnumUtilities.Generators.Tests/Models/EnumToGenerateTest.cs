using Raiqub.Generators.EnumUtilities.Generators.Tests.Common;
using Raiqub.Generators.EnumUtilities.Models;

namespace Raiqub.Generators.EnumUtilities.Generators.Tests.Models;

public class EnumToGenerateTest
{
    [Fact]
    public async Task IsFlags_WithFlagsAttribute_ShouldBeTrue()
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

        var symbol = await CompilationSymbolFactory.GetEnumSymbol(source);
        var result = EnumToGenerate.FromSymbol(symbol);

        Assert.NotNull(result);
        Assert.True(result.IsFlags);
    }

    [Fact]
    public async Task OrderedValues_WithSignedEnum_ShouldOrderBySignedValue()
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

        var symbol = await CompilationSymbolFactory.GetEnumSymbol(source);
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
        Assert.Equal(-20, orderedValues[0].AsInt64());
        Assert.Equal(-5, orderedValues[1].AsInt64());
        Assert.Equal(10, orderedValues[2].AsInt64());
        Assert.Equal(25, orderedValues[3].AsInt64());
        Assert.Equal(40, orderedValues[4].AsInt64());
    }

    [Fact]
    public async Task OrderedValues_WithUnsignedEnum_ShouldOrderByUnsignedValue()
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

        var symbol = await CompilationSymbolFactory.GetEnumSymbol(source);
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
        Assert.Equal(100UL, orderedValues[0].AsUInt64());
        Assert.Equal(500UL, orderedValues[1].AsUInt64());
        Assert.Equal(1000UL, orderedValues[2].AsUInt64());
        Assert.Equal(5000UL, orderedValues[3].AsUInt64());
        Assert.Equal(uint.MaxValue, orderedValues[4].AsUInt64());
    }
}
