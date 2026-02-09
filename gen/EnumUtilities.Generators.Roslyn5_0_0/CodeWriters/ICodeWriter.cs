using System.Text;

namespace Raiqub.Generators.EnumUtilities.CodeWriters;

public interface ICodeWriter<in T>
{
    bool CanGenerateFor(T model);
    string GetFileName(T model);
    void Write(StringBuilder builder, T model);
}
