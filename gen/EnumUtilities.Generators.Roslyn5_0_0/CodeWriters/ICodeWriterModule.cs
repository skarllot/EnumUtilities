using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters;

public interface ICodeWriterModule<in T>
{
    /// <summary>
    /// Determines whether code should be generated for the specified model.
    /// </summary>
    /// <param name="model">The model to evaluate.</param>
    /// <returns><see langword="true"/> if code should be generated for the model; otherwise, <see langword="false"/>.</returns>
    bool CanGenerateFor(T model);

    /// <summary>
    /// Writes the source code to the specified writer using the provided model.
    /// </summary>
    /// <param name="writer">The writer to output the generated source code to.</param>
    /// <param name="model">The model containing the data for code generation.</param>
    void Write(SourceTextWriter writer, T model);
}
