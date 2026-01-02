using Microsoft.CodeAnalysis;

namespace Raiqub.Generators.EnumUtilities.Common;

public static class CSharpExtensions
{
    public static string GetNumericCSharpKeyword(this INamedTypeSymbol typeSymbol)
    {
        return typeSymbol.Name switch
        {
            "SByte" => "sbyte",
            "Byte" => "byte",
            "Int16" => "short",
            "UInt16" => "ushort",
            "Int32" => "int",
            "UInt32" => "uint",
            "Int64" => "long",
            "UInt64" => "ulong",
            "IntPtr" => "nint",
            "UIntPtr" => "nuint",
            _ => typeSymbol.Name
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
            _ => keyword
        };
    }

    public static Location GetDefaultLocation(this ISymbol symbol)
    {
        return symbol.Locations.FirstOrDefault(l => l.Kind == LocationKind.SourceFile) ?? Location.None;
    }
}
