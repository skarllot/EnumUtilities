using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Extensions;

public sealed class ExtensionsEnumMemberBlock : ICodeWriterModule<EnumToGenerate>
{
    public bool CanGenerateFor(EnumToGenerate model) =>
        (model.SelectedGenerators & SelectedGenerators.MainGenerator) != 0 && model.HasSerializationValue;

    public void Write(SourceTextWriter writer, EnumToGenerate model)
    {
        WriteToEnumMemberValue(writer, model);
        writer.WriteLine();
        WriteGetEnumMemberValueStringLength(writer, model);
        writer.WriteLine();
        FormatStringInternal.Write(writer, model, static x => x.ResolvedSerializedValue, "EnumMemberValue");
    }

    private static void WriteToEnumMemberValue(SourceTextWriter writer, EnumToGenerate model)
    {
        writer.WriteLine(
            $$"""
            public static string ToEnumMemberValue(this {{model.RefName}} value)
            {
                return {{(
                model.IsFlags ? "FormatFlagEnumMemberValues" : "GetEnumMemberValueInlined"
            )}}(({{model.UnderlyingType}})value)
                    ?? (({{model.UnderlyingType}})value).ToString();
            }
            """
        );
    }

    private static void WriteGetEnumMemberValueStringLength(SourceTextWriter writer, EnumToGenerate model)
    {
        writer.WriteLine(
            $$"""
            public static int GetEnumMemberValueStringLength(this {{model.RefName}} value)
            {
                return {{(
                model.IsFlags ? "FormatFlagEnumMemberValuesLength" : "GetEnumMemberValueLengthInlined"
            )}}(({{model.UnderlyingType}})value)
                    ?? EnumNumericFormatter.GetStringLength(({{model.UnderlyingType}})value);
            }
            """
        );
    }
}
