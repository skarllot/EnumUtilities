using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Factory;

public static class ParseFacadeWriter
{
    public static void Write(SourceTextWriter writer, EnumToGenerate model, in EnumParseDefinition definition)
    {
        var coreMethodName = TryParseInternalWriter.GetMethodName(definition.CoreNameSuffix);
        WriteParseString(writer, model, definition, coreMethodName);

        writer.WriteLine();
        WriteParseSpan(writer, model, definition, coreMethodName);

        writer.WriteLine();
        WriteParseOrNull(writer, model, definition, coreMethodName);

        writer.WriteLine();
        WriteTryParseStringWithIgnoreCase(writer, model, definition, coreMethodName);

        writer.WriteLine();
        WriteTryParseString(writer, model, definition, coreMethodName);

        writer.WriteLine();
        WriteTryParseStringNullable(writer, model, definition, coreMethodName);

        writer.WriteLine();
        WriteTryParseSpanWithIgnoreCase(writer, model, definition, coreMethodName);

        writer.WriteLine();
        WriteTryParseSpan(writer, model, definition, coreMethodName);

        writer.WriteLine();
        WriteTryParseSpanNullable(writer, model, definition, coreMethodName);
    }

    private static void WriteParseString(
        SourceTextWriter writer,
        EnumToGenerate model,
        in EnumParseDefinition def,
        TextSegment coreMethodName
    )
    {
        if (def.UseStringComparison)
        {
            writer.WriteLine(
                $$"""
                /// <inheritdoc cref="{{def.XmlRefType}}.{{def.ActionName}}{{def.FacadeNameSuffix}}(string, StringComparison)"/>
                public static {{model.RefName}} {{def.ActionName}}{{def.FacadeNameSuffix}}(string {{def.ParameterName}}, StringComparison comparisonType = StringComparison.Ordinal)
                {
                    if ({{def.ParameterName}} is null) ThrowHelper.ThrowArgumentNullException(nameof({{def.ParameterName}}));
                    {{coreMethodName}}({{def.ParameterName}}.AsSpan(), comparisonType, throwOnFailure: true, out var result);
                    return ({{model.RefName}})result;
                }
                """
            );
        }
        else
        {
            writer.WriteLine(
                $$"""
                /// <inheritdoc cref="{{def.XmlRefType}}.{{def.ActionName}}{{def.FacadeNameSuffix}}(string, bool)"/>
                public static {{model.RefName}} {{def.ActionName}}{{def.FacadeNameSuffix}}(string {{def.ParameterName}}, bool ignoreCase = false)
                {
                    if ({{def.ParameterName}} is null) ThrowHelper.ThrowArgumentNullException(nameof({{def.ParameterName}}));
                    {{coreMethodName}}({{def.ParameterName}}.AsSpan(), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: true, out var result);
                    return ({{model.RefName}})result;
                }
                """
            );
        }
    }

    private static void WriteParseSpan(
        SourceTextWriter writer,
        EnumToGenerate model,
        in EnumParseDefinition def,
        TextSegment coreMethodName
    )
    {
        if (def.UseStringComparison)
        {
            writer.WriteLine(
                $$"""
                /// <inheritdoc cref="{{def.XmlRefType}}.{{def.ActionName}}{{def.FacadeNameSuffix}}(System.ReadOnlySpan{char}, StringComparison)"/>
                public static {{model.RefName}} {{def.ActionName}}{{def.FacadeNameSuffix}}(ReadOnlySpan<char> {{def.ParameterName}}, StringComparison comparisonType = StringComparison.Ordinal)
                {
                    {{coreMethodName}}({{def.ParameterName}}, comparisonType, throwOnFailure: true, out var result);
                    return ({{model.RefName}})result;
                }
                """
            );
        }
        else
        {
            writer.WriteLine(
                $$"""
                /// <inheritdoc cref="{{def.XmlRefType}}.{{def.ActionName}}{{def.FacadeNameSuffix}}(System.ReadOnlySpan{char}, bool)"/>
                public static {{model.RefName}} {{def.ActionName}}{{def.FacadeNameSuffix}}(ReadOnlySpan<char> {{def.ParameterName}}, bool ignoreCase = false)
                {
                    {{coreMethodName}}({{def.ParameterName}}, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: true, out var result);
                    return ({{model.RefName}})result;
                }
                """
            );
        }
    }

