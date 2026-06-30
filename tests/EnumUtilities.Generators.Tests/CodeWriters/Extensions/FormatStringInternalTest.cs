using Raiqub.Generators.EnumUtilities.CodeWriters;
using Raiqub.Generators.EnumUtilities.CodeWriters.Extensions;
using Raiqub.Generators.EnumUtilities.Generators.Tests.Common;
using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.Generators.Tests.CodeWriters.Extensions;

public class FormatStringInternalTest
{
    [Fact]
    public async Task Write_WithPlainEnum_WritesSwitchBasedFormatter()
    {
        const string source = """
            using Raiqub.Generators.EnumUtilities;

            [EnumGenerator]
            public enum Status
            {
                Unknown = 0,
                Active = 1,
                Inactive = 2
            }
            """;

        var output = await WriteFormatString(source, DefaultFormatDefinition);

        Assert.Contains("public static string ToStringFast(this Status value)", output);
        Assert.Contains("int v = (int)value;", output);
        Assert.Contains("0 => \"Unknown\",", output);
        Assert.Contains("1 => \"Active\",", output);
        Assert.Contains("_ => v.ToString()", output);
        Assert.Contains("public static int GetStringLength(this Status value)", output);
        Assert.Contains("2 => 8,", output);
    }

    [Fact]
    public async Task Write_WithSmallFlagsEnum_WritesLookupTableFormatter()
    {
        const string source = """
            using System;
            using Raiqub.Generators.EnumUtilities;

            [Flags]
            [EnumGenerator]
            public enum Colours
            {
                Red = 1,
                Blue = 2,
                Green = 4
            }
            """;

        var output = await WriteFormatString(source, DefaultFormatDefinition);

        Assert.Contains("private static ReadOnlySpan<byte> s_formatDefaultLengths => new byte[8]", output);
        Assert.Contains("private static readonly string[] s_formatDefaults = new string[8]", output);
        Assert.Contains("\"Red, Blue, Green\"", output);
        Assert.Contains("if ((uint)value < 8)", output);
        Assert.Contains("return ((int)value).ToString();", output);
    }

    [Fact]
    public async Task Write_WithLookupTableDisabled_WritesMultipleFlagsFormatter()
    {
        const string source = """
            using System;
            using Raiqub.Generators.EnumUtilities;

            [Flags]
            [EnumGenerator(DisableLookupTable = true)]
            public enum UserRole : ulong
            {
                None = 0,
                NormalUser = 1UL << 0,
                Custodian = 1UL << 1,
                Finance = 1UL << 3,
                SuperUser = Custodian | Finance,
                All = Custodian | Finance | NormalUser
            }
            """;

        var output = await WriteFormatString(source, DefaultFormatDefinition);

        Assert.Contains("private static ReadOnlySpan<byte> s_formatDefaultLengths => new byte[6]", output);
        Assert.Contains("private static readonly string?[] s_formatDefaults = new string?[6]", output);
        Assert.Contains("private static readonly ulong[] s_compositeDefaultValues = new ulong[2]", output);
        Assert.Contains("if ((v & ~ValidFlagsMask) != 0) { return v.ToString(); }", output);
        Assert.Contains("private static string FormatDefaultMultipleFlags(ulong value)", output);
        Assert.Contains("private static int GetDefaultStringLengthForMultipleFlags(ulong value)", output);
        Assert.Contains("if ((remaining & c) == c)", output);
    }

    [Fact]
    public async Task Write_WithLargeFlagsEnum_WritesHighBitNameIntoTable()
    {
        const string source = """
            using System;
            using Raiqub.Generators.EnumUtilities;

            [Flags]
            [EnumGenerator(DisableLookupTable = true)]
            public enum LargeFlags : ulong
            {
                Low = 1UL << 0,
                High = 1UL << 40
            }
            """;

        var output = await WriteFormatString(source, DefaultFormatDefinition);

        Assert.Contains("s_formatDefaultLengths => new byte[41]", output);
        Assert.Contains("s_formatDefaults = new string?[41]", output);
        Assert.Contains("\"High\"", output);
    }

    [Fact]
    public async Task Write_WithEnumMemberValues_WritesFormatterWithStringFallback()
    {
        const string source = """
            using System.Runtime.Serialization;
            using Raiqub.Generators.EnumUtilities;

            [EnumGenerator]
            public enum PaymentMethod
            {
                [EnumMember(Value = "Credit card")]
                Credit = 1,
                [EnumMember(Value = "Debit card")]
                Debit = 2,
                Cash = 3
            }
            """;

        var model = await CreateModel(source);
        var block = new ExtensionsEnumMemberBlock();
        var writer = new SourceTextWriter();

        Assert.True(block.CanGenerateFor(model));
        block.Write(writer, model);

        var output = writer.ToString();
        Assert.Contains("public static string ToEnumMemberValue(this PaymentMethod value)", output);
        Assert.Contains("1 => \"Credit card\",", output);
        Assert.Contains("3 => \"Cash\",", output);
        Assert.Contains("_ => v.ToString()", output);
        Assert.Contains("public static int GetEnumMemberValueStringLength(this PaymentMethod value)", output);
    }

    [Fact]
    public async Task EnumExtensionsWriter_WithUnsignedFlags_WritesValidFlagsMaskWithSuffix()
    {
        const string source = """
            using System;
            using Raiqub.Generators.EnumUtilities;

            [Flags]
            [EnumGenerator]
            public enum Permissions : uint
            {
                Read = 1u,
                Write = 2u,
                Execute = 4u
            }
            """;

        var model = await CreateModel(source);
        var writer = new SourceTextWriter();

        new EnumExtensionsWriter().Write(writer, model);

        Assert.Contains("private const uint ValidFlagsMask = 7U;", writer.ToString());
    }

    [Fact]
    public async Task EnumExtensionsWriter_WithSignedNegativeFlags_DoesNotEmitUnsignedValidFlagsMaskLiteral()
    {
        const string source = """
            using System;
            using Raiqub.Generators.EnumUtilities;

            [Flags]
            [EnumGenerator]
            public enum SignedFlags
            {
                All = -1
            }
            """;

        var model = await CreateModel(source);
        var writer = new SourceTextWriter();

        new EnumExtensionsWriter().Write(writer, model);

        Assert.Contains("private const int ValidFlagsMask = -1;", writer.ToString());
        Assert.DoesNotContain("private const int ValidFlagsMask = 18446744073709551615;", writer.ToString());
    }

    private static EnumFormatDefinition DefaultFormatDefinition =>
        new()
        {
            XmlRefType = "Raiqub.Generators.EnumUtilities.Contracts.IEnumExtensions{TEnum}",
            ToStringMethodName = "ToStringFast",
            GetStringLengthMethodName = "GetStringLength",
            Type = "Default",
            KeySelector = static x => x.MemberName,
            AllowNumbers = true,
        };

    private static async Task<string> WriteFormatString(string source, EnumFormatDefinition formatDefinition)
    {
        var model = await CreateModel(source);
        var writer = new SourceTextWriter();

        FormatStringInternal.Write(writer, model, formatDefinition);

        return writer.ToString();
    }

    private static async Task<EnumToGenerate> CreateModel(string source)
    {
        var symbol = await CompilationSymbolFactory.GetEnumSymbol(source);
        return EnumToGenerate.FromSymbol(symbol) ?? throw new InvalidOperationException("Enum model not found");
    }
}
