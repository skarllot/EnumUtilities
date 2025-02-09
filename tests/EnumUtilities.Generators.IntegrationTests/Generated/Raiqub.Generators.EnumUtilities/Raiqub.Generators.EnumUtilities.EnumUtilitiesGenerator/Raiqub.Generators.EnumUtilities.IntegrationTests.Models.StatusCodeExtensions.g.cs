﻿// <auto-generated />
#nullable enable

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Raiqub.Generators.EnumUtilities.Formatters;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.9.0.0")]
    public static partial class StatusCodeExtensions
    {
        /// <summary>Converts the value of this instance to its equivalent string representation.</summary>
        /// <returns>The string representation of the value of this instance.</returns>
        public static string ToStringFast(this StatusCode value)
        {
            return GetNameInlined((int)value)
                ?? ((int)value).ToString();
        }

        /// <summary>Calculates the number of characters produced by converting the specified value to string.</summary>
        /// <param name="value">The value to calculate the number of characters.</param>
        /// <returns>The number of characters produced by converting the specified value to string.</returns>
        public static int GetStringLength(this StatusCode value)
        {
            return GetNameLengthInlined((int)value)
                ?? EnumNumericFormatter.GetStringLength((int)value);
        }

        /// <summary>Returns a boolean telling whether the value of this instance exists in the enumeration.</summary>
        /// <returns><c>true</c> if the value of this instance exists in the enumeration; <c>false</c> otherwise.</returns>
        public static bool IsDefined(this StatusCode value)
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

        private static int? GetNameLengthInlined(int value)
        {
            return value switch
            {
                -1 => 7,
                0 => 7,
                -2 => 5,
                -3 => 8,
                -4 => 7,
                -5 => 12,
                -6 => 9,
                -7 => 8,
                -8 => 4,
                -9 => 14,
                -10 => 11,
                _ => null
            };
        }

        private static string? GetNameInlined(int value)
        {
            return value switch
            {
                -1 => "Unknown",
                0 => "Success",
                -2 => "Error",
                -3 => "NotFound",
                -4 => "Timeout",
                -5 => "Unauthorized",
                -6 => "Forbidden",
                -7 => "Conflict",
                -8 => "Gone",
                -9 => "InvalidRequest",
                -10 => "ServerError",
                _ => null
            };
        }

        /// <summary>Adds two enumerations and replaces the first integer with the sum, as an atomic operation.</summary>
        /// <param name="location">A variable containing the first value to be added.</param>
        /// <param name="value">The value to be added to the enumeration at <paramref name="location" />.</param>
        /// <returns>The new value that was stored at <paramref name="location" /> by this operation.</returns>
        public static StatusCode InterlockedAdd(this ref StatusCode location, int value)
        {
            ref int locationRaw = ref Unsafe.As<StatusCode, int>(ref location);
            int resultRaw = Interlocked.Add(ref locationRaw, value);
            return Unsafe.As<int, StatusCode>(ref resultRaw);
        }

        /// <summary>Decrements enumeration and stores the result, as an atomic operation.</summary>
        /// <param name="location">The variable whose value is to be decremented.</param>
        /// <returns>The value of the variable immediately after the decrement operation finished.</returns>
        public static StatusCode InterlockedDecrement(this ref StatusCode location)
        {
            ref int locationRaw = ref Unsafe.As<StatusCode, int>(ref location);
            int resultRaw = Interlocked.Decrement(ref locationRaw);
            return Unsafe.As<int, StatusCode>(ref resultRaw);
        }

        /// <summary>Increments enumeration and stores the result, as an atomic operation.</summary>
        /// <param name="location">The variable whose value is to be incremented.</param>
        /// <returns>The value of the variable immediately after the increment operation finished.</returns>
        public static StatusCode InterlockedIncrement(this ref StatusCode location)
        {
            ref int locationRaw = ref Unsafe.As<StatusCode, int>(ref location);
            int resultRaw = Interlocked.Increment(ref locationRaw);
            return Unsafe.As<int, StatusCode>(ref resultRaw);
        }

        /// <summary>Compares two enumerations for equality and, if they are equal, replaces the first value.</summary>
        /// <param name="location">The destination, whose value is compared with <paramref name="comparand" /> and possibly replaced.</param>
        /// <param name="value">The value that replaces the destination value if the comparison results in equality.</param>
        /// <param name="comparand">The value that is compared to the value at <paramref name="location" />.</param>
        /// <returns>The original value in <paramref name="location" />.</returns>
        public static StatusCode InterlockedCompareExchange(this ref StatusCode location, StatusCode value, StatusCode comparand)
        {
            ref int locationRaw = ref Unsafe.As<StatusCode, int>(ref location);
            int resultRaw = Interlocked.CompareExchange(ref locationRaw, Unsafe.As<StatusCode, int>(ref value), Unsafe.As<StatusCode, int>(ref comparand));
            return Unsafe.As<int, StatusCode>(ref resultRaw);
        }

        /// <summary>Sets an enumeration value to a specified value and returns the original value, as an atomic operation.</summary>
        /// <param name="location">The variable to set to the specified value.</param>
        /// <param name="value">The value to which the <paramref name="location" /> parameter is set.</param>
        /// <returns>The original value of <paramref name="location" />.</returns>
        public static StatusCode InterlockedExchange(this ref StatusCode location, StatusCode value)
        {
            ref int locationRaw = ref Unsafe.As<StatusCode, int>(ref location);
            int resultRaw = Interlocked.Exchange(ref locationRaw, Unsafe.As<StatusCode, int>(ref value));
            return Unsafe.As<int, StatusCode>(ref resultRaw);
        }

        public static string ToEnumMemberValue(this StatusCode value)
        {
            return GetEnumMemberValueInlined((int)value)
                ?? ((int)value).ToString();
        }

        public static int GetEnumMemberValueStringLength(this StatusCode value)
        {
            return GetEnumMemberValueLengthInlined((int)value)
                ?? EnumNumericFormatter.GetStringLength((int)value);
        }

        private static int? GetEnumMemberValueLengthInlined(int value)
        {
            return value switch
            {
                -1 => 7,
                0 => 7,
                -2 => 5,
                -3 => 9,
                -4 => 7,
                -5 => 12,
                -6 => 9,
                -7 => 8,
                -8 => 4,
                -9 => 14,
                -10 => 11,
                _ => null
            };
        }

        private static string? GetEnumMemberValueInlined(int value)
        {
            return value switch
            {
                -1 => "Unknown",
                0 => "Success",
                -2 => "Error",
                -3 => "Not Found",
                -4 => "Timeout",
                -5 => "Unauthorized",
                -6 => "Forbidden",
                -7 => "Conflict",
                -8 => "Gone",
                -9 => "InvalidRequest",
                -10 => "ServerError",
                _ => null
            };
        }

        public static string GetDisplayShortName(this StatusCode value)
        {
            return (int)value switch
            {
                _ => GetDisplayName(value)
            };
        }

        public static string GetDisplayName(this StatusCode value)
        {
            return (int)value switch
            {
                -1 => "Unknown",
                0 => "Success",
                -2 => "Error",
                -3 => "NotFound",
                -4 => "Timeout",
                -5 => "Unauthorized",
                -6 => "Forbidden",
                -7 => "Conflict",
                -8 => "Gone",
                -9 => "Invalid request",
                -10 => "ServerError",
                _ => ToStringFast(value)
            };
        }

        public static string? GetDescription(this StatusCode value)
        {
            return (int)value switch
            {
                -9 => "The request is invalid",
                _ => null
            };
        }
    }
}
