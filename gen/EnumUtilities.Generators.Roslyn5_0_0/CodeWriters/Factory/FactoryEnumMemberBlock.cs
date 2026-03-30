using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Factory;

public class FactoryEnumMemberBlock : ICodeWriterModule<EnumToGenerate>
{
    public IEnumerable<string> GetNamespacesImports(EnumToGenerate model) => [];

    public bool CanGenerateFor(EnumToGenerate model) =>
        (model.SelectedGenerators & SelectedGenerators.MainGenerator) != SelectedGenerators.None
        && model.HasSerializationValue;

    public void Write(SourceTextWriter writer, EnumToGenerate model)
    {
        var parseDefinition = new EnumParseDefinition
        {
            XmlRefType = "Raiqub.Generators.EnumUtilities.Contracts.IEnumFactoryEnumMember{TEnum}",
            FacadeNameSuffix = "FromEnumMemberValue",
            CoreNameSuffix = "EnumMemberValue",
            KeySelector = static x => x.ResolvedSerializedValue,
        };

        ParseFacadeWriter.Write(writer, model, parseDefinition);

        writer.WriteLine();
        TryParseInternalWriter.Write(writer, model, parseDefinition);
    }
}
