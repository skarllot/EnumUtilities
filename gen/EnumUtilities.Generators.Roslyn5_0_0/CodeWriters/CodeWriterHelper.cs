using Raiqub.Generators.EnumUtilities.Models;

namespace Raiqub.Generators.EnumUtilities.CodeWriters;

public static class CodeWriterHelper
{
    public static string GetFileName(EnumToGenerate model, string generatorName)
    {
        if (model is { RootNamespace: not null, Namespace: not null } &&
            model.Namespace.Length >= model.RootNamespace.Length)
        {
            if (model.RootNamespace == model.Namespace)
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
}
