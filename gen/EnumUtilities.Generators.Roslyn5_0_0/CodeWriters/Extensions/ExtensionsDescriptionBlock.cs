using Raiqub.Generators.EnumUtilities.Common;
using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Extensions;

public sealed class ExtensionsDescriptionBlock : ICodeWriterModule<EnumToGenerate>
{
    public bool CanGenerateFor(EnumToGenerate model) =>
        (model.SelectedGenerators & SelectedGenerators.MainGenerator) != 0 && model.HasDescription;

    public void Write(SourceTextWriter writer, EnumToGenerate model)
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
        foreach (var curr in model.UniqueValues)
        {
            if (curr.Description == null)
            {
                continue;
            }

            writer.WriteLine($"{curr.MemberValue} => {curr.Description.ToQuotedStringOrNullLiteral()},");
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
