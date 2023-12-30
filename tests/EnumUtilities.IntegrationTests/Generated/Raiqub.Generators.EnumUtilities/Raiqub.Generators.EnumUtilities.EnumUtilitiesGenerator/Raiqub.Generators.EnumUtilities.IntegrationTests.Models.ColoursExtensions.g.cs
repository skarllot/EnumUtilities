﻿// <auto-generated />
#nullable enable

using System;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.4.0.0")]
    public static partial class ColoursExtensions
    {
        /// <summary>Converts the value of this instance to its equivalent string representation.</summary>
        /// <returns>The string representation of the value of this instance.</returns>
        public static string ToStringFast(this Colours value)
        {
            return value switch
            {
                Colours.Red => nameof(Colours.Red),
                Colours.Blue => nameof(Colours.Blue),
                Colours.Green => nameof(Colours.Green),
                _ => value.ToString()
            };
        }

        /// <summary>Returns a boolean telling whether the value of this instance exists in the enumeration.</summary>
        /// <returns><c>true</c> if the value of this instance exists in the enumeration; <c>false</c> otherwise.</returns>
        public static bool IsDefined(this Colours value)
        {
            return ColoursValidation.IsDefined(value);
        }
    }
}
