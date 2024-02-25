using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Raiqub.Generators.EnumUtilities.Common;

/// <summary>Represents the base class for code writers.</summary>
public abstract class CodeWriterBase
{
    private const char IndentationChar = ' ';
    private const int CharsPerIndentation = 4;

    private readonly StringBuilder _builder;
    private readonly int _charsPerIndentation;
    private int _indentation;

    /// <summary>
    /// Initializes a new instance of the CodeWriterBase class with a StringBuilder.
    /// </summary>
    /// <param name="builder">The StringBuilder object used for building the template.</param>
    /// <param name="charsPerIndentation">The number of characters per indentation level.</param>
    protected CodeWriterBase(StringBuilder builder, int charsPerIndentation = CharsPerIndentation)
    {
        _builder = builder;
        _charsPerIndentation = charsPerIndentation;
    }

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
        ClearIndent();
        context.AddSource(GetFileName(), SourceText.From(TransformText(), Encoding.UTF8));
    }

    /// <summary>Write text directly into the generated output.</summary>
    /// <param name="textToAppend">The text to be appended to the generated output.</param>
    protected void Write(string? textToAppend)
    {
        Write(textToAppend.AsSpan());
    }

    protected void Write(int number)
    {
        if (_indentation == 0)
        {
            _builder.Append(number);
            return;
        }

        bool endsWithNewline = _builder.Length > 0 && _builder[^1] == '\n';
        if (endsWithNewline)
            WriteIndentation();

        _builder.Append(number);
    }

    protected void Write(ReadOnlySpan<char> textToAppend)
    {
        if (textToAppend.IsEmpty)
        {
            return;
        }

        if (_indentation == 0)
        {
            _builder.Append(textToAppend);
            return;
        }

        bool endsWithNewline = _builder.Length > 0 && _builder[^1] == '\n';
        bool isFinalLine;
        var remainingText = textToAppend;
        while (true)
        {
            var nextLine = GetNextLine(ref remainingText, out isFinalLine);

            if (endsWithNewline && nextLine.Length > 0)
                WriteIndentation();

            _builder.Append(nextLine);

            if (isFinalLine)
                return;

            _builder.AppendLine();
            endsWithNewline = true;
        }
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

    /// <summary>Appends a new line into the generated output.</summary>
    public void WriteLine()
    {
        _builder.AppendLine();
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

    /// <summary>Increase the indent.</summary>
    protected void PushIndent()
    {
        _indentation++;
    }

    /// <summary>Remove the last indent that was added with <see cref="PushIndent"/>.</summary>
    protected void PopIndent()
    {
        if (_indentation <= 0)
        {
            Throw();
            static void Throw() => throw new InvalidOperationException("Indentation is already zeroed");
        }

        _indentation--;
    }

    /// <summary>Remove any indentation.</summary>
    protected void ClearIndent()
    {
        _indentation = 0;
    }

    private void WriteIndentation()
    {
        _builder.Append(IndentationChar, _charsPerIndentation * _indentation);
    }

    private static ReadOnlySpan<char> GetNextLine(ref ReadOnlySpan<char> remainingText, out bool isFinalLine)
    {
        if (remainingText.IsEmpty)
        {
            isFinalLine = true;
            return default;
        }

        ReadOnlySpan<char> next;
        ReadOnlySpan<char> rest;

        int lineLength = remainingText.IndexOf('\n');
        if (lineLength == -1)
        {
            lineLength = remainingText.Length;
            isFinalLine = true;
            rest = default;
        }
        else
        {
            rest = remainingText.Slice(lineLength + 1);
            isFinalLine = false;
        }

        if ((uint)lineLength > 0 && remainingText[lineLength - 1] == '\r')
        {
            lineLength--;
        }

        next = remainingText.Slice(0, lineLength);
        remainingText = rest;
        return next;
    }

    protected readonly struct None;

    protected sealed class ToStringInstanceHelper
    {
        public static readonly ToStringInstanceHelper Instance = new();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string? ToStringWithCulture(string? value) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ToStringWithCulture(int number) => number;

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
        private readonly CodeWriterBase _codeWriter;

        public WriteInterpolatedStringHandler(int literalLength, int formattedCount, CodeWriterBase codeWriter)
        {
            _codeWriter = codeWriter;
        }

        public void AppendLiteral(string s)
        {
            _codeWriter.Write(s);
        }

        public void AppendFormatted<T>(T value)
        {
            if (value is not null)
                _codeWriter.Write(value.ToString());
        }

        public void AppendFormatted(string? value)
        {
            if (value is not null)
                _codeWriter.Write(value);
        }

        public void AppendFormatted(int value)
        {
            _codeWriter.Write(value);
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
        if (!CanGenerateFor(model))
            return;

        Model = model;
        base.GenerateCompilationSource(context);
        Model = default!;
    }

    protected virtual bool CanGenerateFor(T model) => true;
}
