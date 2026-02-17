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
}
