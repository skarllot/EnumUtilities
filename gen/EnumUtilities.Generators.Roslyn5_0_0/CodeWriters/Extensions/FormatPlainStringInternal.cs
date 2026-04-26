using Raiqub.Generators.EnumUtilities.Common;
using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

public static class FormatPlainStringInternal
{
    public static void Write(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type
    )
    {
        WriteTryGetLengthInlined(writer, model, keySelector, type);
        writer.WriteLine();
        WriteGetInlined(writer, model, keySelector, type);
    }

    private static void WriteTryGetLengthInlined(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type
    )
    {
        writer.WriteLine(
            $$"""
            private static bool TryGet{{type}}LengthInlined({{model.UnderlyingType}} value, out int length)
            {
            """
        );
        writer.PushIndent();

        writer.WriteLine(
            """
            switch (value)
            {
            """
        );
        writer.PushIndent();

        if (!model.HasZeroMember)
        {
            writer.WriteLine("case 0: length = 1; return true;");
        }

        foreach (var curr in model.UniqueValues)
        {
            writer.WriteLine($"case {curr.MemberValue}: length = {keySelector(curr).Length}; return true;");
        }

        writer.WriteLine("default: length = 0; return false;");

        writer.PopIndent(levels: 2);
        writer.WriteLine(
            """
                }
            }
            """
        );
    }

    private static void WriteGetInlined(
        SourceTextWriter writer,
        EnumToGenerate model,
        Func<EnumValue, string> keySelector,
        string type
    )
    {
        writer.WriteLine(
            $$"""
            private static string? Get{{type}}Inlined({{model.UnderlyingType}} value)
            {
                return value switch
                {
            """
        );

        writer.PushIndent(levels: 2);
        if (!model.HasZeroMember)
        {
            writer.WriteLine("""0 => "0",""");
        }

        foreach (var curr in model.UniqueValues)
        {
            writer.WriteLine($"{curr.MemberValue} => {keySelector(curr).ToQuotedStringLiteral()},");
        }

        writer.WriteLine("_ => null");

        writer.PopIndent(levels: 2);
        writer.WriteLine(
            """
                };
            }
            """
        );
    }
}
