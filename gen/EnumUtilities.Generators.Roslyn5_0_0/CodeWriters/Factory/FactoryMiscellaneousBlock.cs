using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Factory;

public class FactoryMiscellaneousBlock : ICodeWriterModule<EnumToGenerate>
{
    public IEnumerable<string> GetNamespacesImports(EnumToGenerate model) => [];

    public bool CanGenerateFor(EnumToGenerate model) =>
        (model.SelectedGenerators & SelectedGenerators.MainGenerator) != SelectedGenerators.None;

    public void Write(SourceTextWriter writer, EnumToGenerate model)
    {
        WriteGetValues(writer, model);
        writer.WriteLine();
        WriteGetNames(writer, model);
    }

    private static void WriteGetValues(SourceTextWriter writer, EnumToGenerate model)
    {
        writer.WriteLine(
            $$"""
            /// <summary>Retrieves an array of the values of the constants in the {{model.Name}} enumeration.</summary>
            /// <returns>An array that contains the values of the constants in {{model.Name}}.</returns>
            public static {{model.RefName}}[] GetValues()
            {
                return new[]
                {
            """
        );
        writer.PushIndent(levels: 2);
        foreach (var curr in model.UniqueValues)
        {
            writer.WriteLine($"({model.RefName})({curr.MemberValue}),");
        }
        writer.PopIndent(levels: 2);
        writer.WriteLine(
            """
                };
            }
            """
        );
    }

    private static void WriteGetNames(SourceTextWriter writer, EnumToGenerate model)
    {
        writer.WriteLine(
            $$"""
            /// <summary>Retrieves an array of the names of the constants in {{model.Name}} enumeration.</summary>
            /// <returns>A string array of the names of the constants in {{model.Name}}.</returns>
            public static string[] GetNames()
            {
                return new[]
                {
            """
        );
        writer.PushIndent(levels: 2);
        foreach (var curr in model.Values)
        {
            writer.WriteLine($"\"{curr.MemberName}\",");
        }
        writer.PopIndent(levels: 2);
        writer.WriteLine(
            """
                };
            }
            """
        );
    }
}
