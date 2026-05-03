using System.Text;
using Raiqub.Generators.EnumUtilities.Common;
using Raiqub.Generators.EnumUtilities.Formatters;
using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Extensions;

public static class FormatSmallFlagsStringInternal
{
    public static void Write(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type
    )
    {
        var maxLength = model.FlagsInfo!.BitValues.Max(x => keySelector(x).Length);
        var lengthTableIsRva = maxLength <= byte.MaxValue;

        WriteLengthField(writer, model, keySelector, type, lengthTableIsRva);
        writer.WriteLine();
        WriteNameField(writer, model, keySelector, type);
        writer.WriteLine();
        WriteTryFormatFlagLength(writer, model, type);
        writer.WriteLine();
        WriteFormatFlag(writer, model, type);
    }

    private static void WriteLengthField(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type,
        bool lengthTableIsRva
    )
    {
        var bitCount = model.GetMappedBitCount();
        var tableLength = (uint)Math.Pow(2, bitCount);

        if (lengthTableIsRva)
        {
            writer.Write($"private static ReadOnlySpan<byte> s_format{type}Lengths => new byte[{tableLength}] {{ ");
        }
        else
        {
            writer.Write($"private static readonly int[] s_format{type}Lengths = new int[{tableLength}] {{ ");
        }

        var zeroLength = model.HasZeroMember ? keySelector(model.ZeroMember).Length : 1;
        writer.Write(zeroLength);
        for (var i = 1u; i < tableLength; i++)
        {
            writer.Write(", ");
            var len = model
                .FlagsInfo!.GetMatchingValues(i)
                .Aggregate(
                    0,
                    (agg, value) => agg == 0 ? keySelector(value).Length : agg + keySelector(value).Length + 2
                );
            writer.Write(len > 0 ? len : EnumNumericFormatter.GetStringLength(i));
        }

        writer.WriteLine(" };");
    }

    private static void WriteNameField(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type
    )
    {
        var bitCount = model.GetMappedBitCount();
        var tableLength = (uint)Math.Pow(2, bitCount);

        writer.Write($"private static readonly string[] s_format{type}s = new string[{tableLength}] {{ ");
        writer.Write(model.HasZeroMember ? keySelector(model.ZeroMember).ToQuotedStringLiteral() : "\"0\"");
        for (var i = 1u; i < tableLength; i++)
        {
            writer.Write(", ");
            var sb = model
                .FlagsInfo!.GetMatchingValues(i)
                .Aggregate(
                    new StringBuilder(),
                    (agg, value) =>
                        agg.Length == 0 ? agg.Append(keySelector(value)) : agg.Append(", ").Append(keySelector(value))
                );
            writer.Write(sb.Length > 0 ? sb.ToString().ToQuotedStringLiteral() : $"\"{i}\"");
        }

        writer.WriteLine(" };");
    }

    private static void WriteTryFormatFlagLength(SourceTextWriter writer, EnumToGenerate model, string type)
    {
        var bitCount = model.GetMappedBitCount();
        var tableLength = (uint)Math.Pow(2, bitCount);
        var unSigType = model.BitCount > 32 ? "ulong" : "uint";
        writer.WriteLine(
            $$"""
            private static bool TryFormatFlag{{type}}sLength({{model.UnderlyingType}} value, out int length)
            {
                if (({{unSigType}})value < {{tableLength}})
                {
                    length = global::System.Runtime.CompilerServices.Unsafe.Add(
                        ref global::System.Runtime.InteropServices.MemoryMarshal.GetReference(s_format{{type}}Lengths),
                        (int)value);
                    return true;
                }

                length = 0;
                return false;
            }
            """
        );
    }

    private static void WriteFormatFlag(SourceTextWriter writer, EnumToGenerate model, string type)
    {
        var bitCount = model.GetMappedBitCount();
        var tableLength = (uint)Math.Pow(2, bitCount);
        var unSigType = model.BitCount > 32 ? "ulong" : "uint";
        writer.WriteLine(
            $$"""
            private static string? FormatFlag{{type}}s({{model.UnderlyingType}} value)
            {
                if (({{unSigType}})value < {{tableLength}})
                {
                    return global::System.Runtime.CompilerServices.Unsafe.Add(
                        ref global::System.Runtime.InteropServices.MemoryMarshal.GetReference(s_format{{type}}s),
                        (int)value);
                }

                return null;
            }
            """
        );
    }
}
