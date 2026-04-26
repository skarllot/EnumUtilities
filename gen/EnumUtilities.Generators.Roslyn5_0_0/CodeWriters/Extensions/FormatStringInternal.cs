using Raiqub.Generators.EnumUtilities.IntegrationTests.Models;
using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Extensions;

public static class FormatStringInternal
{
    public static void Write(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type
    )
    {
        switch (model.IsFlags, model.FlagsInfo?.HasFewCombinations)
        {
            case (true, true):
                FormatSmallFlagsStringInternal.Write(writer, model, keySelector, type);
                break;
            case (true, _):
                FormatFlagsStringInternal.Write(writer, model, keySelector, type);
                break;
            case (false, _):
                FormatPlainStringInternal.Write(writer, model, keySelector, type);
                break;
        }
    }
}
