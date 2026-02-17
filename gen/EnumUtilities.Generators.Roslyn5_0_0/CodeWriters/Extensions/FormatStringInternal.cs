using Raiqub.Generators.EnumUtilities.Common;
using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Extensions;

public static class FormatStringInternal
{
    public static void Write(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type
    )
    {
        if (model.IsFlags)
        {
            WriteFormatFlagLength(writer, model, keySelector, type);
            writer.WriteLine();
            WriteFormatFlag(writer, model, keySelector, type);
            writer.WriteLine();
            WriteTryFindFlags(writer, model, keySelector, type);
            writer.WriteLine();
        }

        WriteGetLengthInlined(writer, model, keySelector, type);
        writer.WriteLine();
        WriteGetInlined(writer, model, keySelector, type);
    }

    private static void WriteFormatFlagLength(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type
    )
    {
        var valuesRanges = model.GetEnumValueRangesByBitRange();
        writer.WriteLine(
            $$"""
            private static int? FormatFlag{{type}}sLength({{model.UnderlyingType}} value)
            {
                int? fastResult = Get{{type}}LengthInlined(value);
                if (fastResult is not null)
                {
                    return fastResult.Value;
                }
            """
        );
        writer.PushIndent();

        if (model.Values.All(x => keySelector(x) != "0"))
        {
            writer.WriteLine();
            writer.WriteLine(
                """
                if (value == 0)
                {
                    return 1;
                }
                """
            );
        }

        writer.WriteLine();
        writer.WriteLine("int count = 0, foundItemsCount = 0;");
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
                        count = checked(count + {{keySelector(curr).Length}});
                        foundItemsCount++;
                        if (value == 0) goto CountLength;
                    }
                    """
                );
            }

            writer.PopIndent();

            writer.WriteLine('}');
        }

        writer.WriteLine();
        writer.WriteLine(
            """
            if (value != 0)
            {
                return null;
            }
            """
        );

        writer.PopIndent();
        writer.WriteLine();
        writer.WriteLine(
            """
            CountLength:
                const int separatorStringLength = 2;
                return checked(count + (separatorStringLength * (foundItemsCount - 1)));
            }
            """
        );
    }

    private static void WriteFormatFlag(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type
    )
    {
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

        writer.WriteLine();
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

    private static void WriteGetLengthInlined(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type
    )
    {
        writer.WriteLine(
            $$"""
            private static int? Get{{type}}LengthInlined({{model.UnderlyingType}} value)
            {
                return value switch
                {
            """
        );

        writer.PushIndent(levels: 2);
        if (!model.HasZeroMember)
        {
            writer.WriteLine("0 => 1,");
        }

        foreach (var curr in model.UniqueValues)
        {
            writer.WriteLine($"{curr.MemberValue} => {keySelector(curr).Length},");
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
