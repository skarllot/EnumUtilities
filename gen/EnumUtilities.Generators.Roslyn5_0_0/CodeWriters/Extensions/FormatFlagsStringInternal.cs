using Raiqub.Generators.EnumUtilities.Common;
using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

public static class FormatFlagsStringInternal
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
        var compositeIsRva =
            model.FlagsInfo.InvertedCompositeValues.Count == 0
            || model.FlagsInfo.InvertedCompositeValues.Max(x => keySelector(x).Length) <= byte.MaxValue;

        WriteFlagFields(writer, model, keySelector, type, lengthTableIsRva, compositeIsRva);
        writer.WriteLine();
        WriteTryFormatFlagLength(writer, model, keySelector, type, lengthTableIsRva, compositeIsRva);
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
        bool lengthTableIsRva,
        bool compositeIsRva
    )
    {
        WriteFlagLengthsWithDefinedBits(writer, model, keySelector, type, lengthTableIsRva);

        if (model.FlagsInfo!.InvertedCompositeValues.Count > 0)
        {
            writer.WriteLine();
            WriteFlagLengthsForCompositeValues(writer, model, keySelector, type, compositeIsRva);
        }

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

    private static void WriteFlagLengthsWithDefinedBits(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type,
        bool lengthTableIsRva
    )
    {
        var bitCount = model.GetMappedBitCount();

        if (lengthTableIsRva)
        {
            writer.Write($"private static ReadOnlySpan<byte> s_format{type}Lengths => new byte[{bitCount}] {{ ");
        }
        else
        {
            writer.Write($"private static readonly int[] s_format{type}Lengths = new int[{bitCount}] {{ ");
        }

        var bitValues = model.FlagsInfo!.BitValues;
        for (var i = 0; i < bitCount; i++)
        {
            if (i > 0)
                writer.Write(", ");
            var found = bitValues.Find(x => x.RealMemberValue == 1u << i);
            writer.Write(found is not null ? keySelector(found).Length : 0);
        }

        writer.WriteLine(" };");
    }

    private static void WriteFlagLengthsForCompositeValues(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type,
        bool compositeIsRva
    )
    {
        var compositeValuesCount = model.FlagsInfo!.InvertedCompositeValues.Count;
        writer.Write(
            $"private static readonly {model.UnderlyingType}[] s_composite{type}Values = new {model.UnderlyingType}[{compositeValuesCount}] {{ "
        );

        for (var i = 0; i < model.FlagsInfo.InvertedCompositeValues.Count; i++)
        {
            if (i > 0)
                writer.Write(", ");
            writer.Write(model.FlagsInfo.InvertedCompositeValues[i].MemberValue);
        }

        writer.WriteLine(" };");

        if (compositeIsRva)
            writer.Write(
                $"private static ReadOnlySpan<byte> s_composite{type}Lengths => new byte[{compositeValuesCount}] {{ "
            );
        else
            writer.Write(
                $"private static readonly int[] s_composite{type}Lengths = new int[{compositeValuesCount}] {{ "
            );

        for (var i = 0; i < model.FlagsInfo.InvertedCompositeValues.Count; i++)
        {
            if (i > 0)
                writer.Write(", ");
            writer.Write(keySelector(model.FlagsInfo.InvertedCompositeValues[i]).Length);
        }

        writer.WriteLine(" };");
    }

    private static void WriteTryFormatFlagLength(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type,
        bool lengthTableIsRva,
        bool compositeIsRva
    )
    {
        writer.WriteLine(
            $$"""
            private static bool TryFormatFlag{{type}}sLength({{model.UnderlyingType}} value, out int length)
            {
            """
        );
        writer.PushIndent();

        var zeroLength = model.HasZeroMember ? keySelector(model.ZeroMember).Length : 1;
        var unSigType = model.BitCount > 32 ? "ulong" : "uint";
        var tableType = lengthTableIsRva ? "byte" : "int";

        writer.WriteLine($"if (value == 0) {{ length = {zeroLength}; return true; }}");

        if (!model.FlagsInfo!.IsAllBitsDefined)
        {
            writer.WriteLine("if ((value & ~ValidFlagsMask) != 0) { length = 0; return false; }");
        }

        writer.WriteLine();
        writer.WriteLine(
            $$"""
            ref {{tableType}} table = ref global::System.Runtime.InteropServices.MemoryMarshal.GetReference(s_format{{type}}Lengths);

            if ((value & (value - 1)) == 0)
            {
                int bitPos = global::System.Numerics.BitOperations.TrailingZeroCount(value);
                length = global::System.Runtime.CompilerServices.Unsafe.Add(ref table, bitPos);
                return true;
            }
            """
        );

        writer.WriteLine();
        writer.WriteLine(
            $$"""
            int charCount = -2;
            {{unSigType}} remaining = ({{unSigType}})value;
            """
        );

        if (model.FlagsInfo.InvertedCompositeValues.Count > 0)
        {
            var compositeTableType = compositeIsRva ? "byte" : "int";
            writer.WriteLine();
            writer.WriteLine(
                $$"""
                ref {{model.UnderlyingType}} cv = ref global::System.Runtime.InteropServices.MemoryMarshal.GetReference(s_composite{{type}}Values);
                ref {{compositeTableType}} cl = ref global::System.Runtime.InteropServices.MemoryMarshal.GetReference(s_composite{{type}}Lengths);
                int n = s_composite{{type}}Values.Length;
                for (int i = 0; i < n; i++)
                {
                    {{unSigType}} c = ({{unSigType}})global::System.Runtime.CompilerServices.Unsafe.Add(ref cv, i);
                    if ((remaining & c) == c)
                    {
                        charCount += global::System.Runtime.CompilerServices.Unsafe.Add(ref cl, i) + 2;
                        remaining &= ~c;
                        if ((remaining & (remaining - 1)) == 0) break;
                    }
                }

                if (remaining == 0) { length = charCount; return true; }
                """
            );
        }

        writer.WriteLine();
        writer.WriteLine(
            """
            do
            {
                int bitPos = global::System.Numerics.BitOperations.TrailingZeroCount(remaining);
                charCount += global::System.Runtime.CompilerServices.Unsafe.Add(ref table, bitPos) + 2;
                remaining &= remaining - 1;
            } while (remaining != 0);

            length = charCount;
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
