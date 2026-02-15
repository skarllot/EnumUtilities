using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.EnumInfo;

public static class EnumInfoDefaultBlock
{
    public static void Write(SourceTextWriter writer, EnumToGenerate model)
    {
        var hasMainGenerator =
            (model.SelectedGenerators & SelectedGenerators.MainGenerator) == SelectedGenerators.MainGenerator;

        if (hasMainGenerator)
        {
            EnumInfoNamesInternal.Write(
                writer,
                model,
                "Name",
                "members names",
                "name",
                "converting",
                x => x.MemberName
            );
        }

        if (hasMainGenerator && model.HasSerializationValue)
        {
            writer.WriteLine();
            EnumInfoNamesInternal.Write(
                writer,
                model,
                "SerializedValue",
                "serialized members values",
                "serialized value",
                "serializing",
                x => x.ResolvedSerializedValue
            );
        }

        if (hasMainGenerator && model.HasJsonProperty)
        {
            writer.WriteLine();
            EnumInfoNamesInternal.Write(
                writer,
                model,
                "JsonValue",
                "serialized members values",
                "serialized value",
                "serializing",
                x => x.ResolvedJsonValue
            );
        }
    }
}
