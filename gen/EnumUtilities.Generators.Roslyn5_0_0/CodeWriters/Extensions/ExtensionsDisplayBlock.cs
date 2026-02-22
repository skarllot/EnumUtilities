using Raiqub.Generators.EnumUtilities.Common;
using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Extensions;

public sealed class ExtensionsDisplayBlock : ICodeWriterModule<EnumToGenerate>
{
    public IEnumerable<string> GetNamespacesImports(EnumToGenerate model) => [];

    public bool CanGenerateFor(EnumToGenerate model) =>
        (model.SelectedGenerators & SelectedGenerators.MainGenerator) != SelectedGenerators.None
        && (model.HasDisplayName || model.HasDisplayDescription);

    public void Write(SourceTextWriter writer, EnumToGenerate model)
    {
        if (model.HasDisplayName)
        {
            WriteGetDisplayShortName(writer, model);
            writer.WriteLine();
            WriteGetDisplayName(writer, model);
        }

        if (model is { HasDisplayName: true, HasDisplayDescription: true })
        {
            writer.WriteLine();
        }

        if (model.HasDisplayDescription)
        {
            WriteGetDescription(writer, model);
        }
    }

    private static void WriteGetDisplayShortName(SourceTextWriter writer, EnumToGenerate model)
    {
        writer.WriteLine(
            $$"""
            public static string GetDisplayShortName(this {{model.RefName}} value)
            {
                return ({{model.UnderlyingType}})value switch
                {
            """
        );

        writer.PushIndent(levels: 2);
        foreach (var curr in model.UniqueValues.Where(x => x.Display?.ShortName != null))
        {
            var currResult =
                curr.Display!.ResourceShortName != null
                    ? curr.Display.ResourceShortName
                    : curr.Display.ShortName.ToQuotedStringOrNullLiteral();
            writer.WriteLine($"{curr.MemberValue} => {currResult},");
        }

        writer.WriteLine("_ => GetDisplayName(value)");
        writer.PopIndent(levels: 2);

        writer.WriteLine(
            """
                };
            }
            """
        );
    }

    private static void WriteGetDisplayName(SourceTextWriter writer, EnumToGenerate model)
    {
        writer.WriteLine(
            $$"""
            public static string GetDisplayName(this {{model.RefName}} value)
            {
                return ({{model.UnderlyingType}})value switch
                {
            """
        );

        writer.PushIndent(levels: 2);
        foreach (var curr in model.UniqueValues)
        {
            var currResult =
                curr.Display?.ResourceName ?? (curr.Display?.Name ?? curr.MemberName).ToQuotedStringLiteral();
            writer.WriteLine($"{curr.MemberValue} => {currResult},");
        }

        writer.WriteLine("_ => ToStringFast(value)");
        writer.PopIndent(levels: 2);

        writer.WriteLine(
            """
                };
            }
            """
        );
    }

    private static void WriteGetDescription(SourceTextWriter writer, EnumToGenerate model)
    {
        writer.WriteLine(
            $$"""
            public static string? GetDescription(this {{model.RefName}} value)
            {
                return ({{model.UnderlyingType}})value switch
                {
            """
        );

        writer.PushIndent(levels: 2);
        foreach (var curr in model.UniqueValues.Where(x => x.Display?.Description != null))
        {
            var currResult =
                curr.Display!.ResourceDescription != null
                    ? curr.Display.ResourceDescription
                    : curr.Display.Description.ToQuotedStringOrNullLiteral();
            writer.WriteLine($"{curr.MemberValue} => {currResult},");
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
