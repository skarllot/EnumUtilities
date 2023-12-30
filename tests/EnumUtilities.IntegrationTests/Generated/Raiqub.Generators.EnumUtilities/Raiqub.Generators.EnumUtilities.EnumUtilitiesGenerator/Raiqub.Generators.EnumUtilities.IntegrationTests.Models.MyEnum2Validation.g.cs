﻿// <auto-generated />
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.3.0.0")]
    internal static partial class MyEnum2Validation
    {
        /// <summary>Returns a boolean telling whether the value of <see cref="MyEnum2"/> instance exists in the enumeration.</summary>
        /// <returns><c>true</c> if the value of <see cref="MyEnum2"/> instance exists in the enumeration; <c>false</c> otherwise.</returns>
        public static bool IsDefined(NestedInClass.MyEnum2 value)
        {
            return value switch
            {
                NestedInClass.MyEnum2.Credit => true,
                NestedInClass.MyEnum2.Debit => true,
                NestedInClass.MyEnum2.Cash => true,
                NestedInClass.MyEnum2.Cheque => true,
                _ => false
            };
        }

        public static bool IsDefined(
            [NotNullWhen(true)] string? name,
            StringComparison comparisonType)
        {
            return name switch
            {
                { } s when s.Equals(nameof(NestedInClass.MyEnum2.Credit), comparisonType) => true,
                { } s when s.Equals(nameof(NestedInClass.MyEnum2.Debit), comparisonType) => true,
                { } s when s.Equals(nameof(NestedInClass.MyEnum2.Cash), comparisonType) => true,
                { } s when s.Equals(nameof(NestedInClass.MyEnum2.Cheque), comparisonType) => true,
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
                nameof(NestedInClass.MyEnum2.Credit) => true,
                nameof(NestedInClass.MyEnum2.Debit) => true,
                nameof(NestedInClass.MyEnum2.Cash) => true,
                nameof(NestedInClass.MyEnum2.Cheque) => true,
                _ => false
            };
        }
    }
}
