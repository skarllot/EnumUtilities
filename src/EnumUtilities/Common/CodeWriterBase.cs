using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Raiqub.Generators.EnumUtilities.Common;

/// <summary>Represents the base class for code writers.</summary>
public abstract class CodeWriterBase
{
    private readonly StringBuilder _builder;

    /// <summary>
    /// Initializes a new instance of the <see cref="CodeWriterBase"/> class with a <see cref="StringBuilder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="StringBuilder"/> object used for building the template.</param>
    protected CodeWriterBase(StringBuilder builder) => _builder = builder;

    /// <summary>Gets the name of the current assembly.</summary>
    protected static AssemblyName CurrentAssemblyName { get; } = typeof(CodeWriterBase).Assembly.GetName();

    /// <summary>Gets or sets the string builder that generation-time code is using to assemble generated output.</summary>
    protected StringBuilder GenerationEnvironment => _builder;

    protected ToStringInstanceHelper ToStringHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ToStringInstanceHelper.Instance;
    }

    /// <summary>Retrieves the name of the file for the code of current code writer state.</summary>
    /// <returns>The name of the file.</returns>
    public abstract string GetFileName();

    /// <summary>Create the source text from current code writer state.</summary>
    /// <returns>The transformed text.</returns>
    public abstract string TransformText();

    /// <summary>Adds a source to the compilation using the provided context.</summary>
    /// <param name="context">The source production context.</param>
    /// <remarks>
    /// This method takes a source production context and adds the source with the filename and transformed text
    /// to the compilation using the <see cref="SourceProductionContext.AddSource(string, SourceText)"/> method.
    /// </remarks>
    public void GenerateCompilationSource(SourceProductionContext context)
    {
        _builder.Clear();
        context.AddSource(GetFileName(), SourceText.From(TransformText(), Encoding.UTF8));
    }

    /// <summary>Write text directly into the generated output.</summary>
    /// <param name="textToAppend">The text to be appended to the generated output.</param>
    protected void Write(string? textToAppend)
    {
        if (string.IsNullOrEmpty(textToAppend))
            return;

        _builder.Append(textToAppend);
    }

    /// <summary>Writes the specified interpolated string directly into the generated output.</summary>
    /// <param name="handler">The interpolated string to append.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected void Write([InterpolatedStringHandlerArgument("")] ref WriteInterpolatedStringHandler handler)
    {
        // Text is written using interpolated string handler by compiler generated code
    }

    /// <summary>Does nothing.</summary>
    /// <param name="none">An instance of the None struct.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected void Write(None none)
    {
        // Text was already been written using interpolated string handler
        // Nothing to do
    }

    /// <summary>Write text directly into the generated output and appends a new line.</summary>
    /// <param name="textToAppend">The text to be written.</param>
    public void WriteLine(string textToAppend)
    {
        Write(textToAppend);
        _builder.AppendLine();
    }

    /// <summary>Writes the specified interpolated string directly into the generated output and appends a new line.</summary>
    /// <param name="handler">The interpolated string to append.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected void WriteLine([InterpolatedStringHandlerArgument("")] ref WriteInterpolatedStringHandler handler)
    {
        // Text is written using interpolated string handler by compiler generated code
        _builder.AppendLine();
    }

    /// <summary>Append text directly into the generated output for expression control blocks.</summary>
    /// <param name="textToAppend">The text to be appended to the generated output.</param>
    protected None Append(string? textToAppend)
    {
        Write(textToAppend);
        return default;
    }

    /// <summary>Append the specified interpolated string directly into the generated output for expression control blocks.</summary>
    /// <param name="handler">The interpolated string to append.</param>
    protected None Append([InterpolatedStringHandlerArgument("")] ref WriteInterpolatedStringHandler handler)
    {
        // Text is written using interpolated string handler by compiler generated code
        return default;
    }

    protected readonly struct None;

    protected sealed class ToStringInstanceHelper
    {
        public static readonly ToStringInstanceHelper Instance = new();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string? ToStringWithCulture(string? value) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public None ToStringWithCulture(None none)
        {
            // Text was already been written using interpolated string handler
            return none;
        }
    }

    [InterpolatedStringHandler]
    protected readonly struct WriteInterpolatedStringHandler
    {
        private readonly AppendInterpolatedStringHandler _handler;

        public WriteInterpolatedStringHandler(int literalLength, int formattedCount, CodeWriterBase codeWriter)
        {
            _handler = new AppendInterpolatedStringHandler(literalLength, formattedCount, codeWriter._builder);
        }

        public void AppendLiteral(string s)
        {
            _handler.AppendLiteral(s);
        }

        public void AppendFormatted<T>(T value)
        {
            _handler.AppendFormatted(value);
        }

        public void AppendFormatted<T>(T value, string? format)
        {
            _handler.AppendFormatted(value, format);
        }

        public void AppendFormatted<T>(T value, int alignment)
        {
            _handler.AppendFormatted(value, alignment);
        }

        public void AppendFormatted<T>(T value, int alignment, string? format)
        {
            _handler.AppendFormatted(value, alignment, format);
        }

        public void AppendFormatted(ReadOnlySpan<char> value)
        {
            _handler.AppendFormatted(value);
        }

        public void AppendFormatted(ReadOnlySpan<char> value, int alignment = 0, string? format = null)
        {
            _handler.AppendFormatted(value, alignment, format);
        }

        public void AppendFormatted(string? value)
        {
            _handler.AppendFormatted(value);
        }

        public void AppendFormatted(string? value, int alignment = 0, string? format = null)
        {
            _handler.AppendFormatted(value, alignment, format);
        }

        public void AppendFormatted(object? value, int alignment = 0, string? format = null)
        {
            _handler.AppendFormatted(value, alignment, format);
        }
    }
}

public abstract class CodeWriterBase<T> : CodeWriterBase
{
    protected CodeWriterBase(StringBuilder builder) : base(builder)
    {
    }

    public T Model { get; protected set; } = default!;

    public void GenerateCompilationSource(SourceProductionContext context, T model)
    {
        Model = model;
        base.GenerateCompilationSource(context);
        Model = default!;
    }
}
