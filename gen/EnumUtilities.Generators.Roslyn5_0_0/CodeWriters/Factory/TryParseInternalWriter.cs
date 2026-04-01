using Raiqub.Generators.EnumUtilities.Common;
using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Factory;

public static class TryParseInternalWriter
{
    public static TextSegment GetMethodName(string nameSuffix) => $"TryParse{nameSuffix}";

    public static void Write(SourceTextWriter writer, EnumToGenerate model, EnumParseDefinition definition)
    {
        var methodName = GetMethodName(definition.CoreNameSuffix);
        var emptyMember = definition.AllowEmpty
            ? model.Values.FirstOrDefault(x => definition.KeySelector(x)?.Length == 0)
            : null;

        if (definition.AllowNumbers)
        {
            WriteTryParseForAllowNumeric(writer, model, definition, methodName, emptyMember);
        }
        else
        {
            WriteTryParseForNonNumeric(writer, model, definition, methodName, emptyMember);
        }

        writer.WriteLine();
        WriteTryParseNonNumeric(writer, model, definition, allowFlags: !definition.AllowEmpty);
        writer.WriteLine();
        WriteTryParseLookup(writer, model, definition);
    }

    private static void WriteTryParseForAllowNumeric(
        SourceTextWriter writer,
        EnumToGenerate model,
        in EnumParseDefinition def,
        TextSegment methodName,
        EnumValue? emptyMember
    )
    {
        writer.WriteLine(
            $$"""
            private static bool {{methodName}}(ReadOnlySpan<char> {{def.ParameterName}}, StringComparison comparisonType, bool throwOnFailure, out {{model.UnderlyingType}} result)
            {
            """
        );
        writer.PushIndent();

        if (emptyMember != null)
        {
            writer.WriteLine(
                $$"""
                if ({{def.ParameterName}}.IsEmpty)
                {
                    result = {{emptyMember.MemberValue}};
                    return true;
                }
                else
                """
            );
        }
        else
        {
            writer.WriteLine($"if (!{def.ParameterName}.IsEmpty)");
        }

        writer.WriteLine('{');
        writer.PushIndent();

        writer.WriteLine(
            $$"""
            char c = {{def.ParameterName}}[0];
            if (char.IsWhiteSpace(c))
            {
                {{def.ParameterName}} = {{def.ParameterName}}.TrimStart();
                if ({{def.ParameterName}}.IsEmpty)
                {
                    goto ParseFailure;
                }

                c = {{def.ParameterName}}[0];
            }

            if ((c < '0' || c > '9') && c != '-' && c != '+')
            {
                return TryParseNonNumeric{{def.CoreNameSuffix}}({{def.ParameterName}}, comparisonType, throwOnFailure, out result);
            }

            bool success = EnumNumericParser.TryParse({{def.ParameterName}}, out result);
            if (success)
            {
                return true;
            }
            """
        );
        writer.WriteLine();

        writer.WriteLine(
            $"return TryParseNonNumeric{def.CoreNameSuffix}({def.ParameterName}, comparisonType, throwOnFailure, out result);"
        );

        writer.PopIndent();
        writer.WriteLine('}');
        writer.WriteLine();

        writer.WriteLine("ParseFailure:");

        writer.WriteLine(
            $$"""
            if (throwOnFailure)
            {
                ThrowHelper.ThrowInvalidEmptyParseArgument(nameof({{def.ParameterName}}));
            }

            result = 0;
            return false;
            """
        );

        writer.PopIndent();
        writer.WriteLine('}');
    }

    private static void WriteTryParseForNonNumeric(
        SourceTextWriter writer,
        EnumToGenerate model,
        in EnumParseDefinition def,
        TextSegment methodName,
        EnumValue? emptyMember
    )
    {
        writer.WriteLine(
            $$"""
            private static bool {{methodName}}(ReadOnlySpan<char> {{def.ParameterName}}, StringComparison comparisonType, bool throwOnFailure, out {{model.UnderlyingType}} result)
            {
            """
        );
        writer.PushIndent();

        if (emptyMember != null)
        {
            writer.WriteLine(
                $$"""
                if ({{def.ParameterName}}.IsEmpty)
                {
                    result = {{emptyMember.MemberValue}};
                    return true;
                }
                else
                """
            );
        }
        else
        {
            writer.WriteLine($"if (!{def.ParameterName}.IsEmpty)");
        }

        writer.WriteLine('{');
        writer.PushIndent();

        writer.WriteLine(
            $"return TryParseNonNumeric{def.CoreNameSuffix}({def.ParameterName}, comparisonType, throwOnFailure, out result);"
        );

        writer.PopIndent();
        writer.WriteLine('}');
        writer.WriteLine();

        if (emptyMember == null)
        {
            writer.WriteLine(
                $$"""
                if (throwOnFailure)
                {
                    ThrowHelper.ThrowInvalidEmptyParseArgument(nameof({{def.ParameterName}}));
                }

                result = 0;
                return false;
                """
            );
        }

        writer.PopIndent();
        writer.WriteLine('}');
    }

