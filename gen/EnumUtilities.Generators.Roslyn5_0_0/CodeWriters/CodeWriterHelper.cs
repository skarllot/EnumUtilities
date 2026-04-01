using System.Reflection;
using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters;

public static class CodeWriterHelper
{
    private static AssemblyName CurrentAssemblyName { get; } = typeof(EnumFactoryWriter).Assembly.GetName();

    private static string GeneratedCodeAttributes
    {
        get =>
            field ??= $"""
                [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
                [global::System.CodeDom.Compiler.GeneratedCodeAttribute("{CurrentAssemblyName.Name}", "{CurrentAssemblyName.Version}")]
                """;
    }

    public static string GetFileName(EnumToGenerate model, string generatorName)
    {
        if (
            model is { RootNamespace: not null, Namespace: not null }
            && model.Namespace.Length >= model.RootNamespace.Length
        )
        {
            if (string.Equals(model.RootNamespace, model.Namespace, StringComparison.Ordinal))
            {
                return $"{model.Name}{generatorName}.g.cs";
            }

            var index = model.Namespace.IndexOf(model.RootNamespace, StringComparison.Ordinal);
            if (index == 0)
            {
                return $"{model.Namespace.AsSpan(model.RootNamespace.Length + 1)}.{model.Name}{generatorName}.g.cs";
            }
        }

        return $"{model.Namespace ?? "_"}.{model.Name}{generatorName}.g.cs";
    }

    public static void WriteGeneratedCodeAttributes(SourceTextWriter writer)
    {
        writer.WriteLine(GeneratedCodeAttributes);
    }
}
