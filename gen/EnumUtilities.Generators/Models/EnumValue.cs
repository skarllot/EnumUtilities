using System.Runtime.CompilerServices;
using Microsoft.CodeAnalysis;
using Raiqub.Generators.EnumUtilities.Common;

namespace Raiqub.Generators.EnumUtilities.Models;

public sealed class EnumValue
{
    private EnumValue(string memberName, string memberValue, object realMemberValue)
    {
        MemberName = memberName;
        MemberValue = memberValue;
        RealMemberValue = ConvertToUInt64(realMemberValue);
    }

    public string MemberName { get; }
    public string MemberValue { get; }
    public ulong RealMemberValue { get; set; }
    public string? SerializationValue { get; set; }
    public string? Description { get; set; }
    public DisplayAttribute? Display { get; set; }
    public string? JsonPropertyName { get; set; }
    public string ResolvedSerializedValue => SerializationValue ?? MemberName;

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

    private static ulong ConvertToUInt64(object realMemberValue)
    {
        long tmp;
        switch (realMemberValue)
        {
            case int v:
                tmp = v;
                return Unsafe.As<long, ulong>(ref tmp);
            case uint v:
                return v;
            case long v:
                return Unsafe.As<long, ulong>(ref v);
            case ulong v:
                return v;
            case byte v:
                return v;
            case sbyte v:
                tmp = v;
                return Unsafe.As<long, ulong>(ref tmp);
            case short v:
                tmp = v;
                return Unsafe.As<long, ulong>(ref tmp);
            case ushort v:
                return v;
            default:
                return Convert.ToUInt64(realMemberValue);
        }
    }
}
