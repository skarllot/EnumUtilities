﻿// <auto-generated />
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.11.0.0")]
    public static partial class StatusCodeValidation
    {
        /// <summary>Returns a boolean telling whether the value of <see cref="StatusCode"/> instance exists in the enumeration.</summary>
        /// <returns><c>true</c> if the value of <see cref="StatusCode"/> instance exists in the enumeration; <c>false</c> otherwise.</returns>
        public static bool IsDefined(StatusCode value)
        {
            return (int)value switch
            {
                -1 => true,
                0 => true,
                -2 => true,
                -3 => true,
                -4 => true,
                -5 => true,
                -6 => true,
                -7 => true,
                -8 => true,
                -9 => true,
                -10 => true,
                _ => false
            };
        }

        public static bool IsDefined(
            [NotNullWhen(true)] string? name,
            StringComparison comparisonType)
        {
            return name switch
            {
                { } s when s.Equals("Unknown", comparisonType) => true,
                { } s when s.Equals("Success", comparisonType) => true,
                { } s when s.Equals("Error", comparisonType) => true,
                { } s when s.Equals("NotFound", comparisonType) => true,
                { } s when s.Equals("Timeout", comparisonType) => true,
                { } s when s.Equals("Unauthorized", comparisonType) => true,
                { } s when s.Equals("Forbidden", comparisonType) => true,
                { } s when s.Equals("Conflict", comparisonType) => true,
                { } s when s.Equals("Gone", comparisonType) => true,
                { } s when s.Equals("InvalidRequest", comparisonType) => true,
                { } s when s.Equals("ServerError", comparisonType) => true,
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
                "Unknown" => true,
                "Success" => true,
                "Error" => true,
                "NotFound" => true,
                "Timeout" => true,
                "Unauthorized" => true,
                "Forbidden" => true,
                "Conflict" => true,
                "Gone" => true,
                "InvalidRequest" => true,
                "ServerError" => true,
                _ => false
            };
        }
    }
}
