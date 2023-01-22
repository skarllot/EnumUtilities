﻿// <auto-generated />
#nullable enable

using System;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public static partial class PaymentMethodExtensions
    {
        /// <summary>Converts the value of this instance to its equivalent string representation.</summary>
        /// <returns>The string representation of the value of this instance.</returns>
        public static string ToStringFast(this PaymentMethod value)
        {
            return value switch
            {
                PaymentMethod.Credit => nameof(PaymentMethod.Credit),
                PaymentMethod.Debit => nameof(PaymentMethod.Debit),
                PaymentMethod.Cash => nameof(PaymentMethod.Cash),
                PaymentMethod.Cheque => nameof(PaymentMethod.Cheque),
                _ => value.ToString()
            };
        }

        /// <summary>Returns a boolean telling whether the value of this instance exists in the enumeration.</summary>
        /// <returns><c>true</c> if the value of this instance exists in the enumeration; <c>false</c> otherwise.</returns>
        public static bool IsDefined(this PaymentMethod value)
        {
            return PaymentMethodValidation.IsDefined(value);
        }

        public static string ToEnumMemberValue(this PaymentMethod value)
        {
            return value switch
            {
                PaymentMethod.Credit => "Credit card",
                PaymentMethod.Debit => "Debit card",
                PaymentMethod.Cash => nameof(PaymentMethod.Cash),
                PaymentMethod.Cheque => nameof(PaymentMethod.Cheque),
                _ => value.ToString()
            };
        }

        public static string? GetDescription(this PaymentMethod value)
        {
            return value switch
            {
                PaymentMethod.Cash => "The payment by using physical cash",
                _ => null
            };
        }

        public static string GetDisplayShortName(this PaymentMethod value)
        {
            return value switch
            {
                _ => GetDisplayName(value)
            };
        }

        public static string GetDisplayName(this PaymentMethod value)
        {
            return value switch
            {
                PaymentMethod.Credit => "Credit Card",
                PaymentMethod.Debit => "Debit Card",
                PaymentMethod.Cash => "Physical Cash",
                PaymentMethod.Cheque => nameof(PaymentMethod.Cheque),
                _ => value.ToString()
            };
        }
    }
}
