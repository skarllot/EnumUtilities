using Raiqub.Generators.EnumUtilities.Common;
using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Extensions;

public static class FormatPlainStringInternal
{
    public static void Write(SourceTextWriter writer, EnumToGenerate model, EnumFormatDefinition formatDefinition)
    {
        var caseCount = model.UniqueValues.Count;
        var additionalCases = 1 + (model.HasZeroMember ? 0 : 1);
        var range = model.IsUnsigned
            ? (model.UniqueValues.Max(static x => x.AsUInt64()) - model.UniqueValues.Min(static x => x.AsUInt64()))
            : (ulong)(
                model.UniqueValues.Max(static x => x.AsInt64()) - model.UniqueValues.Min(static x => x.AsInt64())
            );
        var isDense = range <= (ulong)caseCount;
        var isInlining = caseCount + additionalCases <= 10 && (isDense || caseCount + additionalCases <= 5);

        WriteToString(writer, model, formatDefinition, isInlining);
        writer.WriteLine();
        WriteGetStringLength(writer, model, formatDefinition, isInlining);
    }

    private static void WriteToString(
        SourceTextWriter writer,
        EnumToGenerate model,
        EnumFormatDefinition formatDefinition,
        bool isInlining
    )
    {
        var nullableSign = formatDefinition.AllowNumbers ? "" : "?";

        writer.WriteLine(
            $"/// <inheritdoc cref=\"{formatDefinition.XmlRefType}.{formatDefinition.ToStringMethodName}(TEnum)\"/>"
        );

        if (isInlining)
        {
            writer.WriteLine(
                "[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]"
            );
        }

        writer.WriteLine(
            $$"""
            public static string{{nullableSign}} {{formatDefinition.ToStringMethodName}}(this {{model.RefName}} value)
            {
                {{model.UnderlyingType}} v = ({{model.UnderlyingType}})value;
                return v switch
                {
            """
        );
        writer.PushIndent(levels: 2);

        if (!model.HasZeroMember)
        {
            writer.WriteLine(formatDefinition.AllowNumbers ? "0 => \"0\"," : "0 => null,");
        }

        foreach (var curr in model.UniqueValues)
        {
            writer.WriteLine($"{curr.MemberValue} => {formatDefinition.KeySelector(curr).ToQuotedStringLiteral()},");
        }

        writer.WriteLine(formatDefinition.AllowNumbers ? "_ => v.ToString()" : "_ => null");

        writer.PopIndent(levels: 2);
        writer.WriteLine(
            """
                };
            }
            """
        );
    }

    private static void WriteGetStringLength(
        SourceTextWriter writer,
        EnumToGenerate model,
        EnumFormatDefinition formatDefinition,
        bool isInlining
    )
    {
        var nullableSign = formatDefinition.AllowNumbers ? "" : "?";

        writer.WriteLine(
            $"/// <inheritdoc cref=\"{formatDefinition.XmlRefType}.{formatDefinition.GetStringLengthMethodName}(TEnum)\"/>"
        );

        if (isInlining)
        {
            writer.WriteLine(
                "[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]"
            );
        }

        writer.WriteLine(
            $$"""
            public static int{{nullableSign}} {{formatDefinition.GetStringLengthMethodName}}(this {{model.RefName}} value)
            {
                {{model.UnderlyingType}} v = ({{model.UnderlyingType}})value;
                return v switch
                {
            """
        );
        writer.PushIndent(levels: 2);

        if (!model.HasZeroMember)
        {
            writer.WriteLine(formatDefinition.AllowNumbers ? "0 => 1," : "0 => null,");
        }

        foreach (var curr in model.UniqueValues)
        {
            writer.WriteLine($"{curr.MemberValue} => {formatDefinition.KeySelector(curr).Length},");
        }

        writer.WriteLine(
            formatDefinition.AllowNumbers
                ? "_ => global::Raiqub.Generators.EnumUtilities.Formatters.EnumNumericFormatter.GetStringLength(v)"
                : "_ => null"
        );

        writer.PopIndent(levels: 2);
        writer.WriteLine(
            """
                };
            }
            """
        );
    }
}
