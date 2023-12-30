﻿// <auto-generated />
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.4.0.0")]
    public static partial class MyEnum3Validation
    {
        /// <summary>Returns a boolean telling whether the value of <see cref="MyEnum3"/> instance exists in the enumeration.</summary>
        /// <returns><c>true</c> if the value of <see cref="MyEnum3"/> instance exists in the enumeration; <c>false</c> otherwise.</returns>
        public static bool IsDefined(NestedInClass.MyEnum3 value)
        {
            return value switch
            {
                NestedInClass.MyEnum3.Monday => true,
                NestedInClass.MyEnum3.Tuesday => true,
                NestedInClass.MyEnum3.Wednesday => true,
                NestedInClass.MyEnum3.Thursday => true,
                NestedInClass.MyEnum3.Friday => true,
                NestedInClass.MyEnum3.Saturday => true,
                NestedInClass.MyEnum3.Sunday => true,
                _ => false
            };
        }

        public static bool IsDefined(
            [NotNullWhen(true)] string? name,
            StringComparison comparisonType)
        {
            return name switch
            {
                { } s when s.Equals(nameof(NestedInClass.MyEnum3.Monday), comparisonType) => true,
                { } s when s.Equals(nameof(NestedInClass.MyEnum3.Tuesday), comparisonType) => true,
                { } s when s.Equals(nameof(NestedInClass.MyEnum3.Wednesday), comparisonType) => true,
                { } s when s.Equals(nameof(NestedInClass.MyEnum3.Thursday), comparisonType) => true,
                { } s when s.Equals(nameof(NestedInClass.MyEnum3.Friday), comparisonType) => true,
                { } s when s.Equals(nameof(NestedInClass.MyEnum3.Saturday), comparisonType) => true,
                { } s when s.Equals(nameof(NestedInClass.MyEnum3.Sunday), comparisonType) => true,
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
                nameof(NestedInClass.MyEnum3.Monday) => true,
                nameof(NestedInClass.MyEnum3.Tuesday) => true,
                nameof(NestedInClass.MyEnum3.Wednesday) => true,
                nameof(NestedInClass.MyEnum3.Thursday) => true,
                nameof(NestedInClass.MyEnum3.Friday) => true,
                nameof(NestedInClass.MyEnum3.Saturday) => true,
                nameof(NestedInClass.MyEnum3.Sunday) => true,
                _ => false
            };
        }
    }
}
