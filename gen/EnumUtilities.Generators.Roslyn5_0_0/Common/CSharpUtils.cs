using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Raiqub.Generators.EnumUtilities.Common;

public static class CSharpUtils
{
    private static readonly SymbolDisplayFormat s_cSharpTypeFormat =
        SymbolDisplayFormat.FullyQualifiedFormat.WithMiscellaneousOptions(
            SymbolDisplayMiscellaneousOptions.UseSpecialTypes
                | SymbolDisplayMiscellaneousOptions.EscapeKeywordIdentifiers
                | SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier
        );

    public static string ToCSharpTypeName(this ITypeSymbol typeSymbol)
    {
        return typeSymbol.ToDisplayString(s_cSharpTypeFormat);
    }

    public static string GetNumericSuffixFromCSharpKeyword(string keyword)
    {
        return keyword switch
        {
            "uint" => "U",
            "long" => "L",
            "ulong" => "UL",
            "nuint" => "U",
            _ => "",
        };
    }

    public static string GetTypeNameFromCSharpKeyword(string keyword)
    {
        return keyword switch
        {
            "sbyte" => "SByte",
            "byte" => "Byte",
            "short" => "Int16",
            "ushort" => "UInt16",
            "int" => "Int32",
            "uint" => "UInt32",
            "long" => "Int64",
            "ulong" => "UInt64",
            "nint" => "IntPtr",
            "nuint" => "UIntPtr",
            _ => keyword,
        };
    }

    public static Location GetDefaultLocation(this ISymbol symbol)
    {
        return symbol.Locations.FirstOrDefault(l => l.Kind == LocationKind.SourceFile) ?? Location.None;
    }

    public static string ToQuotedStringOrNullLiteral(this string? value)
    {
        return value is null ? "null" : SymbolDisplay.FormatLiteral(value, quote: true);
    }

    public static string ToQuotedStringLiteral(this string value)
    {
        return SymbolDisplay.FormatLiteral(value, quote: true);
    }

    public static string ToQuotedCharLiteral(this char value)
    {
        return SymbolDisplay.FormatLiteral(value, quote: true);
    }
}
