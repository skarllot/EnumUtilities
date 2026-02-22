using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters;

public static class CodeWriterExtensions
{
    public static void WriteAll<T>(
        this SourceTextWriter writer,
        IEnumerable<ICodeWriterModule<T>> modules,
        T model,
        Action<SourceTextWriter>? separator = null
    )
    {
        var isFirst = true;
        foreach (var module in modules)
        {
            if (!module.CanGenerateFor(model))
            {
                continue;
            }

            if (!isFirst)
            {
                separator?.Invoke(writer);
            }

            module.Write(writer, model);
            isFirst = false;
        }
    }

    public static void WriteNamespaceImports<T>(
        this SourceTextWriter writer,
        IEnumerable<ICodeWriterModule<T>> modules,
        T model,
        bool sortSystemDirectivesFirst = true,
        IEnumerable<string>? defaultImports = null
    )
    {
        var all = modules
            .SelectMany(m => m.CanGenerateFor(model) ? m.GetNamespacesImports(model) : [])
            .Concat(defaultImports ?? [])
            .Distinct(StringComparer.Ordinal);

        var sorted = sortSystemDirectivesFirst
            ? all.OrderBy(x =>
                    string.Equals(x, "System", StringComparison.Ordinal)
                    || x.StartsWith("System.", StringComparison.Ordinal)
                        ? 0
                        : 1
                )
                .ThenBy(x => x, StringComparer.Ordinal)
            : all.OrderBy(x => x, StringComparer.Ordinal);

        foreach (var ns in sorted)
        {
            writer.WriteLine($"using {ns};");
        }
    }
}
