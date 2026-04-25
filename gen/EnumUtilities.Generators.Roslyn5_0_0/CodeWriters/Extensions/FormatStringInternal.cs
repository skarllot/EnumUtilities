using Raiqub.Generators.EnumUtilities.Common;
using Raiqub.Generators.EnumUtilities.Formatters;
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
            WriteFlagFields(writer, model, keySelector, type, out var lengthTableIsRva);
            writer.WriteLine();
            WriteTryFormatFlagLength(writer, model, keySelector, type, lengthTableIsRva);
            writer.WriteLine();
            WriteFormatFlag(writer, model, type);
            writer.WriteLine();
            WriteTryFindFlags(writer, model, keySelector, type);
        }
        else
        {
            WriteTryGetLengthInlined(writer, model, keySelector, type);
        }

        writer.WriteLine();
        WriteGetInlined(writer, model, keySelector, type);
    }

    private static void WriteFlagFields(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type,
        out bool lengthTableIsRva
    )
    {
        var bitCount = model.GetMappedBitCount();
        var maxLength = model.FlagsInfo!.BitValues.Max(x => keySelector(x).Length);
        lengthTableIsRva = maxLength <= byte.MaxValue;
        var tableLength =
            lengthTableIsRva && model.FlagsInfo.HasFewCombinations ? (uint)Math.Pow(2, bitCount) : (uint)bitCount;

        if (lengthTableIsRva)
        {
            writer.Write($"private static ReadOnlySpan<byte> s_format{type}Lengths => new byte[{tableLength}] {{ ");
        }
        else
        {
            writer.Write($"private static readonly int[] s_format{type}Lengths = new int[{bitCount}] {{ ");
        }

        if (lengthTableIsRva && model.FlagsInfo.HasFewCombinations)
        {
            var zeroLength = model.HasZeroMember ? keySelector(model.ZeroMember).Length : 1;
            writer.Write(zeroLength);
            for (var i = 1u; i < tableLength; i++)
            {
                writer.Write(", ");
                var len = model
                    .FlagsInfo.GetMatchingValues(i)
                    .Aggregate(
                        0,
                        (agg, value) => agg == 0 ? keySelector(value).Length : agg + keySelector(value).Length + 2
                    );
                writer.Write(len > 0 ? len : EnumNumericFormatter.GetStringLength(i));
            }
        }
        else
        {
            for (var i = 0; i < bitCount; i++)
            {
                if (i > 0)
                    writer.Write(", ");
                var found = model.Values.FirstOrDefault(x => x.RealMemberValue == 1u << i);
                writer.Write(found is not null ? keySelector(found).Length : 0);
            }
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

    private static void WriteTryFormatFlagLength(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type,
        bool lengthTableIsRva
    )
    {
        writer.WriteLine(
            $$"""
            private static bool TryFormatFlag{{type}}sLength({{model.UnderlyingType}} value, out int length)
            {
            """
        );
        writer.PushIndent();

        if (lengthTableIsRva && model.FlagsInfo!.HasFewCombinations)
        {
            var bitCount = model.GetMappedBitCount();
            var tableLength = (uint)Math.Pow(2, bitCount);
            writer.WriteLine(
                $$"""
                if (value < {{tableLength}})
                {
                    length = global::System.Runtime.CompilerServices.Unsafe.Add(
                        ref global::System.Runtime.InteropServices.MemoryMarshal.GetReference(s_format{{type}}Lengths),
                        (int)value);
                    return true;
                }

                length = 0;
                return false;
                """
            );

            writer.PopIndent();
            writer.WriteLine('}');
            return;
        }

        var zeroLength = model.HasZeroMember ? keySelector(model.ZeroMember).Length : 1;
        var unSigType = model.BitCount > 32 ? "ulong" : "uint";
        var tableType = lengthTableIsRva ? "byte" : "int";
        var compositeValues = model.FlagsInfo!.CompositeValues;

        writer.WriteLine($"if (value == 0) {{ length = {zeroLength}; return true; }}");

        if (!model.FlagsInfo.IsAllBitsDefined)
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

        if (compositeValues.Count > 0)
        {
            writer.WriteLine();
            writer.WriteLine(
                """
                switch (value)
                {
                """
            );
            writer.PushIndent();

            foreach (var curr in compositeValues)
            {
                writer.WriteLine($"case {curr.MemberValue}: length = {keySelector(curr).Length}; return true;");
            }

            writer.PopIndent();
            writer.WriteLine('}');
        }

        writer.WriteLine();
        writer.WriteLine(
            $$"""
            int charCount = -2;
            {{unSigType}} remaining = ({{unSigType}})value;

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

        writer.WriteLine(
            """
            switch (value)
            {
            """
        );
        writer.PushIndent();

        if (!model.HasZeroMember)
        {
            writer.WriteLine("case 0: length = 1; return true;");
        }

        foreach (var curr in model.UniqueValues)
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
