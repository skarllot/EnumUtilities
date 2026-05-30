using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Extensions;

public sealed class ExtensionsEnumMemberBlock : ICodeWriterModule<EnumToGenerate>
{
    public IEnumerable<string> GetNamespacesImports(EnumToGenerate model) => [];

    public bool CanGenerateFor(EnumToGenerate model) =>
        (model.SelectedGenerators & SelectedGenerators.MainGenerator) != SelectedGenerators.None
        && model.HasSerializationValue;

    public void Write(SourceTextWriter writer, EnumToGenerate model)
    {
        FormatStringInternal.Write(
            writer: writer,
            model: model,
            new EnumFormatDefinition
            {
                XmlRefType = "Raiqub.Generators.EnumUtilities.Contracts.IEnumExtensions{TEnum}",
                ToStringMethodName = "ToEnumMemberValue",
                GetStringLengthMethodName = "GetEnumMemberValueStringLength",
                Type = "EnumMemberValue",
                KeySelector = static x => x.ResolvedSerializedValue,
            }
        );
    }
}
