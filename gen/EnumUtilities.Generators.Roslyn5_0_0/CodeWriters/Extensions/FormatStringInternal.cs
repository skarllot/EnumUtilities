using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Extensions;

public static class FormatStringInternal
{
    public static void Write(SourceTextWriter writer, EnumToGenerate model, EnumFormatDefinition formatDefinition)
    {
        switch (model.IsFlags, model.FlagsInfo?.HasFewCombinations, model.EnumGeneratorOptions?.DisableLookupTable)
        {
            case (true, true, not true):
                FormatSmallFlagsStringInternal.Write(writer, model, formatDefinition);
                break;
            case (true, _, _):
                FormatFlagsStringInternal.Write(writer, model, formatDefinition);
                break;
            case (false, _, _):
                FormatPlainStringInternal.Write(writer, model, formatDefinition);
                break;
        }
    }
}
