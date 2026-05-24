using Raiqub.Generators.EnumUtilities.Common;
using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Extensions;

public static class FormatFlagsStringInternal
{
    public static void Write(SourceTextWriter writer, EnumToGenerate model, EnumFormatDefinition formatDefinition)
    {
        var maxLength = model.UniqueValues.Max(x => formatDefinition.KeySelector(x).Length);
        var lengthTableIsRva = maxLength <= byte.MaxValue;

        WriteFlagFields(writer, model, formatDefinition.KeySelector, formatDefinition.Type, lengthTableIsRva);
        writer.WriteLine();
        WriteToString(writer, model, formatDefinition);
        writer.WriteLine();
        WriteGetStringLength(writer, model, formatDefinition, lengthTableIsRva);
        writer.WriteLine();
        WriteFormatMultipleFlags(writer, model, formatDefinition, lengthTableIsRva);
        writer.WriteLine();
        WriteGetStringLengthForMultipleFlags(writer, model, formatDefinition, lengthTableIsRva);
    }

    private static void WriteFlagFields(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type,
        bool lengthTableIsRva
    )
    {
        WriteDefinedBitsLengthField(writer, model, keySelector, type, lengthTableIsRva);
        WriteDefinedBitsNameField(writer, model, keySelector, type);

        if (model.FlagsInfo!.InvertedCompositeValues.Count > 0)
        {
            WriteCompositeBitsValuesField(writer, model, type);
        }
    }

    private static void WriteDefinedBitsLengthField(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type,
        bool lengthTableIsRva
    )
    {
        var bitCount = model.GetMappedBitCount();
        var compositeValuesCount = model.FlagsInfo!.InvertedCompositeValues.Count;

        if (lengthTableIsRva)
        {
            writer.Write(
                $"private static ReadOnlySpan<byte> s_format{type}Lengths => new byte[{bitCount + compositeValuesCount}] {{ "
            );
        }
        else
        {
            writer.Write(
                $"private static readonly int[] s_format{type}Lengths = new int[{bitCount + compositeValuesCount}] {{ "
            );
        }

        var bitValues = model.FlagsInfo!.BitValues;
        for (var i = 0; i < bitCount; i++)
        {
            if (i > 0)
                writer.Write(", ");
            var found = bitValues.Find(x => x.BinaryValue == 1ul << i);
            writer.Write(found is not null ? keySelector(found).Length : 0);
        }

        var compositeValues = model.FlagsInfo.InvertedCompositeValues;
        for (var i = 0; i < compositeValues.Count; i++)
        {
            if (bitCount > 0 || i > 0)
                writer.Write(", ");
            writer.Write(keySelector(compositeValues[i]).Length);
        }

        writer.WriteLine(" };");
    }

    private static void WriteDefinedBitsNameField(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type
    )
    {
        var bitCount = model.GetMappedBitCount();
        var compositeValuesCount = model.FlagsInfo!.InvertedCompositeValues.Count;
        var nullableSign = model.FlagsInfo.IsAllSingleBitsDefined ? "" : "?";

        writer.Write(
            $"private static readonly string{nullableSign}[] s_format{type}s = new string{nullableSign}[{bitCount + compositeValuesCount}] {{ "
        );

        var bitValues = model.FlagsInfo!.BitValues;
        for (var i = 0; i < bitCount; i++)
        {
            if (i > 0)
                writer.Write(", ");
            var found = bitValues.Find(x => x.BinaryValue == 1ul << i);
            writer.Write(found is not null ? keySelector(found).ToQuotedStringLiteral() : "null");
        }

        var compositeValues = model.FlagsInfo.InvertedCompositeValues;
        for (var i = 0; i < compositeValues.Count; i++)
        {
            if (bitCount > 0 || i > 0)
                writer.Write(", ");
            writer.Write(keySelector(compositeValues[i]).ToQuotedStringLiteral());
        }

        writer.WriteLine(" };");
    }

