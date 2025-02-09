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
    public static partial class WeekDaysExtensions
    {
        /// <summary>Converts the value of this instance to its equivalent string representation.</summary>
        /// <returns>The string representation of the value of this instance.</returns>
        public static string ToStringFast(this WeekDays value)
        {
            return GetNameInlined((int)value)
                ?? ((int)value).ToString();
        }

        /// <summary>Calculates the number of characters produced by converting the specified value to string.</summary>
        /// <param name="value">The value to calculate the number of characters.</param>
        /// <returns>The number of characters produced by converting the specified value to string.</returns>
        public static int GetStringLength(this WeekDays value)
        {
            return GetNameLengthInlined((int)value)
                ?? EnumNumericFormatter.GetStringLength((int)value);
        }

        /// <summary>Returns a boolean telling whether the value of this instance exists in the enumeration.</summary>
        /// <returns><c>true</c> if the value of this instance exists in the enumeration; <c>false</c> otherwise.</returns>
        public static bool IsDefined(this WeekDays value)
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

        private static int? GetNameLengthInlined(int value)
        {
            return value switch
            {
                0 => 6,
                1 => 7,
                2 => 9,
                3 => 8,
                4 => 6,
                5 => 8,
                6 => 6,
                _ => null
            };
        }

        private static string? GetNameInlined(int value)
        {
            return value switch
            {
                0 => "Monday",
                1 => "Tuesday",
                2 => "Wednesday",
                3 => "Thursday",
                4 => "Friday",
                5 => "Saturday",
                6 => "Sunday",
                _ => null
            };
        }

        /// <summary>Adds two enumerations and replaces the first integer with the sum, as an atomic operation.</summary>
        /// <param name="location">A variable containing the first value to be added.</param>
        /// <param name="value">The value to be added to the enumeration at <paramref name="location" />.</param>
        /// <returns>The new value that was stored at <paramref name="location" /> by this operation.</returns>
        public static WeekDays InterlockedAdd(this ref WeekDays location, int value)
        {
            ref int locationRaw = ref Unsafe.As<WeekDays, int>(ref location);
            int resultRaw = Interlocked.Add(ref locationRaw, value);
            return Unsafe.As<int, WeekDays>(ref resultRaw);
        }

        /// <summary>Decrements enumeration and stores the result, as an atomic operation.</summary>
        /// <param name="location">The variable whose value is to be decremented.</param>
        /// <returns>The value of the variable immediately after the decrement operation finished.</returns>
        public static WeekDays InterlockedDecrement(this ref WeekDays location)
        {
            ref int locationRaw = ref Unsafe.As<WeekDays, int>(ref location);
            int resultRaw = Interlocked.Decrement(ref locationRaw);
            return Unsafe.As<int, WeekDays>(ref resultRaw);
        }

        /// <summary>Increments enumeration and stores the result, as an atomic operation.</summary>
        /// <param name="location">The variable whose value is to be incremented.</param>
        /// <returns>The value of the variable immediately after the increment operation finished.</returns>
        public static WeekDays InterlockedIncrement(this ref WeekDays location)
        {
            ref int locationRaw = ref Unsafe.As<WeekDays, int>(ref location);
            int resultRaw = Interlocked.Increment(ref locationRaw);
            return Unsafe.As<int, WeekDays>(ref resultRaw);
        }

        /// <summary>Compares two enumerations for equality and, if they are equal, replaces the first value.</summary>
        /// <param name="location">The destination, whose value is compared with <paramref name="comparand" /> and possibly replaced.</param>
        /// <param name="value">The value that replaces the destination value if the comparison results in equality.</param>
        /// <param name="comparand">The value that is compared to the value at <paramref name="location" />.</param>
        /// <returns>The original value in <paramref name="location" />.</returns>
        public static WeekDays InterlockedCompareExchange(this ref WeekDays location, WeekDays value, WeekDays comparand)
        {
            ref int locationRaw = ref Unsafe.As<WeekDays, int>(ref location);
            int resultRaw = Interlocked.CompareExchange(ref locationRaw, Unsafe.As<WeekDays, int>(ref value), Unsafe.As<WeekDays, int>(ref comparand));
            return Unsafe.As<int, WeekDays>(ref resultRaw);
        }

        /// <summary>Sets an enumeration value to a specified value and returns the original value, as an atomic operation.</summary>
        /// <param name="location">The variable to set to the specified value.</param>
        /// <param name="value">The value to which the <paramref name="location" /> parameter is set.</param>
        /// <returns>The original value of <paramref name="location" />.</returns>
        public static WeekDays InterlockedExchange(this ref WeekDays location, WeekDays value)
        {
            ref int locationRaw = ref Unsafe.As<WeekDays, int>(ref location);
            int resultRaw = Interlocked.Exchange(ref locationRaw, Unsafe.As<WeekDays, int>(ref value));
            return Unsafe.As<int, WeekDays>(ref resultRaw);
        }

        public static string GetDisplayShortName(this WeekDays value)
        {
            return (int)value switch
            {
                0 => Raiqub.Generators.EnumUtilities.IntegrationTests.Strings.MondayShort,
                1 => "Tue",
                4 => "Fri",
                5 => "Sat",
                _ => GetDisplayName(value)
            };
        }

        public static string GetDisplayName(this WeekDays value)
        {
            return (int)value switch
            {
                0 => Raiqub.Generators.EnumUtilities.IntegrationTests.Strings.MondayFull,
                1 => "Tuesday",
                2 => "Wednesday",
                3 => "Thursday",
                4 => "Friday",
                5 => "Saturday",
                6 => "Sunday",
                _ => ToStringFast(value)
            };
        }

        public static string? GetDescription(this WeekDays value)
        {
            return (int)value switch
            {
                0 => Raiqub.Generators.EnumUtilities.IntegrationTests.Strings.MondayDescription,
                5 => "Almost the last day of the week",
                6 => "The last day of the week",
                _ => null
            };
        }
    }
}
