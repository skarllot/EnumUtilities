using System.Diagnostics.CodeAnalysis;
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
        WriteFormatFlag(writer, model, keySelector, type, lengthTableIsRva, compositeIsRva);
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
        WriteDefinedBitsLengthField(writer, model, keySelector, type, lengthTableIsRva);
        WriteDefinedBitsNameField(writer, model, keySelector, type);

        if (model.FlagsInfo!.InvertedCompositeValues.Count > 0)
        {
            writer.WriteLine();
            WriteCompositeBitsValuesField(writer, model, type);
            WriteCompositeBitsLengthField(writer, model, keySelector, type, compositeIsRva);
            WriteCompositeBitsNameField(writer, model, keySelector, type);
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

    private static void WriteDefinedBitsNameField(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type
    )
    {
        var bitCount = model.GetMappedBitCount();

        writer.Write($"private static readonly string?[] s_format{type}s = new string?[{bitCount}] {{ ");

        var bitValues = model.FlagsInfo!.BitValues;
        for (var i = 0; i < bitCount; i++)
        {
            if (i > 0)
                writer.Write(", ");
            var found = bitValues.Find(x => x.RealMemberValue == 1u << i);
            writer.Write(found is not null ? keySelector(found).ToQuotedStringLiteral() : "null");
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

    private static void WriteCompositeBitsLengthField(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type,
        bool compositeIsRva
    )
    {
        var compositeValuesCount = model.FlagsInfo!.InvertedCompositeValues.Count;
        if (compositeIsRva)
        {
            writer.Write(
                $"private static ReadOnlySpan<byte> s_composite{type}Lengths => new byte[{compositeValuesCount}] {{ "
            );
        }
        else
        {
            writer.Write(
                $"private static readonly int[] s_composite{type}Lengths = new int[{compositeValuesCount}] {{ "
            );
        }

        for (var i = 0; i < model.FlagsInfo.InvertedCompositeValues.Count; i++)
        {
            if (i > 0)
                writer.Write(", ");
            writer.Write(keySelector(model.FlagsInfo.InvertedCompositeValues[i]).Length);
        }

        writer.WriteLine(" };");
    }

    private static void WriteCompositeBitsNameField(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type
    )
    {
        var compositeValuesCount = model.FlagsInfo!.InvertedCompositeValues.Count;
        writer.Write($"private static readonly string[] s_composite{type}s = new string[{compositeValuesCount}] {{ ");

        for (var i = 0; i < model.FlagsInfo.InvertedCompositeValues.Count; i++)
        {
            if (i > 0)
                writer.Write(", ");
            writer.Write(keySelector(model.FlagsInfo.InvertedCompositeValues[i]).ToQuotedStringLiteral());
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

    [SuppressMessage("Design", "MA0051:Method is too long")]
    private static void WriteFormatFlag(
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
            private static string? FormatFlag{{type}}s({{model.UnderlyingType}} value)
            {
            """
        );
        writer.PushIndent();

        var zeroValue = model.HasZeroMember ? keySelector(model.ZeroMember) : "0";
        var unSigType = model.BitCount > 32 ? "ulong" : "uint";
        var tableType = lengthTableIsRva ? "byte" : "int";

        writer.WriteLine($"if (value == 0) {{ return {zeroValue.ToQuotedStringLiteral()}; }}");

        if (!model.FlagsInfo!.IsAllBitsDefined)
        {
            writer.WriteLine("if ((value & ~ValidFlagsMask) != 0) { return null; }");
        }

        writer.WriteLine();
        writer.WriteLine(
            $$"""
            if ((value & (value - 1)) == 0)
            {
                return global::System.Runtime.CompilerServices.Unsafe.Add(
                    ref global::System.Runtime.InteropServices.MemoryMarshal.GetReference(s_format{{type}}s),
                    global::System.Numerics.BitOperations.TrailingZeroCount(value));
            }
            """
        );

        writer.WriteLine();
        writer.WriteLine(
            $$"""
            int charCount = 0;
            {{unSigType}} remaining = ({{unSigType}})value;
            Span<FoundMember> foundItems = stackalloc FoundMember[{{model.GetMappedBitCount()}}];
            int foundItemsCount = 0;
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
                        foundItems[foundItemsCount++] = new FoundMember(true, i);
                        charCount += global::System.Runtime.CompilerServices.Unsafe.Add(ref cl, i);
                        remaining &= ~c;
                        if ((remaining & (remaining - 1)) == 0) break;
                    }
                }

                if (remaining == 0)
                {
                    return EnumStringFormatter.WriteMultipleFoundFlagsNames(s_format{{type}}s, s_composite{{type}}s, foundItems.Slice(0, foundItemsCount), charCount);
                }
                """
            );
        }

        writer.WriteLine();
        writer.WriteLine(
            $$"""
            ref {{tableType}} table = ref global::System.Runtime.InteropServices.MemoryMarshal.GetReference(s_format{{type}}Lengths);

            do
            {
                int bitPos = global::System.Numerics.BitOperations.Log2(remaining);
                foundItems[foundItemsCount++] = new FoundMember(false, bitPos);
                charCount += global::System.Runtime.CompilerServices.Unsafe.Add(ref table, bitPos);
                remaining ^= 1u << bitPos;
            } while (remaining != 0);
            """
        );

        writer.WriteLine();

        if (model.FlagsInfo.InvertedCompositeValues.Count > 0)
        {
            writer.WriteLine(
                $"return EnumStringFormatter.WriteMultipleFoundFlagsNames(s_format{type}s, s_composite{type}s, foundItems.Slice(0, foundItemsCount), charCount);"
            );
        }
        else
        {
            writer.WriteLine(
                $"return EnumStringFormatter.WriteMultipleFoundFlagsNames(s_format{type}s, default, foundItems.Slice(0, foundItemsCount), charCount);"
            );
        }

        writer.PopIndent();
        writer.WriteLine('}');
    }
}