    private static void WriteCompositeBitsValuesField(SourceTextWriter writer, EnumToGenerate model, string type)
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
    }

    private static void WriteToString(
        SourceTextWriter writer,
        EnumToGenerate model,
        EnumFormatDefinition formatDefinition
    )
    {
        var nullableSign = formatDefinition.AllowNumbers || model.FlagsInfo!.IsAllSingleBitsDefined ? "" : "?";
        writer.WriteLine(
            $$"""
            /// <inheritdoc cref="{{formatDefinition.XmlRefType}}.{{formatDefinition.ToStringMethodName}}(TEnum)"/>
            [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            public static string{{nullableSign}} {{formatDefinition.ToStringMethodName}}(this {{model.RefName}} value)
            {
                {{model.UnderlyingType}} v = ({{model.UnderlyingType}})value;
            """
        );
        writer.PushIndent();

        var zeroValue = (model.HasZeroMember, formatDefinition.AllowNumbers) switch
        {
            (true, _) => formatDefinition.KeySelector(model.ZeroMember!).ToQuotedStringLiteral(),
            (false, true) => "\"0\"",
            (false, false) => "null",
        };
        writer.WriteLine($"if (v == 0) {{ return {zeroValue}; }}");

        if (!model.FlagsInfo!.IsAllBitsDefined)
        {
            var resultValue = formatDefinition.AllowNumbers ? "v.ToString()" : "null";
            writer.WriteLine($"if ((v & ~ValidFlagsMask) != 0) {{ return {resultValue}; }}");
        }

        var fallbackValue = (model.FlagsInfo.IsAllSingleBitsDefined, formatDefinition.AllowNumbers) switch
        {
            (true, _) => "",
            (false, true) => " ?? v.ToString()",
            (false, false) => "",
        };
        writer.WriteLine();
        writer.WriteLine(
            $$"""
            if ((v & (v - 1)) == 0)
            {
                return global::System.Runtime.CompilerServices.Unsafe.Add(
                    ref global::System.Runtime.InteropServices.MemoryMarshal.GetArrayDataReference(s_format{{formatDefinition.Type}}s),
                    global::System.Numerics.BitOperations.TrailingZeroCount(v)){{fallbackValue}};
            }

            return Format{{formatDefinition.Type}}MultipleFlags(v);
            """
        );

        writer.PopIndent();
        writer.WriteLine('}');
    }

    private static void WriteGetStringLength(
        SourceTextWriter writer,
        EnumToGenerate model,
        EnumFormatDefinition formatDefinition,
        bool lengthTableIsRva
    )
    {
        var tableType = lengthTableIsRva ? "byte" : "int";
        var nullableSign = formatDefinition.AllowNumbers || model.FlagsInfo!.IsAllSingleBitsDefined ? "" : "?";
        writer.WriteLine(
            $$"""
            /// <inheritdoc cref="{{formatDefinition.XmlRefType}}.{{formatDefinition.GetStringLengthMethodName}}(TEnum)"/>
            [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            public static int{{nullableSign}} {{formatDefinition.GetStringLengthMethodName}}(this {{model.RefName}} value)
            {
                {{model.UnderlyingType}} v = ({{model.UnderlyingType}})value;
            """
        );
        writer.PushIndent();

        var zeroLength = (model.HasZeroMember, formatDefinition.AllowNumbers) switch
        {
            (true, _) => formatDefinition.KeySelector(model.ZeroMember!).Length.ToString(),
            (false, true) => "1",
            (false, false) => "null",
        };
        writer.WriteLine($"if (v == 0) {{ return {zeroLength}; }}");

        if (!model.FlagsInfo!.IsAllBitsDefined)
        {
            var resultValue = formatDefinition.AllowNumbers
                ? "global::Raiqub.Generators.EnumUtilities.Formatters.EnumNumericFormatter.GetStringLength(v)"
                : "null";
            writer.WriteLine($"if ((v & ~ValidFlagsMask) != 0) {{ return {resultValue}; }}");
        }

        var fallbackValue = (model.FlagsInfo.IsAllSingleBitsDefined, formatDefinition.AllowNumbers) switch
        {
            (true, _) => "ret",
            (false, true) =>
                "ret != 0 ? ret : global::Raiqub.Generators.EnumUtilities.Formatters.EnumNumericFormatter.GetStringLength(v)",
            (false, false) => "ret != 0 ? ret : null",
        };
        writer.WriteLine();
        writer.WriteLine(
            $$"""
            ref {{tableType}} table = ref global::System.Runtime.InteropServices.MemoryMarshal.GetReference(s_format{{formatDefinition.Type}}Lengths);

            if ((v & (v - 1)) == 0)
            {
                int bitPos = global::System.Numerics.BitOperations.TrailingZeroCount(v);
                int ret = global::System.Runtime.CompilerServices.Unsafe.Add(ref table, bitPos);
                return {{fallbackValue}};
            }

            return Get{{formatDefinition.Type}}StringLengthForMultipleFlags(v);
            """
        );

        writer.PopIndent();
        writer.WriteLine('}');
    }

    private static void WriteFormatMultipleFlags(
        SourceTextWriter writer,
        EnumToGenerate model,
        EnumFormatDefinition formatDefinition,
        bool lengthTableIsRva
    )
    {
        var nullableSign = formatDefinition.AllowNumbers || model.FlagsInfo!.IsAllSingleBitsDefined ? "" : "?";
        writer.WriteLine(
            $$"""
            private static string{{nullableSign}} Format{{formatDefinition.Type}}MultipleFlags({{model.UnderlyingType}} value)
            {
            """
        );
        writer.PushIndent();

        var bitCount = model.GetMappedBitCount();
        var unSigType = model.BitCount > 32 ? "ulong" : "uint";
        var tableType = lengthTableIsRva ? "byte" : "int";
        var compositeValuesCount = model.FlagsInfo!.InvertedCompositeValues.Count;
        var hasCompositeValues = compositeValuesCount > 0;

        writer.WriteLine(
            $$"""
            int charCount = 0;
            {{unSigType}} remaining = ({{unSigType}})value;
            Span<int> foundItems = stackalloc int[{{model.GetMappedBitCount()}}];
            int foundItemsCount = 0;
            ref {{tableType}} table = ref global::System.Runtime.InteropServices.MemoryMarshal.GetReference(s_format{{formatDefinition.Type}}Lengths);
            """
        );

        if (hasCompositeValues)
        {
            writer.WriteLine();
            writer.WriteLine(
                $$"""
                ref {{model.UnderlyingType}} cv = ref global::System.Runtime.InteropServices.MemoryMarshal.GetArrayDataReference(s_composite{{formatDefinition.Type}}Values);
                ref {{tableType}} cl = ref global::System.Runtime.CompilerServices.Unsafe.Add(ref table, {{bitCount}});
                for (int i = 0; i < {{compositeValuesCount}}; i++)
                {
                    {{unSigType}} c = ({{unSigType}})global::System.Runtime.CompilerServices.Unsafe.Add(ref cv, i);
                    if ((remaining & c) == c)
                    {
                        foundItems[foundItemsCount++] = i + {{bitCount}};
                        charCount += global::System.Runtime.CompilerServices.Unsafe.Add(ref cl, i);
                        remaining &= ~c;
                        if ((remaining & (remaining - 1)) == 0) break;
                    }
                }

                if (remaining == 0)
                {
                    return global::Raiqub.Generators.EnumUtilities.Formatters.EnumStringFormatter.WriteMultipleFoundFlagsNames(s_format{{formatDefinition.Type}}s, foundItems.Slice(0, foundItemsCount), charCount);
                }
                """
            );
        }

        writer.WriteLine();
        if (model.FlagsInfo.IsAllSingleBitsDefined)
        {
            writer.WriteLine(
                $$"""
                do
                {
                    int bitPos = global::System.Numerics.BitOperations.TrailingZeroCount(remaining);
                    foundItems[foundItemsCount++] = bitPos;
                    charCount += global::System.Runtime.CompilerServices.Unsafe.Add(ref table, bitPos);
                    remaining &= remaining - 1;
                } while (remaining != 0);

                return global::Raiqub.Generators.EnumUtilities.Formatters.EnumStringFormatter.WriteMultipleFoundFlagsNames(s_format{{formatDefinition.Type}}s, foundItems.Slice(0, foundItemsCount), charCount);
                """
            );
        }
        else
        {
            var fallbackValue = formatDefinition.AllowNumbers ? "value.ToString()" : "null";
            writer.WriteLine(
                $$"""
                do
                {
                    int bitPos = global::System.Numerics.BitOperations.TrailingZeroCount(remaining);
                    {{tableType}} lenValue = global::System.Runtime.CompilerServices.Unsafe.Add(ref table, bitPos);
                    if (lenValue == 0) return {{fallbackValue}};
                    foundItems[foundItemsCount++] = bitPos;
                    charCount += lenValue;
                    remaining &= remaining - 1;
                } while (remaining != 0);

                return global::Raiqub.Generators.EnumUtilities.Formatters.EnumStringFormatter.WriteMultipleFoundFlagsNames(s_format{{formatDefinition.Type}}s, foundItems.Slice(0, foundItemsCount), charCount);
                """
            );
        }

        writer.PopIndent();
        writer.WriteLine('}');
    }

    private static void WriteGetStringLengthForMultipleFlags(
        SourceTextWriter writer,
        EnumToGenerate model,
        EnumFormatDefinition formatDefinition,
        bool lengthTableIsRva
    )
    {
        var nullableSign = formatDefinition.AllowNumbers || model.FlagsInfo!.IsAllSingleBitsDefined ? "" : "?";
        writer.WriteLine(
            $$"""
            private static int{{nullableSign}} Get{{formatDefinition.Type}}StringLengthForMultipleFlags({{model.UnderlyingType}} value)
            {
            """
        );
        writer.PushIndent();

        var bitCount = model.GetMappedBitCount();
        var unSigType = model.BitCount > 32 ? "ulong" : "uint";
        var tableType = lengthTableIsRva ? "byte" : "int";
        var compositeValuesCount = model.FlagsInfo!.InvertedCompositeValues.Count;
        var hasCompositeValues = compositeValuesCount > 0;

        writer.WriteLine(
            $$"""
            int charCount = -2;
            {{unSigType}} remaining = ({{unSigType}})value;
            ref {{tableType}} table = ref global::System.Runtime.InteropServices.MemoryMarshal.GetReference(s_format{{formatDefinition.Type}}Lengths);
            """
        );

        if (hasCompositeValues)
        {
            writer.WriteLine();
            writer.WriteLine(
                $$"""
                ref {{model.UnderlyingType}} cv = ref global::System.Runtime.InteropServices.MemoryMarshal.GetArrayDataReference(s_composite{{formatDefinition.Type}}Values);
                ref {{tableType}} cl = ref global::System.Runtime.CompilerServices.Unsafe.Add(ref table, {{bitCount}});
                for (int i = 0; i < {{compositeValuesCount}}; i++)
                {
                    {{unSigType}} c = ({{unSigType}})global::System.Runtime.CompilerServices.Unsafe.Add(ref cv, i);
                    if ((remaining & c) == c)
                    {
                        charCount += global::System.Runtime.CompilerServices.Unsafe.Add(ref cl, i) + 2;
                        remaining &= ~c;
                        if ((remaining & (remaining - 1)) == 0) break;
                    }
                }

                if (remaining == 0) { return charCount; }
                """
            );
        }

        writer.WriteLine();
        if (model.FlagsInfo.IsAllSingleBitsDefined)
        {
            writer.WriteLine(
                """
                do
                {
                    int bitPos = global::System.Numerics.BitOperations.TrailingZeroCount(remaining);
                    charCount += global::System.Runtime.CompilerServices.Unsafe.Add(ref table, bitPos) + 2;
                    remaining &= remaining - 1;
                } while (remaining != 0);

                return charCount;
                """
            );
        }
        else
        {
            var fallbackValue = formatDefinition.AllowNumbers
                ? "global::Raiqub.Generators.EnumUtilities.Formatters.EnumNumericFormatter.GetStringLength(value)"
                : "null";
            writer.WriteLine(
                $$"""
                do
                {
                    int bitPos = global::System.Numerics.BitOperations.TrailingZeroCount(remaining);
                    {{tableType}} lenValue = global::System.Runtime.CompilerServices.Unsafe.Add(ref table, bitPos);
                    if (lenValue == 0) return {{fallbackValue}};
                    charCount += lenValue + 2;
                    remaining &= remaining - 1;
                } while (remaining != 0);

                return charCount;
                """
            );
        }

        writer.PopIndent();
        writer.WriteLine('}');
    }
}