    private static void WriteParseOrNull(
        SourceTextWriter writer,
        EnumToGenerate model,
        in EnumParseDefinition def,
        TextSegment coreMethodName
    )
    {
        if (def.UseStringComparison)
        {
            writer.WriteLine(
                $$"""
                /// <inheritdoc cref="{{def.XmlRefType}}.{{def.ActionName}}{{def.FacadeNameSuffix}}OrNull(string, StringComparison)"/>
                [return: NotNullIfNotNull("{{def.ParameterName}}")]
                public static {{model.RefName}}? {{def.ActionName}}{{def.FacadeNameSuffix}}OrNull(string? {{def.ParameterName}}, StringComparison comparisonType = StringComparison.Ordinal)
                {
                    if ({{def.ParameterName}} is null) return null;
                    {{coreMethodName}}({{def.ParameterName}}.AsSpan(), comparisonType, throwOnFailure: true, out var result);
                    return ({{model.RefName}})result;
                }
                """
            );
        }
        else
        {
            writer.WriteLine(
                $$"""
                /// <inheritdoc cref="{{def.XmlRefType}}.{{def.ActionName}}{{def.FacadeNameSuffix}}OrNull(string, bool)"/>
                [return: NotNullIfNotNull("{{def.ParameterName}}")]
                public static {{model.RefName}}? {{def.ActionName}}{{def.FacadeNameSuffix}}OrNull(string? {{def.ParameterName}}, bool ignoreCase = false)
                {
                    if ({{def.ParameterName}} is null) return null;
                    {{coreMethodName}}({{def.ParameterName}}.AsSpan(), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: true, out var result);
                    return ({{model.RefName}})result;
                }
                """
            );
        }
    }

    private static void WriteTryParseStringWithIgnoreCase(
        SourceTextWriter writer,
        EnumToGenerate model,
        in EnumParseDefinition def,
        TextSegment coreMethodName
    )
    {
        if (def.UseStringComparison)
        {
            writer.WriteLine(
                $$"""
                /// <inheritdoc cref="{{def.XmlRefType}}.Try{{def.ActionName}}{{def.FacadeNameSuffix}}(string, StringComparison, out TEnum)"/>
                public static bool Try{{def.ActionName}}{{def.FacadeNameSuffix}}([NotNullWhen(true)] string? {{def.ParameterName}}, StringComparison comparisonType, out {{model.RefName}} result)
                {
                    Unsafe.SkipInit(out result);
                    return {{coreMethodName}}({{def.ParameterName}}.AsSpan(), comparisonType, throwOnFailure: false, out Unsafe.As<{{model.RefName}}, {{model.UnderlyingType}}>(ref result));
                }
                """
            );
        }
        else
        {
            writer.WriteLine(
                $$"""
                /// <inheritdoc cref="{{def.XmlRefType}}.Try{{def.ActionName}}{{def.FacadeNameSuffix}}(string, bool, out TEnum)"/>
                public static bool Try{{def.ActionName}}{{def.FacadeNameSuffix}}([NotNullWhen(true)] string? {{def.ParameterName}}, bool ignoreCase, out {{model.RefName}} result)
                {
                    Unsafe.SkipInit(out result);
                    return {{coreMethodName}}({{def.ParameterName}}.AsSpan(), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: false, out Unsafe.As<{{model.RefName}}, {{model.UnderlyingType}}>(ref result));
                }
                """
            );
        }
    }

    private static void WriteTryParseString(
        SourceTextWriter writer,
        EnumToGenerate model,
        in EnumParseDefinition def,
        TextSegment coreMethodName
    )
    {
        writer.WriteLine(
            $$"""
            /// <inheritdoc cref="{{def.XmlRefType}}.Try{{def.ActionName}}{{def.FacadeNameSuffix}}(string, out TEnum)"/>
            public static bool Try{{def.ActionName}}{{def.FacadeNameSuffix}}([NotNullWhen(true)] string? {{def.ParameterName}}, out {{model.RefName}} result)
            {
                Unsafe.SkipInit(out result);
                return {{coreMethodName}}({{def.ParameterName}}.AsSpan(), StringComparison.Ordinal, throwOnFailure: false, out Unsafe.As<{{model.RefName}}, {{model.UnderlyingType}}>(ref result));
            }
            """
        );
    }

    private static void WriteTryParseStringNullable(
        SourceTextWriter writer,
        EnumToGenerate model,
        in EnumParseDefinition def,
        TextSegment coreMethodName
    )
    {
        if (def.UseStringComparison)
        {
            writer.WriteLine(
                $$"""
                /// <inheritdoc cref="{{def.XmlRefType}}.Try{{def.ActionName}}{{def.FacadeNameSuffix}}(string, StringComparison)"/>
                public static {{model.RefName}}? Try{{def.ActionName}}{{def.FacadeNameSuffix}}(string? {{def.ParameterName}}, StringComparison comparisonType = StringComparison.Ordinal)
                {
                    return {{coreMethodName}}({{def.ParameterName}}.AsSpan(), comparisonType, throwOnFailure: false, out var result) ? ({{model.RefName}}?)result : null;
                }
                """
            );
        }
        else
        {
            writer.WriteLine(
                $$"""
                /// <inheritdoc cref="{{def.XmlRefType}}.Try{{def.ActionName}}{{def.FacadeNameSuffix}}(string, bool)"/>
                public static {{model.RefName}}? Try{{def.ActionName}}{{def.FacadeNameSuffix}}(string? {{def.ParameterName}}, bool ignoreCase = false)
                {
                    return {{coreMethodName}}({{def.ParameterName}}.AsSpan(), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: false, out var result) ? ({{model.RefName}}?)result : null;
                }
                """
            );
        }
    }

