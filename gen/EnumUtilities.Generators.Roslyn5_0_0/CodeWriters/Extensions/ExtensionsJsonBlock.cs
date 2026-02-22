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
        var internalStringMethodName = model.IsFlags ? "FormatFlagJsonStrings" : "GetJsonStringInlined";
        var internalLengthMethodName = model.IsFlags ? "FormatFlagJsonStringsLength" : "GetJsonStringLengthInlined";

        writer.WriteLine(
            $$"""
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static string? ToJsonString(this {{model.RefName}} value)
            {
                return {{internalStringMethodName}}(({{model.UnderlyingType}})value);
            }
            """
        );

        writer.WriteLine();
        writer.WriteLine(
            $$"""
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static int? GetJsonStringLength(this {{model.RefName}} value)
            {
                return {{internalLengthMethodName}}(({{model.UnderlyingType}})value);
            }
            """
        );

        writer.WriteLine();
        FormatStringInternal.Write(writer, model, static x => x.ResolvedJsonValue, "JsonString");
    }
}