    private static void WriteTryParseNonNumeric(
        SourceTextWriter writer,
        EnumToGenerate model,
        in EnumParseDefinition def,
        bool allowFlags
    )
    {
        if (model.IsFlags && allowFlags)
        {
            writer.WriteLine(
                $$"""
                private static bool TryParseNonNumeric{{def.CoreNameSuffix}}(ReadOnlySpan<char> {{def.ParameterName}}, StringComparison comparisonType, bool throwOnFailure, out {{model.UnderlyingType}} result)
                {
                    bool parsed = true;
                    {{model.UnderlyingType}} localResult = 0;
                    foreach (var item in new FlagsEnumTokenizer({{def.ParameterName}}))
                    {
                        bool success = TryParseSingle{{def.CoreNameSuffix}}(item, comparisonType, out {{model.UnderlyingType}} singleValue);
                        if (!success)
                        {
                            parsed = false;
                            break;
                        }

                        localResult |= singleValue;
                    }

                    if (parsed)
                    {
                        result = localResult;
                        return true;
                    }

                    if (throwOnFailure)
                    {
                        ThrowHelper.ThrowValueNotFound({{def.ParameterName}}, nameof({{def.ParameterName}}));
                    }

                    result = 0;
                    return false;
                }
                """
            );
        }
        else
        {
            writer.WriteLine(
                $$"""
                private static bool TryParseNonNumeric{{def.CoreNameSuffix}}(ReadOnlySpan<char> {{def.ParameterName}}, StringComparison comparisonType, bool throwOnFailure, out {{model.UnderlyingType}} result)
                {
                    bool success = TryParseSingle{{def.CoreNameSuffix}}({{def.ParameterName}}, comparisonType, out result);
                    if (success)
                    {
                        return true;
                    }

                    if (throwOnFailure)
                    {
                        ThrowHelper.ThrowValueNotFound({{def.ParameterName}}, nameof({{def.ParameterName}}));
                    }

                    return false;
                }
                """
            );
        }
    }

    private static void WriteTryParseLookup(SourceTextWriter writer, EnumToGenerate model, EnumParseDefinition def)
    {
        writer.WriteLine(
            $$"""
            private static bool TryParseSingle{{def.CoreNameSuffix}}(ReadOnlySpan<char> value, StringComparison comparisonType, out {{model.UnderlyingType}} result)
            {
            """
        );
        writer.PushIndent();

        WriteTryParseSectionEmptyHandle(writer, model, def.KeySelector);
        writer.WriteLine();

        var lookupTable = model
            .Values.Where(x => def.KeySelector(x)?.Length > 0)
            .ToLookup(x => def.KeySelector(x)![0], CharIgnoreCaseEqualityComparer.Instance);

        writer.WriteLine(
            """
            switch (value[0])
            {
            """
        );
        writer.PushIndent();

        foreach (var curr in lookupTable.OrderBy(x => x.Key))
        {
            if (char.ToUpperInvariant(curr.Key) == curr.Key && char.ToLowerInvariant(curr.Key) == curr.Key)
            {
                writer.WriteLine($"case {curr.Key.ToQuotedCharLiteral()}:");
            }
            else
            {
                writer.WriteLine(
                    $"""
                    case {char.ToUpperInvariant(curr.Key).ToQuotedCharLiteral()}:
                    case {char.ToLowerInvariant(curr.Key).ToQuotedCharLiteral()}:
                    """
                );
            }

            writer.PushIndent();

            WriteTryParseSectionSwitchForFirstCharacter(writer, def.KeySelector, curr);

            writer.WriteLine("break;");
            writer.PopIndent();
        }

        writer.PopIndent(levels: 2);
        writer.WriteLine(
            """
                }

                result = 0;
                return false;
            }
            """
        );
    }

    private static void WriteTryParseSectionEmptyHandle(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string?> keySelector
    )
    {
        writer.WriteLine(
            """
            if (value.IsEmpty)
            {
            """
        );
        writer.PushIndent();

        var binEmptyValue = model.Values.FirstOrDefault(x => keySelector(x)?.Length == 0);
        if (binEmptyValue != null)
        {
            writer.WriteLine(
                $"""
                result = {binEmptyValue.MemberValue};
                return true;
                """
            );
        }
        else
        {
            writer.WriteLine(
                """
                result = 0;
                return false;
                """
            );
        }

        writer.PopIndent();
        writer.WriteLine('}');
    }

    private static void WriteTryParseSectionSwitchForFirstCharacter(
        SourceTextWriter writer,
        Func<EnumValue, string?> keySelector,
        IEnumerable<EnumValue> curr
    )
    {
        writer.WriteLine(
            """
            switch (value)
            {
            """
        );
        writer.PushIndent();

        foreach (var enumValue in curr)
        {
            writer.WriteLine(
                $$"""
                case { } when value.Equals({{keySelector(enumValue)!.ToQuotedStringLiteral()}}, comparisonType):
                    result = {{enumValue.MemberValue}};
                    return true;
                """
            );
        }

        writer.PopIndent();
        writer.WriteLine('}');
    }
}
