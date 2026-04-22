using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Raiqub.Generators.EnumUtilities.Common;
using Raiqub.Generators.InterpolationCodeWriter.Collections;

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
    EquatableArray<EnumValue> Values,
    Location DefaultLocations,
    string? RootNamespace = null
)
{
    public string MetadataClassName => Name.Contains("Metadata") ? $"{Name}Info" : $"{Name}Metadata";

    public string RefName => field ??= ContainingType is not null ? $"{ContainingType.Name}.{Name}" : Name;

    public List<EnumValue> UniqueValues =>
        field ??= Values.AsEnumerable().DistinctBy(static it => it.RealMemberValue).ToList();

    public List<EnumValue> InvertedValues =>
        field ??= IsUnsigned
            ? Values
                .AsEnumerable()
                .DistinctBy(static x => x.RealMemberValue)
                .OrderByDescending(static x => x.RealMemberValue)
                .ToList()
            : Values
                .AsEnumerable()
                .DistinctBy(static x => x.RealMemberSignedValue)
                .OrderByDescending(static x => x.RealMemberSignedValue)
                .ToList();

    public IEnumerable<EnumValue> OrderedValues =>
        IsUnsigned
            ? Values.AsEnumerable().OrderBy(x => x.RealMemberValue)
            : Values.AsEnumerable().OrderBy(x => x.RealMemberSignedValue);

    public bool HasSerializationValue => Values.Exists(static it => it.SerializationValue != null);

    public bool HasDescription => Values.Exists(static it => it.Description != null);

    public bool HasDisplayName => Values.Exists(static it => it.Display?.Name != null || it.Display?.ShortName != null);

    public bool HasDisplayDescription => Values.Exists(static it => it.Display?.Description != null);

    public bool HasDisplayPrompt => Values.Exists(static it => it.Display?.Prompt != null);

    public bool HasDisplayGroupName => Values.Exists(static it => it.Display?.GroupName != null);

    public bool HasJsonProperty => Values.Exists(static it => it.JsonPropertyName != null);

    public bool HasZeroMember { get; } = Values.AsEnumerable().Any(x => x.RealMemberValue == 0);

    public bool IsUnsigned { get; } = UnderlyingType is "byte" or "ushort" or "uint" or "ulong";

    public int BitCount { get; } =
        UnderlyingType switch
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
        if (
            symbol is not INamedTypeSymbol typeSymbol
            || typeSymbol.DeclaredAccessibility is not Accessibility.Public and not Accessibility.Internal
            || typeSymbol.ContainingType
                is { DeclaredAccessibility: not Accessibility.Public and not Accessibility.Internal }
        )
        {
            return null;
        }

        var attributes = typeSymbol.GetAttributes();

        var enumValues = typeSymbol.GetMembers().Select(EnumValue.FromSymbol).WhereNotNull().ToArray();

        if (enumValues.Length == 0)
            return null;

        var ns = typeSymbol.ContainingNamespace?.ToString();
        if (string.Equals(ns, "<global namespace>", StringComparison.Ordinal))
            ns = null;

        return new EnumToGenerate(
            SelectedGenerators: ResolveSelectedGenerators(attributes),
            JsonConverterGeneratorOptions: JsonConverterGeneratorOptions.FromSymbol(typeSymbol),
            Namespace: string.IsNullOrWhiteSpace(ns) ? null : ns,
            ContainingType: typeSymbol.ContainingType is not null
                ? ContainingType.FromSymbol(typeSymbol.ContainingType)
                : null,
            IsPublic: typeSymbol.DeclaredAccessibility == Accessibility.Public,
            IsFlags: attributes.Any(x =>
                string.Equals(x.AttributeClass?.Name, nameof(FlagsAttribute), StringComparison.Ordinal)
            ),
            Name: typeSymbol.Name,
            UnderlyingType: typeSymbol.EnumUnderlyingType?.GetNumericCSharpKeyword() ?? "int",
            Values: EquatableArray<EnumValue>.FromArrayWithoutCopy(enumValues),
            DefaultLocations: typeSymbol.GetDefaultLocation()
        );
    }

    public static string[] BitRangeConditionStrings { get; } =
    ["value > 0xffff_ffff_ffff", "value > 0xffff_ffff", "value > 0xffff", "true"];

    public List<EnumValue>[] GetEnumValueRangesByBitRange()
    {
        var h2Values =
            BitCount == 64 ? InvertedValues.Where(x => x.RealMemberValue > 0x0000_ffff_ffff_ffffUL).ToList() : [];
        var h1Values =
            BitCount == 64
                ? InvertedValues
                    .Where(x => x.RealMemberValue is > 0x0000_0000_ffff_ffffUL and <= 0x0000_ffff_ffff_ffffUL)
                    .ToList()
                : [];
        var l2Values =
            BitCount >= 32
                ? InvertedValues
                    .Where(x => x.RealMemberValue is > 0x0000_0000_0000_ffffUL and <= 0x0000_0000_ffff_ffffUL)
                    .ToList()
                : [];
        var l1Values =
            BitCount >= 16
                ? InvertedValues
                    .Where(x => x.RealMemberValue is > 0x0000_0000_0000_0000UL and <= 0x0000_0000_0000_ffffUL)
                    .ToList()
                : [];
        return [h2Values, h1Values, l2Values, l1Values];
    }

    public int GetMappedBitCount()
    {
        if (Values.AsEnumerable().Any(x => x.MemberValue[0] == '-'))
            return BitCount;

        return BitCount
            - (
                BitOperations.LeadingZeroCount(Values.AsEnumerable().Select(x => x.RealMemberValue).Max())
                - (64 - BitCount)
            );
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

    private static SelectedGenerators ResolveSelectedGenerators(ImmutableArray<AttributeData> attributes) =>
        (
            attributes.Any(x =>
                string.Equals(x.AttributeClass?.Name, nameof(EnumGeneratorAttribute), StringComparison.Ordinal)
            )
                ? SelectedGenerators.MainGenerator
                : SelectedGenerators.None
        )
        | (
            attributes.Any(x =>
                string.Equals(x.AttributeClass?.Name, nameof(JsonConverterGeneratorAttribute), StringComparison.Ordinal)
            )
                ? SelectedGenerators.JsonConverter
                : SelectedGenerators.None
        );
}
