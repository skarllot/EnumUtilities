using System.Text;
using Microsoft.CodeAnalysis;

namespace Raiqub.Generators.EnumUtilities.Common;

public sealed class CodeWriterDispatcher<T>
{
    private const int DefaultStringBuilderCapacity = 1024;
    private readonly Func<StringBuilder, CodeWriterBase<T>>[] _codeWriterFactories;

    public CodeWriterDispatcher(params Func<StringBuilder, CodeWriterBase<T>>[] codeWriterFactories)
    {
        _codeWriterFactories = codeWriterFactories;
    }

    public void GenerateSources(IEnumerable<T> models, SourceProductionContext context)
    {
        var codeWriters = new CodeWriterBase<T>[_codeWriterFactories.Length];
        var sb = new StringBuilder(DefaultStringBuilderCapacity);

        for (int i = 0; i < _codeWriterFactories.Length; i++)
        {
            codeWriters[i] = _codeWriterFactories[i](sb);
        }

        foreach (var model in models)
        {
            foreach (var codeWriter in codeWriters)
            {
                context.CancellationToken.ThrowIfCancellationRequested();
                codeWriter.GenerateCompilationSource(context, model);
            }
        }
    }
}
