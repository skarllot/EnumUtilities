﻿// <auto-generated />
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.11.0.0")]
    public static partial class MyEnum3Validation
    {
        /// <summary>Returns a boolean telling whether the value of <see cref="MyEnum3"/> instance exists in the enumeration.</summary>
        /// <returns><c>true</c> if the value of <see cref="MyEnum3"/> instance exists in the enumeration; <c>false</c> otherwise.</returns>
        public static bool IsDefined(NestedInClass.MyEnum3 value)
        {
            return (int)value switch
            {
                0 => true,
                1 => true,
                2 => true,
                3 => true,
                4 => true,
                5 => true,
                6 => true,
                _ => false
            };
        }

        public static bool IsDefined(
            [NotNullWhen(true)] string? name,
            StringComparison comparisonType)
        {
            return name switch
            {
                { } s when s.Equals("Monday", comparisonType) => true,
                { } s when s.Equals("Tuesday", comparisonType) => true,
                { } s when s.Equals("Wednesday", comparisonType) => true,
                { } s when s.Equals("Thursday", comparisonType) => true,
                { } s when s.Equals("Friday", comparisonType) => true,
                { } s when s.Equals("Saturday", comparisonType) => true,
                { } s when s.Equals("Sunday", comparisonType) => true,
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
                "Monday" => true,
                "Tuesday" => true,
                "Wednesday" => true,
                "Thursday" => true,
                "Friday" => true,
                "Saturday" => true,
                "Sunday" => true,
                _ => false
            };
        }
    }
}
