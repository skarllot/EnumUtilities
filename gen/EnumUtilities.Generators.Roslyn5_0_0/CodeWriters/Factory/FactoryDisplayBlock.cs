using Raiqub.Generators.EnumUtilities.Common;
using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Factory;

public class FactoryDisplayBlock : ICodeWriterModule<EnumToGenerate>
{
    public IEnumerable<string> GetNamespacesImports(EnumToGenerate model) => [];

    public bool CanGenerateFor(EnumToGenerate model) =>
        (model.SelectedGenerators & SelectedGenerators.MainGenerator) != SelectedGenerators.None
        && (model.HasDisplayName || model.HasDisplayDescription);

    public void Write(SourceTextWriter writer, EnumToGenerate model)
    {
        if (model.HasDisplayName)
        {
            WriteTryCreateFromDisplayShortName(writer, model);
            writer.WriteLine();
            WriteTryCreateFromDisplayName(writer, model);
        }

        if (model is { HasDisplayName: true, HasDisplayDescription: true })
        {
            writer.WriteLine();
        }

        if (model.HasDisplayDescription)
        {
            WriteTryCreateFromDescription(writer, model);
        }
    }

    private static void WriteTryCreateFromDisplayShortName(SourceTextWriter writer, EnumToGenerate model)
    {
        writer.WriteLine(
            $$"""
            public static bool TryCreateFromDisplayShortName(
                [NotNullWhen(true)] string? displayShortName,
                StringComparison comparisonType,
                out {{model.RefName}} result)
            {
            """
        );
        writer.PushIndent();

        if (model.Values.All(x => x.Display?.ShortName == null))
        {
            writer.WriteLine("return TryCreateFromDisplayName(displayShortName, comparisonType, out result);");
        }
        else
        {
            writer.WriteLine(
                $$"""
                {{model.UnderlyingType}} numValue;
                switch (displayShortName)
                {
                """
            );

            writer.PushIndent();
            foreach (var curr in model.Values.Where(x => x.Display?.ShortName != null))
            {
                writer.WriteLine(
                    $$"""
                      case { } s when s.Equals({{(
                        curr.Display!.ResourceShortName != null
                            ? curr.Display.ResourceShortName
                            : curr.Display.ShortName!.ToQuotedStringLiteral()
                    )}}, comparisonType):
                          numValue = {{curr.MemberValue}};
                          break;
                      """
                );
            }

            writer.WriteLine(
                """
                default:
                    return TryCreateFromDisplayName(displayShortName, comparisonType, out result);
                """
            );

            writer.PopIndent();
            writer.WriteLine('}');

            writer.WriteLine();
            writer.WriteLine(
                $"""
                result = ({model.RefName})numValue;
                return true;
                """
            );
        }

        writer.PopIndent();
        writer.WriteLine('}');

        writer.WriteLine();
        writer.WriteLine(
            $$"""
            public static bool TryCreateFromDisplayShortName([NotNullWhen(true)] string? displayShortName, out {{model.RefName}} result)
            {
                return TryCreateFromDisplayShortName(displayShortName, StringComparison.Ordinal, out result);
            }

            public static {{model.RefName}}? TryCreateFromDisplayShortName(string? displayShortName, StringComparison comparisonType)
            {
                return TryCreateFromDisplayShortName(displayShortName, comparisonType, out {{model.RefName}} result) ? result : null;
            }

            public static {{model.RefName}}? TryCreateFromDisplayShortName(string? displayShortName)
            {
                return TryCreateFromDisplayShortName(displayShortName, StringComparison.Ordinal, out {{model.RefName}} result) ? result : null;
            }
            """
        );
    }

