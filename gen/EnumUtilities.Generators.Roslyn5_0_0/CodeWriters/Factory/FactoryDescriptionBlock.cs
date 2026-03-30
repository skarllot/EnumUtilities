using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Factory;

public sealed class FactoryDescriptionBlock : ICodeWriterModule<EnumToGenerate>
{
    public IEnumerable<string> GetNamespacesImports(EnumToGenerate model) => [];

    public bool CanGenerateFor(EnumToGenerate model) =>
        (model.SelectedGenerators & SelectedGenerators.MainGenerator) != SelectedGenerators.None
        && model.HasDescription;

    public void Write(SourceTextWriter writer, EnumToGenerate model)
    {
        var parseDefinition = new EnumParseDefinition
        {
            XmlRefType = "Raiqub.Generators.EnumUtilities.Contracts.IEnumFactoryDescription{TEnum}",
            FacadeNameSuffix = "FromDescription",
            CoreNameSuffix = "Description",
            ParameterName = "description",
            KeySelector = static x => x.Description,
            ActionName = "Create",
            AllowNumbers = false,
            AllowEmpty = true,
            UseStringComparison = true,
        };

        ParseFacadeWriter.Write(writer, model, parseDefinition);

        writer.WriteLine();
        TryParseInternalWriter.Write(writer, model, parseDefinition);
    }
}
