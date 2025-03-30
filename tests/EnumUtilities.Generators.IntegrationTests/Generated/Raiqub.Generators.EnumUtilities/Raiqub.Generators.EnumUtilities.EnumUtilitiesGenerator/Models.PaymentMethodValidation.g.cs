﻿// <auto-generated />
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.11.0.0")]
    public static partial class PaymentMethodValidation
    {
        /// <summary>Returns a boolean telling whether the value of <see cref="PaymentMethod"/> instance exists in the enumeration.</summary>
        /// <returns><c>true</c> if the value of <see cref="PaymentMethod"/> instance exists in the enumeration; <c>false</c> otherwise.</returns>
        public static bool IsDefined(PaymentMethod value)
        {
            return (int)value switch
            {
                0 => true,
                1 => true,
                2 => true,
                3 => true,
                _ => false
            };
        }

        public static bool IsDefined(
            [NotNullWhen(true)] string? name,
            StringComparison comparisonType)
        {
            return name switch
            {
                { } s when s.Equals("Credit", comparisonType) => true,
                { } s when s.Equals("Debit", comparisonType) => true,
                { } s when s.Equals("Cash", comparisonType) => true,
                { } s when s.Equals("Cheque", comparisonType) => true,
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
                "Credit" => true,
                "Debit" => true,
                "Cash" => true,
                "Cheque" => true,
                _ => false
            };
        }
    }
}
