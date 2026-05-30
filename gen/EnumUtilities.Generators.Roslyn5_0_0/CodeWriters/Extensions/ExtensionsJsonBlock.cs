using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Extensions;

public sealed class ExtensionsJsonBlock : ICodeWriterModule<EnumToGenerate>
{
    public IEnumerable<string> GetNamespacesImports(EnumToGenerate model) => [];

    public bool CanGenerateFor(EnumToGenerate model) =>
        (model.SelectedGenerators & SelectedGenerators.JsonConverter) != SelectedGenerators.None
        || model.HasJsonProperty;

    public void Write(SourceTextWriter writer, EnumToGenerate model)
    {
        FormatStringInternal.Write(
            writer: writer,
            model: model,
            new EnumFormatDefinition
            {
                XmlRefType = "Raiqub.Generators.EnumUtilities.Contracts.IEnumExtensions{TEnum}",
                ToStringMethodName = "ToJsonString",
                GetStringLengthMethodName = "GetJsonStringLength",
                Type = "JsonString",
                KeySelector = static x => x.ResolvedJsonValue,
                AllowNumbers = false,
            }
        );
    }
}
