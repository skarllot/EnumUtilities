using System.Text;
using Raiqub.Generators.EnumUtilities.Models;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.EnumInfo;

public static class EnumInfoDefaultBlock
{
    public static void Write(StringBuilder builder, EnumToGenerate model)
    {
        var hasMainGenerator =
            (model.SelectedGenerators & SelectedGenerators.MainGenerator) == SelectedGenerators.MainGenerator;

        if (hasMainGenerator)
        {
            EnumInfoNamesInternal.Write(
                builder,
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
            builder.Append('\n');
            EnumInfoNamesInternal.Write(
                builder,
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
            builder.Append('\n');
            EnumInfoNamesInternal.Write(
                builder,
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
