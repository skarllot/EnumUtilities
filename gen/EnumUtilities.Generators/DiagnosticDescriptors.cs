using Microsoft.CodeAnalysis;

namespace Raiqub.Generators.EnumUtilities;

internal static class DiagnosticDescriptors
{
    public static readonly DiagnosticDescriptor UnexpectedErrorParsingCode = new(
        "REU0001",
        "Unexpected error during source code parsing",
        "Unexpected error occurred parsing source code: {0}",
        "Usage",
        DiagnosticSeverity.Error,
        true);

    public static readonly DiagnosticDescriptor UnexpectedErrorGenerating = new(
        "REU0002",
        "Unexpected error during generation",
        "Unexpected error occurred during code generation: {0}",
        "Usage",
        DiagnosticSeverity.Error,
        true);
}
