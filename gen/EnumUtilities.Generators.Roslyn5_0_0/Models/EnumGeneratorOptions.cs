using Microsoft.CodeAnalysis;
using Raiqub.Generators.EnumUtilities.Common;

namespace Raiqub.Generators.EnumUtilities.Models;

public sealed record EnumGeneratorOptions(bool DisableLookupTable)
{
    public static EnumGeneratorOptions? FromSymbol(INamedTypeSymbol typeSymbol)
    {
        var attributeData = typeSymbol
            .GetAttributes()
            .FirstOrDefault(x =>
                string.Equals(x.AttributeClass?.Name, nameof(EnumGeneratorAttribute), StringComparison.Ordinal)
            );
        if (attributeData is null)
            return null;

        return new EnumGeneratorOptions(
            attributeData.GetNamedArgument(nameof(EnumGeneratorAttribute.DisableLookupTable)) as bool? ?? false
        );
    }
}
