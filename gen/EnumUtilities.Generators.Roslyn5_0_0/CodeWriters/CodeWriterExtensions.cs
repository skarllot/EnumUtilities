using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Raiqub.Generators.EnumUtilities.CodeWriters;

public static class CodeWriterExtensions
{
    public static void GenerateCompilationSource<T>(
        this ICodeWriter<T> writer,
        SourceProductionContext context,
        StringBuilder builder,
        T model
    )
    {
        if (!writer.CanGenerateFor(model))
            return;

        builder.Clear();
        writer.Write(builder, model);
        context.AddSource(writer.GetFileName(model), SourceText.From(builder.ToString(), Encoding.UTF8));
    }
}
