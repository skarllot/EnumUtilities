using Microsoft.CodeAnalysis;
using Raiqub.Generators.EnumUtilities.Common;

namespace Raiqub.Generators.EnumUtilities.Models;

public sealed class EnumValue
{
    private EnumValue(string memberName, string memberValue, object realMemberValue)
    {
        MemberName = memberName;
        MemberValue = memberValue;
        RealMemberValue = realMemberValue;
    }

    public string MemberName { get; }
    public string MemberValue { get; }
    public object RealMemberValue { get; }
    public string? SerializationValue { get; set; }
    public string? Description { get; set; }
    public DisplayAttribute? Display { get; set; }
    public string? JsonPropertyName { get; set; }

    public static EnumValue? FromSymbol(ISymbol symbol)
    {
        if (symbol is not IFieldSymbol { ConstantValue: not null } field)
            return null;

        var result = new EnumValue(field.Name, field.ConstantValue.ToString(), field.ConstantValue);

        foreach (var attribute in field.GetAttributes())
        {
            result.SerializationValue ??= attribute
                .WhereClassNameIs("EnumMemberAttribute")
                ?.GetNamedArgument("Value")?.ToString();

            result.Description ??= attribute
                .WhereClassNameIs("DescriptionAttribute")
                ?.GetConstructorArgument(0)?.ToString();

            result.Display ??= attribute
                .WhereClassNameIs("DisplayAttribute")
                .Map(DisplayAttribute.FromAttribute);

            result.JsonPropertyName ??= attribute
                .WhereClassNameIs("JsonPropertyNameAttribute")
                ?.GetConstructorArgument(0)?.ToString();
        }

        return result;
    }
}
