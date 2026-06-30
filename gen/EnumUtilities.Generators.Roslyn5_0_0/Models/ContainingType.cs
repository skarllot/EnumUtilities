using Microsoft.CodeAnalysis;

namespace Raiqub.Generators.EnumUtilities.Models;

public sealed record ContainingType(string Kind, bool IsStatic, string Name)
{
    public static ContainingType FromSymbol(INamedTypeSymbol typeSymbol)
    {
        return new ContainingType(
            typeSymbol.IsRecord ? "record"
                : typeSymbol.IsReferenceType ? "class"
                : typeSymbol.IsValueType ? "struct"
                : "unknown",
            typeSymbol.IsStatic,
            typeSymbol.Name
        );
    }
}
