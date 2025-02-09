using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Raiqub.Generators.EnumUtilities.Common;

namespace Raiqub.Generators.EnumUtilities.Models;

public sealed record EnumToGenerate(
    SelectedGenerators SelectedGenerators,
    JsonConverterGeneratorOptions? JsonConverterGeneratorOptions,
    string? Namespace,
    ContainingType? ContainingType,
    bool IsPublic,
    bool IsFlags,
    string Name,
    string UnderlyingType,
    List<EnumValue> Values,
    ImmutableArray<Location> Locations)
    : ILocalizableSource
{
    private List<EnumValue>? _invertedValues;

    public string MetadataClassName => Name.Contains("Metadata") ? $"{Name}Info" : $"{Name}Metadata";
    public string RefName { get; } = ContainingType is not null ? $"{ContainingType.Name}.{Name}" : Name;

    public List<EnumValue> UniqueValues { get; } =
        Values.DistinctBy(static it => it.MemberValue, StringComparer.Ordinal).ToList();

    public List<EnumValue> InvertedValues =>
        _invertedValues ??= Values
            .DistinctBy(x => x.RealMemberValue)
            .OrderByDescending(x => x.RealMemberValue)
            .ToList();

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

    public bool HasJsonProperty =>
        Values.Exists(static it => it.JsonPropertyName != null);

    public bool HasZeroMember { get; } =
        Values.Any(x => x.RealMemberValue == 0);

    private int BitCount { get; } = UnderlyingType switch
    {
        "byte" => 8,
        "sbyte" => 8,
        "short" => 16,
        "ushort" => 16,
        "int" => 32,
        "uint" => 32,
        "long" => 64,
        "ulong" => 64,
        _ => 64,
    };

    public static EnumToGenerate? FromSymbol(ISymbol symbol)
    {
        if (symbol is not INamedTypeSymbol typeSymbol ||
            typeSymbol.DeclaredAccessibility is not Accessibility.Public and not Accessibility.Internal ||
            typeSymbol.ContainingType is
                { DeclaredAccessibility: not Accessibility.Public and not Accessibility.Internal })
        {
            return null;
        }

        var attributes = typeSymbol.GetAttributes();

        var enumValues = typeSymbol
            .GetMembers()
            .Select(EnumValue.FromSymbol)
            .WhereNotNull()
            .ToList();

        if (enumValues.Count == 0)
            return null;

        string? ns = typeSymbol.ContainingNamespace?.ToString();
        if (ns == "<global namespace>")
            ns = null;

        return new EnumToGenerate(
            (attributes.Any(x => x.AttributeClass?.Name == nameof(EnumGeneratorAttribute))
                ? SelectedGenerators.MainGenerator
                : 0) |
            (attributes.Any(x => x.AttributeClass?.Name == nameof(JsonConverterGeneratorAttribute))
                ? SelectedGenerators.JsonConverter
                : 0),
            JsonConverterGeneratorOptions.FromSymbol(typeSymbol),
            string.IsNullOrWhiteSpace(ns) ? null : ns,
            typeSymbol.ContainingType is not null ? ContainingType.FromSymbol(typeSymbol.ContainingType) : null,
            typeSymbol.DeclaredAccessibility == Accessibility.Public,
            attributes.Any(x => x.AttributeClass?.Name == nameof(FlagsAttribute)),
            typeSymbol.Name,
            typeSymbol.EnumUnderlyingType?.GetNumericCSharpKeyword() ?? "int",
            enumValues,
            typeSymbol.Locations);
    }

    public static string[] BitRangeConditionStrings { get; } =
        ["value > 0xffff_ffff_ffff", "value > 0xffff_ffff", "value > 0xffff", "true"];

    public List<EnumValue>[] GetEnumValueRangesByBitRange()
    {
        var h2Values = BitCount == 64
            ? InvertedValues
                .Where(x => x.RealMemberValue > 0x0000_ffff_ffff_ffffUL)
                .ToList()
            : [];
        var h1Values = BitCount == 64
            ? InvertedValues
                .Where(
                    x => x.RealMemberValue > 0x0000_0000_ffff_ffffUL & x.RealMemberValue <= 0x0000_ffff_ffff_ffffUL)
                .ToList()
            : [];
        var l2Values = BitCount >= 32
            ? InvertedValues
                .Where(
                    x => x.RealMemberValue > 0x0000_0000_0000_ffffUL & x.RealMemberValue <= 0x0000_0000_ffff_ffffUL)
                .ToList()
            : [];
        var l1Values = BitCount >= 16
            ? InvertedValues
                .Where(
                    x => x.RealMemberValue > 0x0000_0000_0000_0000UL & x.RealMemberValue <= 0x0000_0000_0000_ffffUL)
                .ToList()
            : [];
        return [h2Values, h1Values, l2Values, l1Values];
    }

    public int GetMappedBitCount()
    {
        if (Values.Any(x => x.MemberValue[0] == '-'))
            return BitCount;

        return BitCount -
               (BitOperations.LeadingZeroCount(Values.Select(x => x.RealMemberValue).Max()) -
                (64 - BitCount));
    }

    public string? InterlockedUnderlyingType =>
        UnderlyingType switch
        {
            "int" => "int",
            "long" => "long",
            "uint" => "int",
            "ulong" => "long",
            _ => null,
        };

    public bool IsInterlockedSupported() => InterlockedUnderlyingType != null;
}