    private static void WriteTryCreateFromDisplayName(SourceTextWriter writer, EnumToGenerate model)
    {
        writer.WriteLine(
            $$"""
            public static bool TryCreateFromDisplayName(
                [NotNullWhen(true)] string? displayName,
                StringComparison comparisonType,
                out {{model.RefName}} result)
            {
            """
        );
        writer.PushIndent();

        if (model.Values.IsEmpty)
        {
            writer.WriteLine(
                """
                result = default;
                return false;
                """
            );
        }
        else
        {
            writer.WriteLine(
                $$"""
                {{model.UnderlyingType}} numValue;
                switch (displayName)
                {
                """
            );

            writer.PushIndent();
            foreach (var curr in model.Values)
            {
                writer.WriteLine(
                    $$"""
                      case { } s when s.Equals({{(
                        curr.Display?.ResourceName != null
                            ? curr.Display.ResourceName
                            : (curr.Display?.Name ?? curr.MemberName).ToQuotedStringLiteral()
                    )}}, comparisonType):
                          numValue = {{curr.MemberValue}};
                          break;
                      """
                );
            }

            writer.WriteLine(
                """
                default:
                    result = default;
                    return false;
                """
            );

            writer.PopIndent();
            writer.WriteLine('}');

            writer.WriteLine();
            writer.WriteLine(
                $"""
                result = ({model.RefName})numValue;
                return true;
                """
            );
        }

        writer.PopIndent();
        writer.WriteLine('}');

        writer.WriteLine();
        writer.WriteLine(
            $$"""
            public static bool TryCreateFromDisplayName([NotNullWhen(true)] string? displayName, out {{model.RefName}} result)
            {
                return TryCreateFromDisplayName(displayName, StringComparison.Ordinal, out result);
            }

            public static {{model.RefName}}? TryCreateFromDisplayName(string? displayName, StringComparison comparisonType)
            {
                return TryCreateFromDisplayName(displayName, comparisonType, out {{model.RefName}} result) ? result : null;
            }

            public static {{model.RefName}}? TryCreateFromDisplayName(string? displayName)
            {
                return TryCreateFromDisplayName(displayName, StringComparison.Ordinal, out {{model.RefName}} result) ? result : null;
            }
            """
        );
    }

    private static void WriteTryCreateFromDescription(SourceTextWriter writer, EnumToGenerate model)
    {
        writer.WriteLine(
            $$"""
            public static bool TryCreateFromDescription(
                [NotNullWhen(true)] string? description,
                StringComparison comparisonType,
                out {{model.RefName}} result)
            {
            """
        );
        writer.PushIndent();

        if (model.Values.All(x => x.Display?.Description == null))
        {
            writer.WriteLine(
                """
                result = default;
                return false;
                """
            );
        }
        else
        {
            writer.WriteLine(
                $$"""
                {{model.UnderlyingType}} numValue;
                switch (description)
                {
                """
            );

            writer.PushIndent();
            foreach (var curr in model.Values.Where(x => x.Display?.Description != null))
            {
                writer.WriteLine(
                    $$"""
                      case { } s when s.Equals({{(
                        curr.Display!.ResourceDescription != null
                            ? curr.Display.ResourceDescription
                            : curr.Display.Description!.ToQuotedStringLiteral()
                    )}}, comparisonType):
                          numValue = {{curr.MemberValue}};
                          break;
                      """
                );
            }

            writer.WriteLine(
                """
                default:
                    result = default;
                    return false;
                """
            );

            writer.PopIndent();
            writer.WriteLine('}');

            writer.WriteLine();
            writer.WriteLine(
                $"""
                result = ({model.RefName})numValue;
                return true;
                """
            );
        }

        writer.PopIndent();
        writer.WriteLine('}');

        writer.WriteLine();
        writer.WriteLine(
            $$"""
            public static bool TryCreateFromDescription([NotNullWhen(true)] string? description, out {{model.RefName}} result)
            {
                return TryCreateFromDescription(description, StringComparison.Ordinal, out result);
            }

            public static {{model.RefName}}? TryCreateFromDescription(string? description, StringComparison comparisonType)
            {
                return TryCreateFromDescription(description, comparisonType, out {{model.RefName}} result) ? result : null;
            }

            public static {{model.RefName}}? TryCreateFromDescription(string? description)
            {
                return TryCreateFromDescription(description, StringComparison.Ordinal, out {{model.RefName}} result) ? result : null;
            }
            """
        );
    }
}
