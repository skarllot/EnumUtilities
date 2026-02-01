using System.Runtime.CompilerServices;
using Microsoft.CodeAnalysis;
using Raiqub.Generators.EnumUtilities.Common;

namespace Raiqub.Generators.EnumUtilities.Models;

public sealed record EnumValue(
    string MemberName,
    string MemberValue,
    ulong RealMemberValue,
    int Index,
    string? SerializationValue,
    string? Description,
    DisplayAttribute? Display,
    string? JsonPropertyName
)
{
    public string ResolvedSerializedValue => SerializationValue ?? MemberName;
    public string ResolvedJsonValue => JsonPropertyName ?? SerializationValue ?? MemberName;

    public long RealMemberSignedValue
    {
        get
        {
            var tmp = RealMemberValue;
            return Unsafe.As<ulong, long>(ref tmp);
        }
    }

    public static EnumValue? FromSymbol(ISymbol symbol, int index)
    {
        if (symbol is not IFieldSymbol { ConstantValue: not null } field)
            return null;

        string? serializationValue = null;
        string? description = null;
        DisplayAttribute? display = null;
        string? jsonPropertyName = null;

        foreach (var attribute in field.GetAttributes())
        {
            serializationValue ??= attribute
                .WhereClassNameIs("EnumMemberAttribute")
                ?.GetNamedArgument("Value")
                ?.ToString();

            description ??= attribute.WhereClassNameIs("DescriptionAttribute")?.GetConstructorArgument(0)?.ToString();

            display ??= attribute.WhereClassNameIs("DisplayAttribute").Map(DisplayAttribute.FromAttribute);

            jsonPropertyName ??= attribute
                .WhereClassNameIs("JsonPropertyNameAttribute")
                ?.GetConstructorArgument(0)
                ?.ToString();
        }

        return new EnumValue(
            MemberName: field.Name,
            MemberValue: field.ConstantValue.ToString(),
            RealMemberValue: ConvertToUInt64(field.ConstantValue),
            Index: index,
            SerializationValue: serializationValue,
            Description: description,
            Display: display,
            JsonPropertyName: jsonPropertyName
        );
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
