using Microsoft.CodeAnalysis;
using Raiqub.Generators.EnumUtilities.Common;

namespace Raiqub.Generators.EnumUtilities.Models;

public sealed record EnumToGenerate(string Namespace, string Name, string UnderlyingType, List<EnumValue> Values)
{
    public IEnumerable<EnumValue> UniqueValues =>
        Values.DistinctBy(static it => it.MemberValue, StringComparer.Ordinal);

    public bool HasSerializationValue =>
        Values.Exists(static it => it.SerializationValue != null);

    public bool HasDescription =>
        Values.Exists(static it => it.Description != null);

    public bool HasDisplayName => Values.Exists(
        static it => it.Display?.Name != null || it.Display?.ShortName != null);

    public bool HasDisplayDescription =>
        Values.Exists(static it => it.Display?.Description != null);

    public bool HasDisplayPrompt =>
        Values.Exists(static it => it.Display?.Prompt != null);

    public bool HasDisplayGroupName =>
        Values.Exists(static it => it.Display?.GroupName != null);

    public static EnumToGenerate? FromSymbol(ISymbol symbol)
    {
        if (symbol is not INamedTypeSymbol typeSymbol)
            return null;

        var enumValues = typeSymbol
            .GetMembers()
            .Select(EnumValue.FromSymbol)
            .WhereNotNull()
            .ToList();

        if (enumValues.Count == 0)
            return null;

        return new EnumToGenerate(
            typeSymbol.ContainingNamespace?.ToString() ?? "Global",
            typeSymbol.Name,
            typeSymbol.EnumUnderlyingType?.GetNumericCSharpKeyword() ?? "int",
            enumValues);
    }
}