    private static void WriteTryParseSpanWithIgnoreCase(
        SourceTextWriter writer,
        EnumToGenerate model,
        in EnumParseDefinition def,
        TextSegment coreMethodName
    )
    {
        if (def.UseStringComparison)
        {
            writer.WriteLine(
                $$"""
                /// <inheritdoc cref="{{def.XmlRefType}}.Try{{def.ActionName}}{{def.FacadeNameSuffix}}(System.ReadOnlySpan{char}, StringComparison, out TEnum)"/>
                public static bool Try{{def.ActionName}}{{def.FacadeNameSuffix}}(ReadOnlySpan<char> {{def.ParameterName}}, StringComparison comparisonType, out {{model.RefName}} result)
                {
                    Unsafe.SkipInit(out result);
                    return {{coreMethodName}}({{def.ParameterName}}, comparisonType, throwOnFailure: false, out Unsafe.As<{{model.RefName}}, {{model.UnderlyingType}}>(ref result));
                }
                """
            );
        }
        else
        {
            writer.WriteLine(
                $$"""
                /// <inheritdoc cref="{{def.XmlRefType}}.Try{{def.ActionName}}{{def.FacadeNameSuffix}}(System.ReadOnlySpan{char}, bool, out TEnum)"/>
                public static bool Try{{def.ActionName}}{{def.FacadeNameSuffix}}(ReadOnlySpan<char> {{def.ParameterName}}, bool ignoreCase, out {{model.RefName}} result)
                {
                    Unsafe.SkipInit(out result);
                    return {{coreMethodName}}({{def.ParameterName}}, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: false, out Unsafe.As<{{model.RefName}}, {{model.UnderlyingType}}>(ref result));
                }
                """
            );
        }
    }

    private static void WriteTryParseSpan(
        SourceTextWriter writer,
        EnumToGenerate model,
        in EnumParseDefinition def,
        TextSegment coreMethodName
    )
    {
        writer.WriteLine(
            $$"""
            /// <inheritdoc cref="{{def.XmlRefType}}.Try{{def.ActionName}}{{def.FacadeNameSuffix}}(System.ReadOnlySpan{char}, out TEnum)"/>
            public static bool Try{{def.ActionName}}{{def.FacadeNameSuffix}}(ReadOnlySpan<char> {{def.ParameterName}}, out {{model.RefName}} result)
            {
                Unsafe.SkipInit(out result);
                return {{coreMethodName}}({{def.ParameterName}}, StringComparison.Ordinal, throwOnFailure: false, out Unsafe.As<{{model.RefName}}, {{model.UnderlyingType}}>(ref result));
            }
            """
        );
    }

    private static void WriteTryParseSpanNullable(
        SourceTextWriter writer,
        EnumToGenerate model,
        in EnumParseDefinition def,
        TextSegment coreMethodName
    )
    {
        if (def.UseStringComparison)
        {
            writer.WriteLine(
                $$"""
                /// <inheritdoc cref="{{def.XmlRefType}}.Try{{def.ActionName}}{{def.FacadeNameSuffix}}(System.ReadOnlySpan{char}, StringComparison)"/>
                public static {{model.RefName}}? Try{{def.ActionName}}{{def.FacadeNameSuffix}}(ReadOnlySpan<char> {{def.ParameterName}}, StringComparison comparisonType = StringComparison.Ordinal)
                {
                    return {{coreMethodName}}({{def.ParameterName}}, comparisonType, throwOnFailure: false, out var result) ? ({{model.RefName}}?)result : null;
                }
                """
            );
        }
        else
        {
            writer.WriteLine(
                $$"""
                /// <inheritdoc cref="{{def.XmlRefType}}.Try{{def.ActionName}}{{def.FacadeNameSuffix}}(System.ReadOnlySpan{char}, bool)"/>
                public static {{model.RefName}}? Try{{def.ActionName}}{{def.FacadeNameSuffix}}(ReadOnlySpan<char> {{def.ParameterName}}, bool ignoreCase = false)
                {
                    return {{coreMethodName}}({{def.ParameterName}}, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: false, out var result) ? ({{model.RefName}}?)result : null;
                }
                """
            );
        }
    }
}
