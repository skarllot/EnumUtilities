using System.Runtime.CompilerServices;
using System.Text;
using Raiqub.Generators.EnumUtilities.Common;
using Raiqub.Generators.EnumUtilities.Formatters;
using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Extensions;

public static class FormatSmallFlagsStringInternal
{
    public static void Write(SourceTextWriter writer, EnumToGenerate model, EnumFormatDefinition formatDefinition)
    {
        var maxLength = model.FlagsInfo!.BitValues.Max(x => formatDefinition.KeySelector(x).Length);
        var lengthTableIsRva = maxLength <= byte.MaxValue;

        WriteLengthField(writer, model, formatDefinition.KeySelector, formatDefinition.Type, lengthTableIsRva);
        WriteNameField(writer, model, formatDefinition.KeySelector, formatDefinition.Type);
        writer.WriteLine();
        WriteToString(writer, model, formatDefinition);
        writer.WriteLine();
        WriteGetStringLength(writer, model, formatDefinition);
    }

    private static void WriteLengthField(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type,
        bool lengthTableIsRva
    )
    {
        var tableLength = 1u << model.GetMappedBitCount();

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

            if (len > 0)
            {
                writer.Write(len);
            }
            else if (model.IsUnsigned)
            {
                writer.Write(EnumNumericFormatter.GetStringLength(i));
            }
            else
            {
                writer.Write(EnumNumericFormatter.GetStringLength(Unsafe.As<uint, int>(ref i)));
            }
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
        var tableLength = 1u << model.GetMappedBitCount();

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
            if (sb.Length > 0)
            {
                writer.Write(sb.ToString().ToQuotedStringLiteral());
            }
            else if (model.IsUnsigned)
            {
                writer.Write($"\"{i}\"");
            }
            else
            {
                writer.Write($"\"{Unsafe.As<uint, int>(ref i)}\"");
            }
        }

        writer.WriteLine(" };");
    }

    private static void WriteToString(
        SourceTextWriter writer,
        EnumToGenerate model,
        EnumFormatDefinition formatDefinition
    )
    {
        var tableLength = 1u << model.GetMappedBitCount();
        var unSigType = model.BitCount > 32 ? "ulong" : "uint";
        var nullableSign = formatDefinition.AllowNumbers ? "" : "?";
        TextSegment returnValue = formatDefinition.AllowNumbers
            ? $"(({model.UnderlyingType})value).ToString()"
            : "null";

        writer.WriteLine(
            $$"""
            /// <inheritdoc cref="{{formatDefinition.XmlRefType}}.{{formatDefinition.ToStringMethodName}}(TEnum)"/>
            [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            public static string{{nullableSign}} {{formatDefinition.ToStringMethodName}}(this {{model.RefName}} value)
            {
                if (({{unSigType}})value < {{tableLength}})
                {
                    return global::System.Runtime.CompilerServices.Unsafe.Add(
                        ref global::System.Runtime.InteropServices.MemoryMarshal.GetArrayDataReference(s_format{{formatDefinition.Type}}s),
                        (int)value);
                }

                return {{returnValue}};
            }
            """
        );
    }

    private static void WriteGetStringLength(
        SourceTextWriter writer,
        EnumToGenerate model,
        EnumFormatDefinition formatDefinition
    )
    {
        var tableLength = 1u << model.GetMappedBitCount();
        var unSigType = model.BitCount > 32 ? "ulong" : "uint";
        var nullableSign = formatDefinition.AllowNumbers ? "" : "?";
        TextSegment returnValue = formatDefinition.AllowNumbers
            ? $"global::Raiqub.Generators.EnumUtilities.Formatters.EnumNumericFormatter.GetStringLength(({model.UnderlyingType})value)"
            : "null";

        writer.WriteLine(
            $$"""
            /// <inheritdoc cref="{{formatDefinition.XmlRefType}}.{{formatDefinition.GetStringLengthMethodName}}(TEnum)"/>
            [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            public static int{{nullableSign}} {{formatDefinition.GetStringLengthMethodName}}(this {{model.RefName}} value)
            {
                if (({{unSigType}})value < {{tableLength}})
                {
                    return global::System.Runtime.CompilerServices.Unsafe.Add(
                        ref global::System.Runtime.InteropServices.MemoryMarshal.GetReference(s_format{{formatDefinition.Type}}Lengths),
                        (int)value);
                }

                return {{returnValue}};
            }
            """
        );
    }
}
