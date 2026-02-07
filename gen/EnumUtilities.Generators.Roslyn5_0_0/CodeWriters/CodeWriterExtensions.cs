using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Raiqub.Generators.EnumUtilities.CodeWriters;

public static class CodeWriterExtensions
{
    public static void GenerateCompilationSource<T>(
        this ICodeWriter<T> writer,
        SourceProductionContext sourceContext,
        StringBuilder builder,
        T context
    )
    {
        builder.Clear();
        writer.Write(builder, context);
        sourceContext.AddSource(writer.GetFileName(context), SourceText.From(builder.ToString(), Encoding.UTF8));
    }
}
