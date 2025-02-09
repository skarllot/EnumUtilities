using Microsoft.CodeAnalysis;
using Raiqub.Generators.EnumUtilities.Common;

namespace Raiqub.Generators.EnumUtilities.Models;

public sealed record DisplayAttribute(
    string? ShortName,
    string? Name,
    string? Description,
    string? Prompt,
    string? GroupName,
    string? ResourceType)
{
    public bool HasResource => ResourceType is not null;
    public string? ResourceShortName => GetPropertyWithResource(ShortName);
    public string? ResourceName => GetPropertyWithResource(Name);
    public string? ResourceDescription => GetPropertyWithResource(Description);
    public string? ResourcePrompt => GetPropertyWithResource(Prompt);
    public string? ResourceGroupName => GetPropertyWithResource(GroupName);

    public static DisplayAttribute FromAttribute(AttributeData attribute)
    {
        return new DisplayAttribute(
            ShortName: attribute.GetNamedArgument(nameof(ShortName))?.ToString(),
            Name: attribute.GetNamedArgument(nameof(Name))?.ToString(),
            Description: attribute.GetNamedArgument(nameof(Description))?.ToString(),
            Prompt: attribute.GetNamedArgument(nameof(Prompt))?.ToString(),
            GroupName: attribute.GetNamedArgument(nameof(GroupName))?.ToString(),
            ResourceType: attribute.GetNamedArgument(nameof(ResourceType))?.ToString());
    }

    private string? GetPropertyWithResource(string? propertyName)
    {
        return propertyName != null && ResourceType != null ? ResourceType + "." + propertyName : null;
    }
}
