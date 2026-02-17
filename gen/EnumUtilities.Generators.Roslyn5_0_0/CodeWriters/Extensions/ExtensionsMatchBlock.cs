using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Extensions;

public sealed class ExtensionsMatchBlock : ICodeWriterModule<EnumToGenerate>
{
    public bool CanGenerateFor(EnumToGenerate model) =>
        (model.SelectedGenerators & SelectedGenerators.MainGenerator) != 0 && !model.Values.IsEmpty && !model.IsFlags;

    public void Write(SourceTextWriter writer, EnumToGenerate model)
    {
        WriteMatch(writer, model);
        writer.WriteLine();
        WriteMatchWithDelegate(writer, model);
    }

    private static void WriteMatch(SourceTextWriter writer, EnumToGenerate model)
    {
        writer.WriteLine(
            $"""
            /// <summary>
            /// Provides pattern matching functionality for the <see cref="{model.RefName}"/> enum by returning the corresponding value based on the enum value.
            /// </summary>
            /// <typeparam name="TResult">The type of the result to return for each member match.</typeparam>
            /// <param name="value">The <see cref="{model.RefName}"/> enum value to match against.</param>
            """
        );

        foreach (var curr in model.UniqueValues)
        {
            writer.WriteLine(
                $"""
                /// <param name="{curr.MemberName}">The value to return when the enum value is {curr.MemberName}.</param>
                """
            );
        }

        writer.Write(
            $"""
            /// <returns>The corresponding result value based on the enum value.</returns>
            /// <exception cref="ArgumentOutOfRangeException">Thrown when the enum value does not match any of the expected member values.</exception>
            public static TResult Match<TResult>(
                this {model.RefName} value
            """
        );

        writer.PushIndent();
        foreach (var curr in model.UniqueValues)
        {
            writer.WriteLine(',');
            writer.Write($"TResult {curr.MemberName}");
        }

        writer.WriteLine(')');
        writer.PopIndent();

        writer.WriteLine(
            $$"""
            {
                return ({{model.UnderlyingType}})value switch
                {
            """
        );

        writer.PushIndent(levels: 2);
        foreach (var curr in model.UniqueValues)
        {
            writer.WriteLine($"{curr.MemberValue} => {curr.MemberName},");
        }
        writer.WriteLine("_ => throw new ArgumentOutOfRangeException(nameof(value), value, null)");
        writer.PopIndent(levels: 2);

        writer.WriteLine(
            """
                };
            }
            """
        );
    }

    private static void WriteMatchWithDelegate(SourceTextWriter writer, EnumToGenerate model)
    {
        writer.WriteLine(
            $"""
            /// <summary>
            /// Provides pattern matching functionality for the <see cref="{model.RefName}"/> enum by executing the corresponding function based on the enum value.
            /// </summary>
            /// <typeparam name="TResult">The type of the result to return from the executed function.</typeparam>
            /// <param name="value">The <see cref="{model.RefName}"/> enum value to match against.</param>
            """
        );

        foreach (var curr in model.UniqueValues)
        {
            writer.WriteLine(
                $"""
                /// <param name="{curr.MemberName}">The function to execute when the enum value is {curr.MemberName}.</param>
                """
            );
        }

        writer.Write(
            $"""
            /// <returns>The result of executing the corresponding function based on the enum value.</returns>
            /// <exception cref="ArgumentOutOfRangeException">Thrown when the enum value does not match any of the expected <see cref="{model.RefName}"/> values.</exception>
            public static TResult Match<TResult>(
                this {model.RefName} value
            """
        );

        writer.PushIndent();
        foreach (var curr in model.UniqueValues)
        {
            writer.WriteLine(',');
            writer.Write($"Func<{model.RefName}, TResult> {curr.MemberName}");
        }

        writer.WriteLine(')');
        writer.PopIndent();

        writer.WriteLine(
            $$"""
            {
                return ({{model.UnderlyingType}})value switch
                {
            """
        );

        writer.PushIndent(levels: 2);
        foreach (var curr in model.UniqueValues)
        {
            writer.WriteLine($"{curr.MemberValue} => {curr.MemberName}(({model.RefName})value),");
        }
        writer.WriteLine("_ => throw new ArgumentOutOfRangeException(nameof(value), value, null)");
        writer.PopIndent(levels: 2);

        writer.WriteLine(
            """
                };
            }
            """
        );
    }
}
