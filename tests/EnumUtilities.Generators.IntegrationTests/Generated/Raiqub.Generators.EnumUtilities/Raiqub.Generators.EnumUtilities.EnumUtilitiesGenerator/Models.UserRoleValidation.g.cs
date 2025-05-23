﻿// <auto-generated />
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.11.0.0")]
    public static partial class UserRoleValidation
    {
        /// <summary>Returns a boolean telling whether the value of <see cref="UserRole"/> instance exists in the enumeration.</summary>
        /// <returns><c>true</c> if the value of <see cref="UserRole"/> instance exists in the enumeration; <c>false</c> otherwise.</returns>
        public static bool IsDefined(UserRole value)
        {
            return (ulong)value switch
            {
                0 => true,
                1 => true,
                2 => true,
                4 => true,
                6 => true,
                7 => true,
                _ => false
            };
        }

        public static bool IsDefined(
            [NotNullWhen(true)] string? name,
            StringComparison comparisonType)
        {
            return name switch
            {
                { } s when s.Equals("None", comparisonType) => true,
                { } s when s.Equals("NormalUser", comparisonType) => true,
                { } s when s.Equals("Custodian", comparisonType) => true,
                { } s when s.Equals("Finance", comparisonType) => true,
                { } s when s.Equals("SuperUser", comparisonType) => true,
                { } s when s.Equals("All", comparisonType) => true,
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
                "None" => true,
                "NormalUser" => true,
                "Custodian" => true,
                "Finance" => true,
                "SuperUser" => true,
                "All" => true,
                _ => false
            };
        }
    }
}
