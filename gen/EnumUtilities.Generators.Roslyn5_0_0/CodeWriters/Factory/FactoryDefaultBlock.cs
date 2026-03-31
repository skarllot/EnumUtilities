using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Factory;

public sealed class FactoryDefaultBlock : ICodeWriterModule<EnumToGenerate>
{
    public IEnumerable<string> GetNamespacesImports(EnumToGenerate model) => [];

    public bool CanGenerateFor(EnumToGenerate model) =>
        (model.SelectedGenerators & SelectedGenerators.MainGenerator) != SelectedGenerators.None;

    public void Write(SourceTextWriter writer, EnumToGenerate model)
    {
        var parseDefinition = new EnumParseDefinition
        {
            XmlRefType = "Raiqub.Generators.EnumUtilities.Contracts.IEnumFactory{TEnum}",
            FacadeNameSuffix = "",
            CoreNameSuffix = "Name",
            KeySelector = static x => x.MemberName,
        };

        ParseFacadeWriter.Write(writer, model, parseDefinition);

        writer.WriteLine();
        TryParseInternalWriter.Write(writer, model, parseDefinition);
    }
}
