﻿// <auto-generated />
#nullable enable

using System;
using System.Runtime.CompilerServices;
using System.Threading;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.6.0.0")]
    internal static partial class MyEnum2Extensions
    {
        /// <summary>Converts the value of this instance to its equivalent string representation.</summary>
        /// <returns>The string representation of the value of this instance.</returns>
        public static string ToStringFast(this NestedInClass.MyEnum2 value)
        {
            return (int)value switch
            {
                0 => "Credit",
                1 => "Debit",
                2 => "Cash",
                3 => "Cheque",
                _ => value.ToString()
            };
        }

        /// <summary>Returns a boolean telling whether the value of this instance exists in the enumeration.</summary>
        /// <returns><c>true</c> if the value of this instance exists in the enumeration; <c>false</c> otherwise.</returns>
        public static bool IsDefined(this NestedInClass.MyEnum2 value)
        {
            return MyEnum2Validation.IsDefined(value);
        }

        /// <summary>Adds two enumerations and replaces the first integer with the sum, as an atomic operation.</summary>
        /// <param name="location">A variable containing the first value to be added.</param>
        /// <param name="value">The value to be added to the enumeration at <paramref name="location" />.</param>
        /// <returns>The new value that was stored at <paramref name="location" /> by this operation.</returns>
        public static NestedInClass.MyEnum2 InterlockedAdd(this ref NestedInClass.MyEnum2 location, int value)
        {
            ref int locationRaw = ref Unsafe.As<NestedInClass.MyEnum2, int>(ref location);
            int resultRaw = Interlocked.Add(ref locationRaw, value);
            return Unsafe.As<int, NestedInClass.MyEnum2>(ref resultRaw);
        }

        /// <summary>Decrements enumeration and stores the result, as an atomic operation.</summary>
        /// <param name="location">The variable whose value is to be decremented.</param>
        /// <returns>The value of the variable immediately after the decrement operation finished.</returns>
        public static NestedInClass.MyEnum2 InterlockedDecrement(this ref NestedInClass.MyEnum2 location)
        {
            ref int locationRaw = ref Unsafe.As<NestedInClass.MyEnum2, int>(ref location);
            int resultRaw = Interlocked.Decrement(ref locationRaw);
            return Unsafe.As<int, NestedInClass.MyEnum2>(ref resultRaw);
        }

        /// <summary>Increments enumeration and stores the result, as an atomic operation.</summary>
        /// <param name="location">The variable whose value is to be incremented.</param>
        /// <returns>The value of the variable immediately after the increment operation finished.</returns>
        public static NestedInClass.MyEnum2 InterlockedIncrement(this ref NestedInClass.MyEnum2 location)
        {
            ref int locationRaw = ref Unsafe.As<NestedInClass.MyEnum2, int>(ref location);
            int resultRaw = Interlocked.Increment(ref locationRaw);
            return Unsafe.As<int, NestedInClass.MyEnum2>(ref resultRaw);
        }

        /// <summary>Compares two enumerations for equality and, if they are equal, replaces the first value.</summary>
        /// <param name="location">The destination, whose value is compared with <paramref name="comparand" /> and possibly replaced.</param>
        /// <param name="value">The value that replaces the destination value if the comparison results in equality.</param>
        /// <param name="comparand">The value that is compared to the value at <paramref name="location" />.</param>
        /// <returns>The original value in <paramref name="location" />.</returns>
        public static NestedInClass.MyEnum2 InterlockedCompareExchange(this ref NestedInClass.MyEnum2 location, NestedInClass.MyEnum2 value, NestedInClass.MyEnum2 comparand)
        {
            ref int locationRaw = ref Unsafe.As<NestedInClass.MyEnum2, int>(ref location);
            int resultRaw = Interlocked.CompareExchange(ref locationRaw, Unsafe.As<NestedInClass.MyEnum2, int>(ref value), Unsafe.As<NestedInClass.MyEnum2, int>(ref comparand));
            return Unsafe.As<int, NestedInClass.MyEnum2>(ref resultRaw);
        }

        /// <summary>Sets an enumeration value to a specified value and returns the original value, as an atomic operation.</summary>
        /// <param name="location">The variable to set to the specified value.</param>
        /// <param name="value">The value to which the <paramref name="location" /> parameter is set.</param>
        /// <returns>The original value of <paramref name="location" />.</returns>
        public static NestedInClass.MyEnum2 InterlockedExchange(this ref NestedInClass.MyEnum2 location, NestedInClass.MyEnum2 value)
        {
            ref int locationRaw = ref Unsafe.As<NestedInClass.MyEnum2, int>(ref location);
            int resultRaw = Interlocked.Exchange(ref locationRaw, Unsafe.As<NestedInClass.MyEnum2, int>(ref value));
            return Unsafe.As<int, NestedInClass.MyEnum2>(ref resultRaw);
        }

        public static string ToEnumMemberValue(this NestedInClass.MyEnum2 value)
        {
            return (int)value switch
            {
                0 => "Credit card",
                1 => "Debit card",
                2 => "Cash",
                3 => "Cheque",
                _ => value.ToString()
            };
        }

        public static string? GetDescription(this NestedInClass.MyEnum2 value)
        {
            return (int)value switch
            {
                2 => "The payment by using physical cash",
                _ => null
            };
        }

        public static string GetDisplayShortName(this NestedInClass.MyEnum2 value)
        {
            return (int)value switch
            {
                _ => GetDisplayName(value)
            };
        }

        public static string GetDisplayName(this NestedInClass.MyEnum2 value)
        {
            return (int)value switch
            {
                0 => "Credit Card",
                1 => "Debit Card",
                2 => "Physical Cash",
                3 => "Cheque",
                _ => value.ToString()
            };
        }
    }
}
