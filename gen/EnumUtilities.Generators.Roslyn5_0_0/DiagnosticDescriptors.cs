using Microsoft.CodeAnalysis;

namespace Raiqub.Generators.EnumUtilities;

internal static class DiagnosticDescriptors
{
    public static readonly DiagnosticDescriptor UnexpectedErrorParsingCode = new(
        id: "REU0001",
        title: "Unexpected error during source code parsing",
        messageFormat: "Unexpected error occurred parsing source code: {0}",
        category: "Usage",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true
    );

    public static readonly DiagnosticDescriptor UnexpectedErrorGenerating = new(
        id: "REU0002",
        title: "Unexpected error during generation",
        messageFormat: "Unexpected error occurred during code generation: {0}",
        category: "Usage",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true
    );
}
