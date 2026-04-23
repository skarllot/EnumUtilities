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
            WriteFlagFields(writer, model, keySelector, type);
            writer.WriteLine();
            WriteTryFormatFlagLength(writer, model, type);
            writer.WriteLine();
            WriteFormatFlag(writer, model, type);
            writer.WriteLine();
            WriteTryFindFlags(writer, model, keySelector, type);
            writer.WriteLine();
        }

        WriteTryGetLengthInlined(writer, model, keySelector, type);
        writer.WriteLine();
        WriteGetInlined(writer, model, keySelector, type);
    }

    private static void WriteFlagFields(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type
    )
    {
        var bitCount = model.GetMappedBitCount();
        var maxLength = model
            .Values.Where(x => BitOperations.IsPow2(x.RealMemberValue))
            .Max(x => keySelector(x).Length);

        if (maxLength <= byte.MaxValue)
        {
            writer.Write($"private static ReadOnlySpan<byte> s_format{type}Lengths => new byte[{bitCount}] {{ ");
        }
        else
        {
            writer.Write($"private static readonly int[] s_format{type}Lengths = new int[{bitCount}] {{ ");
        }

        for (var i = 0; i < bitCount; i++)
        {
            if (i > 0)
                writer.Write(", ");
            var found = model.Values.FirstOrDefault(x => x.RealMemberValue == 1u << i);
            writer.Write(found is not null ? keySelector(found).Length : 0);
        }

        writer.WriteLine(" };");

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

    private static void WriteTryFormatFlagLength(SourceTextWriter writer, EnumToGenerate model, string type)
    {
        writer.WriteLine(
            $$"""
            private static bool TryFormatFlag{{type}}sLength({{model.UnderlyingType}} value, out int length)
            {
                if (TryGet{{type}}LengthInlined(value, out length))
                {
                    return true;
                }
            """
        );
        writer.PushIndent();

        writer.WriteLine();
        var popCountType = model.BitCount > 32 ? "ulong" : "uint";
        writer.WriteLine(
            $$"""
            int nameCharCount = 0;
            uint remaining = (uint)value;

            while (remaining != 0)
            {
                int bitPos = global::System.Numerics.BitOperations.TrailingZeroCount(remaining);

                if ((uint)bitPos >= (uint)s_format{{type}}Lengths.Length || s_format{{type}}Lengths[bitPos] == 0)
                {
                    return false;
                }

                nameCharCount += s_format{{type}}Lengths[bitPos];
                remaining &= remaining - 1;
            }

            const int separatorStringLength = 2;
            int flagCount = global::System.Numerics.BitOperations.PopCount(({{popCountType}})value);
            length = nameCharCount + (separatorStringLength * (flagCount - 1));
            return true;
            """
        );

        writer.PopIndent();
        writer.WriteLine('}');
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

    private static void WriteTryGetLengthInlined(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type
    )
    {
        writer.WriteLine(
            $$"""
            private static bool TryGet{{type}}LengthInlined({{model.UnderlyingType}} value, out int length)
            {
            """
        );
        writer.PushIndent();

        if (model.IsFlags)
        {
            var zeroLength = model.HasZeroMember ? keySelector(model.ZeroMember).Length : 1;
            writer.WriteLine($"if (value == 0) {{ length = {zeroLength}; return true; }}");
            writer.WriteLine();

            writer.WriteLine(
                $$"""
                if ((value & (value - 1)) == 0)
                {
                    int bitPos = global::System.Numerics.BitOperations.TrailingZeroCount(value);
                    if ((uint)bitPos < (uint)s_format{{type}}Lengths.Length)
                    {
                        length = s_format{{type}}Lengths[bitPos];
                        return length != 0;
                    }
                    else
                    {
                        length = 0;
                        return false;
                    }
                }
                """
            );
            writer.WriteLine();
        }

        writer.WriteLine(
            """
            switch (value)
            {
            """
        );
        writer.PushIndent();

        if (model is { IsFlags: false, HasZeroMember: false })
        {
            writer.WriteLine("case 0: length = 1; return true;");
        }

        var uniqueValues = model.IsFlags
            ? model.UniqueValues.Where(x => x.RealMemberValue != 0 && !BitOperations.IsPow2(x.RealMemberValue))
            : model.UniqueValues;
        foreach (var curr in uniqueValues)
        {
            writer.WriteLine($"case {curr.MemberValue}: length = {keySelector(curr).Length}; return true;");
        }

        writer.WriteLine("default: length = 0; return false;");

        writer.PopIndent(levels: 2);
        writer.WriteLine(
            """
                }
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
