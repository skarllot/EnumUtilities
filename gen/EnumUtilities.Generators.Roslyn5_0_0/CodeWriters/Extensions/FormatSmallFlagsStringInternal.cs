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

        WriteFlagFields(writer, model, keySelector, type, lengthTableIsRva);
        writer.WriteLine();
        WriteTryFormatFlagLength(writer, model, type);
        writer.WriteLine();
        WriteFormatFlag(writer, model, type);
        writer.WriteLine();
        WriteTryFindFlags(writer, model, keySelector, type);
        writer.WriteLine();
        WriteGetInlined(writer, model, keySelector, type);
    }

    private static void WriteFlagFields(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type,
        bool lengthTableIsRva
    )
    {
        WriteFlagFieldsLengths(writer, model, keySelector, type, lengthTableIsRva);

        writer.WriteLine();

        writer.Write(
            $"private static readonly string[] s_format{type}s = new string[{model.InvertedValues.Count}] {{ "
        );
        foreach (var (index, curr) in model.InvertedValues.Index())
        {
            if (index > 0)
                writer.Write(", ");
            writer.Write(keySelector(curr).ToQuotedStringLiteral());
        }

        writer.WriteLine(" };");
    }

    private static void WriteFlagFieldsLengths(
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

    private static void WriteTryFormatFlagLength(SourceTextWriter writer, EnumToGenerate model, string type)
    {
        var bitCount = model.GetMappedBitCount();
        var tableLength = (uint)Math.Pow(2, bitCount);
        writer.WriteLine(
            $$"""
            private static bool TryFormatFlag{{type}}sLength({{model.UnderlyingType}} value, out int length)
            {
                if (value < {{tableLength}})
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
        writer.WriteLine(
            $$"""
            private static string? FormatFlag{{type}}s({{model.UnderlyingType}} value)
            {
                string? result = Get{{type}}Inlined(value);
                if (result is null)
                {
                    Span<int> foundItems = stackalloc int[{{model.GetMappedBitCount()}}];
                    if (TryFindFlags{{type}}s(value, foundItems, out int foundItemsCount, out int resultLength))
                    {
                        result = EnumStringFormatter.WriteMultipleFoundFlagsNames(s_format{{type}}s, foundItems.Slice(0, foundItemsCount), resultLength);
                    }
                }

                return result;
            }
            """
        );
    }

    private static void WriteTryFindFlags(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type
    )
    {
        var valuesRanges = model.GetEnumValueRangesByBitRange();
        writer.WriteLine(
            $$"""
            private static bool TryFindFlags{{type}}s({{model.UnderlyingType}} value, Span<int> foundItems, out int foundItemsCount, out int resultLength)
            {
                resultLength = 0;
                foundItemsCount = 0;
            """
        );
        writer.PushIndent();

        foreach (var (i, vRange) in valuesRanges.Index())
        {
            if (vRange.Count == 0)
                continue;

            writer.WriteLine(
                $$"""
                if ({{EnumToGenerate.BitRangeConditionStrings[i]}})
                {
                """
            );

            writer.PushIndent();
            foreach (var curr in vRange)
            {
                writer.WriteLine(
                    $$"""
                    if ((value & {{curr.MemberValue}}) == {{curr.MemberValue}})
                    {
                        value -= {{curr.MemberValue}};
                        resultLength = checked(resultLength + {{keySelector(curr).Length}});
                        foundItems[foundItemsCount++] = {{model.InvertedValues.IndexOf(curr)}};
                        if (value == 0) return true;
                    }
                    """
                );
            }

            writer.PopIndent();
            writer.WriteLine('}');
        }

        writer.WriteLine();
        writer.WriteLine("return value == 0;");
        writer.PopIndent();
        writer.WriteLine('}');
    }

    private static void WriteGetInlined(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type
    )
    {
        writer.WriteLine(
            $$"""
            private static string? Get{{type}}Inlined({{model.UnderlyingType}} value)
            {
                return value switch
                {
            """
        );

        writer.PushIndent(levels: 2);
        if (!model.HasZeroMember)
        {
            writer.WriteLine("""0 => "0",""");
        }

        foreach (var curr in model.UniqueValues)
        {
            writer.WriteLine($"{curr.MemberValue} => {keySelector(curr).ToQuotedStringLiteral()},");
        }

        writer.WriteLine("_ => null");

        writer.PopIndent(levels: 2);
        writer.WriteLine(
            """
                };
            }
            """
        );
    }
}
