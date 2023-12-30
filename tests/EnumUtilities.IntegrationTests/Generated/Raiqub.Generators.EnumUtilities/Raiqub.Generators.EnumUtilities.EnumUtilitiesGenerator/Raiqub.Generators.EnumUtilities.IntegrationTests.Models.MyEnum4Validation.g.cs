﻿// <auto-generated />
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.3.0.0")]
    internal static partial class MyEnum4Validation
    {
        /// <summary>Returns a boolean telling whether the value of <see cref="MyEnum4"/> instance exists in the enumeration.</summary>
        /// <returns><c>true</c> if the value of <see cref="MyEnum4"/> instance exists in the enumeration; <c>false</c> otherwise.</returns>
        public static bool IsDefined(NestedInClass.MyEnum4 value)
        {
            return value switch
            {
                NestedInClass.MyEnum4.Zero => true,
                NestedInClass.MyEnum4.One => true,
                NestedInClass.MyEnum4.Two => true,
                _ => false
            };
        }

        public static bool IsDefined(
            [NotNullWhen(true)] string? name,
            StringComparison comparisonType)
        {
            return name switch
            {
                { } s when s.Equals(nameof(NestedInClass.MyEnum4.Zero), comparisonType) => true,
                { } s when s.Equals(nameof(NestedInClass.MyEnum4.One), comparisonType) => true,
                { } s when s.Equals(nameof(NestedInClass.MyEnum4.Two), comparisonType) => true,
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
                nameof(NestedInClass.MyEnum4.Zero) => true,
                nameof(NestedInClass.MyEnum4.One) => true,
                nameof(NestedInClass.MyEnum4.Two) => true,
                _ => false
            };
        }
    }
}