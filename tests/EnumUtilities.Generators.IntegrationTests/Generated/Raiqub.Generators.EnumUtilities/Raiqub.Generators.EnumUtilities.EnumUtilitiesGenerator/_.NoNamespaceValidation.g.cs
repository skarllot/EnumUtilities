﻿// <auto-generated />
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS1591 // publicly visible type or member must be documented

[global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.8.0.0")]
public static partial class NoNamespaceValidation
{
    /// <summary>Returns a boolean telling whether the value of <see cref="NoNamespace"/> instance exists in the enumeration.</summary>
    /// <returns><c>true</c> if the value of <see cref="NoNamespace"/> instance exists in the enumeration; <c>false</c> otherwise.</returns>
    public static bool IsDefined(NoNamespace value)
    {
        return (int)value switch
        {
            0 => true,
            1 => true,
            2 => true,
            _ => false
        };
    }

    public static bool IsDefined(
        [NotNullWhen(true)] string? name,
        StringComparison comparisonType)
    {
        return name switch
        {
            { } s when s.Equals("Zero", comparisonType) => true,
            { } s when s.Equals("One", comparisonType) => true,
            { } s when s.Equals("Two", comparisonType) => true,
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
            "Zero" => true,
            "One" => true,
            "Two" => true,
            _ => false
        };
    }
}