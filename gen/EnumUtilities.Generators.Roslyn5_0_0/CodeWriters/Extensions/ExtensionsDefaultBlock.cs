using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Extensions;

public sealed class ExtensionsDefaultBlock : ICodeWriterModule<EnumToGenerate>
{
    public IEnumerable<string> GetNamespacesImports(EnumToGenerate model) => [];

    public bool CanGenerateFor(EnumToGenerate model) =>
        (model.SelectedGenerators & SelectedGenerators.MainGenerator) != SelectedGenerators.None;

    public void Write(SourceTextWriter writer, EnumToGenerate model)
    {
        FormatStringInternal.Write(
            writer: writer,
            model: model,
            new EnumFormatDefinition
            {
                XmlRefType = "Raiqub.Generators.EnumUtilities.Contracts.IEnumExtensions{TEnum}",
                ToStringMethodName = "ToStringFast",
                GetStringLengthMethodName = "GetStringLength",
                Type = "Name",
                KeySelector = static x => x.MemberName,
            }
        );

        if (model.IsFlags)
        {
            writer.WriteLine();
            WriteHasFlagFast(writer, model);
        }

        writer.WriteLine();
        WriteIsDefined(writer, model);
    }

    private static void WriteHasFlagFast(SourceTextWriter writer, EnumToGenerate model)
    {
        writer.WriteLine(
            $$"""
            /// <summary>Determines whether one or more bit fields are set in the current instance.</summary>
            /// <param name="flag">An enumeration value.</param>
            /// <returns><see langword="true"/> if the bit field or bit fields that are set in flag are also set in the current instance; otherwise, <see langword="false"/>.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool HasFlagFast(this {{model.RefName}} value, {{model.RefName}} flag)
            {
                return (value & flag) == flag;
            }
            """
        );
    }

    private static void WriteIsDefined(SourceTextWriter writer, EnumToGenerate model)
    {
        writer.WriteLine(
            $$"""
            /// <summary>Returns a boolean telling whether the value of this instance exists in the enumeration.</summary>
            /// <returns><c>true</c> if the value of this instance exists in the enumeration; <c>false</c> otherwise.</returns>
            public static bool IsDefined(this {{model.RefName}} value)
            {
                return ({{model.UnderlyingType}})value switch
                {
            """
        );

        writer.PushIndent(levels: 2);
        foreach (var curr in model.UniqueValues)
        {
            writer.WriteLine($"{curr.MemberValue} => true,");
        }

        writer.PopIndent(levels: 2);
        writer.WriteLine(
            """
                    _ => false
                };
            }
            """
        );
    }
}
