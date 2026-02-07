using System.Text;

namespace Raiqub.Generators.EnumUtilities.CodeWriters;

public interface ICodeWriter<in T>
{
    string GetFileName(T context);
    void Write(StringBuilder builder, T model);
}
