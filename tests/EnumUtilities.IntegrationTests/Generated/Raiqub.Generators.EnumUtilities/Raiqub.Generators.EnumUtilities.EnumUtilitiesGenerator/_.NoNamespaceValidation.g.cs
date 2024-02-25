﻿// <auto-generated />
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS1591 // publicly visible type or member must be documented

[global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.5.0.0")]
public static partial class NoNamespaceValidation
{
    /// <summary>Returns a boolean telling whether the value of <see cref="NoNamespace"/> instance exists in the enumeration.</summary>
    /// <returns><c>true</c> if the value of <see cref="NoNamespace"/> instance exists in the enumeration; <c>false</c> otherwise.</returns>
    public static bool IsDefined(NoNamespace value)
    {
        return value switch
        {
            NoNamespace.Zero => true,
            NoNamespace.One => true,
            NoNamespace.Two => true,
            _ => false
        };
    }

    public static bool IsDefined(
        [NotNullWhen(true)] string? name,
        StringComparison comparisonType)
    {
        return name switch
        {
            { } s when s.Equals(nameof(NoNamespace.Zero), comparisonType) => true,
            { } s when s.Equals(nameof(NoNamespace.One), comparisonType) => true,
            { } s when s.Equals(nameof(NoNamespace.Two), comparisonType) => true,
            _ => false
        };
    }

    public static bool IsDefinedIgnoreCase([NotNullWhen(true)] string? name)
    {
        return IsDefined(name, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsDefined([NotNullWhen(true)] string? name)
    {
        return name switch
        {
            nameof(NoNamespace.Zero) => true,
            nameof(NoNamespace.One) => true,
            nameof(NoNamespace.Two) => true,
            _ => false
        };
    }
}
