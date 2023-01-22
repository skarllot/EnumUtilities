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
}