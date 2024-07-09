﻿// <auto-generated />
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.8.0.0")]
    public static partial class HumanStatesValidation
    {
        /// <summary>Returns a boolean telling whether the value of <see cref="HumanStates"/> instance exists in the enumeration.</summary>
        /// <returns><c>true</c> if the value of <see cref="HumanStates"/> instance exists in the enumeration; <c>false</c> otherwise.</returns>
        public static bool IsDefined(HumanStates value)
        {
            return (int)value switch
            {
                1 => true,
                2 => true,
                3 => true,
                4 => true,
                5 => true,
                _ => false
            };
        }

        public static bool IsDefined(
            [NotNullWhen(true)] string? name,
            StringComparison comparisonType)
        {
            return name switch
            {
                { } s when s.Equals("Idle", comparisonType) => true,
                { } s when s.Equals("Working", comparisonType) => true,
                { } s when s.Equals("Sleeping", comparisonType) => true,
                { } s when s.Equals("Eating", comparisonType) => true,
                { } s when s.Equals("Dead", comparisonType) => true,
                { } s when s.Equals("Relaxing", comparisonType) => true,
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
                "Idle" => true,
                "Working" => true,
                "Sleeping" => true,
                "Eating" => true,
                "Dead" => true,
                "Relaxing" => true,
                _ => false
            };
        }
    }
}
