using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Factory;

public sealed class FactoryJsonBlock : ICodeWriterModule<EnumToGenerate>
{
    public IEnumerable<string> GetNamespacesImports(EnumToGenerate model) => [];

    public bool CanGenerateFor(EnumToGenerate model) =>
        model.HasJsonProperty
        || (model.SelectedGenerators & SelectedGenerators.JsonConverter) != SelectedGenerators.None;

    public void Write(SourceTextWriter writer, EnumToGenerate model)
    {
        var parseDefinition = new EnumParseDefinition
        {
            XmlRefType = "Raiqub.Generators.EnumUtilities.Contracts.IEnumFactoryJson{TEnum}",
            FacadeNameSuffix = "JsonString",
            CoreNameSuffix = "JsonString",
            ParameterName = "value",
            KeySelector = static x => x.ResolvedJsonValue,
            AllowNumbers = false,
        };

        ParseFacadeWriter.Write(writer, model, parseDefinition);

        writer.WriteLine();
        TryParseInternalWriter.Write(writer, model, parseDefinition);
    }
}
