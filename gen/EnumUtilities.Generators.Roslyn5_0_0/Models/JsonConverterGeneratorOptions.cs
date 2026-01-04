using Microsoft.CodeAnalysis;
using Raiqub.Generators.EnumUtilities.Common;

namespace Raiqub.Generators.EnumUtilities.Models;

public sealed record JsonConverterGeneratorOptions(
    bool AllowIntegerValues,
    bool IgnoreCase,
    object? DeserializationFailureFallbackValue
)
{
    public static JsonConverterGeneratorOptions? FromSymbol(INamedTypeSymbol typeSymbol)
    {
        var attributeData = typeSymbol
            .GetAttributes()
            .FirstOrDefault(x => x.AttributeClass?.Name == nameof(JsonConverterGeneratorAttribute));
        if (attributeData is null)
            return null;

        return new JsonConverterGeneratorOptions(
            attributeData.GetNamedArgument(nameof(JsonConverterGeneratorAttribute.AllowIntegerValues)) as bool? ?? true,
            attributeData.GetNamedArgument(nameof(JsonConverterGeneratorAttribute.IgnoreCase)) as bool? ?? false,
            attributeData.GetNamedArgument(nameof(JsonConverterGeneratorAttribute.DeserializationFailureFallbackValue))
        );
    }
}
