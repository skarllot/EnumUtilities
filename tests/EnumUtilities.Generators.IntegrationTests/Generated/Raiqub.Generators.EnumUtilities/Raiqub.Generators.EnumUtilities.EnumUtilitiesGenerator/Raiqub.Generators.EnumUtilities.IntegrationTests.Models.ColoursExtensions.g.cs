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
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.8.0.0")]
    public static partial class ColoursExtensions
    {
        /// <summary>Converts the value of this instance to its equivalent string representation.</summary>
        /// <returns>The string representation of the value of this instance.</returns>
        public static string ToStringFast(this Colours value)
        {
            return FormatFlagNames((int)value)
                ?? ((int)value).ToString();
        }

        /// <summary>Determines whether one or more bit fields are set in the current instance.</summary>
        /// <param name="flag">An enumeration value.</param>
        /// <returns><see langword="true"/> if the bit field or bit fields that are set in flag are also set in the current instance; otherwise, <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasFlagFast(this Colours value, Colours flag)
        {
            return (value & flag) == flag;
        }

        /// <summary>Calculates the number of characters produced by converting the specified value to string.</summary>
        /// <param name="value">The value to calculate the number of characters.</param>
        /// <returns>The number of characters produced by converting the specified value to string.</returns>
        public static int GetStringLength(this Colours value)
        {
            return FormatFlagNamesLength((int)value)
                ?? EnumNumericFormatter.GetStringLength((int)value);
        }

        /// <summary>Returns a boolean telling whether the value of this instance exists in the enumeration.</summary>
        /// <returns><c>true</c> if the value of this instance exists in the enumeration; <c>false</c> otherwise.</returns>
        public static bool IsDefined(this Colours value)
        {
            return (int)value switch
            {
                1 => true,
                2 => true,
                4 => true,
                _ => false
            };
        }

        private static int? FormatFlagNamesLength(int value)
        {
            int? fastResult = GetNameLengthInlined(value);
            if (fastResult is not null)
            {
                return fastResult.Value;
            }

            if (value == 0)
            {
                return 1;
            }

            int count = 0, foundItemsCount = 0;
            if (true)
            {
                if ((value & 4) == 4)
                {
                    value -= 4;
                    count = checked(count + 5);
                    foundItemsCount++;
                    if (value == 0) goto CountLength;
                }
                if ((value & 2) == 2)
                {
                    value -= 2;
                    count = checked(count + 4);
                    foundItemsCount++;
                    if (value == 0) goto CountLength;
                }
                if ((value & 1) == 1)
                {
                    value -= 1;
                    count = checked(count + 3);
                    foundItemsCount++;
                    if (value == 0) goto CountLength;
                }
            }

            if (value != 0)
            {
                return null;
            }

    CountLength:
            const int separatorStringLength = 2;
            return checked(count + (separatorStringLength * (foundItemsCount - 1)));
        }

        private static string? FormatFlagNames(int value)
        {
            string? result = GetNameInlined(value);
            if (result is null)
            {
                var rented = System.Buffers.ArrayPool<string>.Shared.Rent(3);
                try
                {
                    Span<string> foundItems = new Span<string>(rented, 0, 3);
                    if (TryFindFlagsNames(value, foundItems, out int foundItemsCount, out int resultLength))
                    {
                        result = EnumStringFormatter.WriteMultipleFoundFlagsNames(foundItems, foundItemsCount, resultLength);
                    }
                }
                finally
                {
                    System.Buffers.ArrayPool<string>.Shared.Return(rented);
                }
            }

            return result;
        }

        private static bool TryFindFlagsNames(int value, Span<string> foundItems, out int foundItemsCount, out int resultLength)
        {
            resultLength = 0;
            foundItemsCount = 0;
            if (true)
            {
                if ((value & 4) == 4)
                {
                    value -= 4;
                    resultLength = checked(resultLength + 5);
                    foundItems[foundItemsCount++] = "Green";
                    if (value == 0) return true;
                }
                if ((value & 2) == 2)
                {
                    value -= 2;
                    resultLength = checked(resultLength + 4);
                    foundItems[foundItemsCount++] = "Blue";
                    if (value == 0) return true;
                }
                if ((value & 1) == 1)
                {
                    value -= 1;
                    resultLength = checked(resultLength + 3);
                    foundItems[foundItemsCount++] = "Red";
                    if (value == 0) return true;
                }
            }

            return value == 0;
        }

        private static int? GetNameLengthInlined(int value)
        {
            return value switch
            {
                0 => 1,
                1 => 3,
                2 => 4,
                4 => 5,
                _ => null
            };
        }

        private static string? GetNameInlined(int value)
        {
            return value switch
            {
                0 => "0",
                1 => "Red",
                2 => "Blue",
                4 => "Green",
                _ => null
            };
        }

    #if NET5_0_OR_GREATER
        /// <summary>Bitwise "ands" two enumerations and replaces the first value with the result, as an atomic operation.</summary>
        /// <param name="location">A variable containing the first value to be combined.</param>
        /// <param name="value">The value to be combined with the value at <paramref name="location" />.</param>
        /// <returns>The original value in <paramref name="location" />.</returns>
        public static Colours InterlockedAnd(this ref Colours location, Colours value)
        {
            ref int locationRaw = ref Unsafe.As<Colours, int>(ref location);
            int resultRaw = Interlocked.And(ref locationRaw, Unsafe.As<Colours, int>(ref value));
            return Unsafe.As<int, Colours>(ref resultRaw);
        }

        /// <summary>Bitwise "ors" two enumerations and replaces the first value with the result, as an atomic operation.</summary>
        /// <param name="location">A variable containing the first value to be combined.</param>
        /// <param name="value">The value to be combined with the value at <paramref name="location" />.</param>
        /// <returns>The original value in <paramref name="location" />.</returns>
        public static Colours InterlockedOr(this ref Colours location, Colours value)
        {
            ref int locationRaw = ref Unsafe.As<Colours, int>(ref location);
            int resultRaw = Interlocked.Or(ref locationRaw, Unsafe.As<Colours, int>(ref value));
            return Unsafe.As<int, Colours>(ref resultRaw);
        }
    #endif

        /// <summary>Compares two enumerations for equality and, if they are equal, replaces the first value.</summary>
        /// <param name="location">The destination, whose value is compared with <paramref name="comparand" /> and possibly replaced.</param>
        /// <param name="value">The value that replaces the destination value if the comparison results in equality.</param>
        /// <param name="comparand">The value that is compared to the value at <paramref name="location" />.</param>
        /// <returns>The original value in <paramref name="location" />.</returns>
        public static Colours InterlockedCompareExchange(this ref Colours location, Colours value, Colours comparand)
        {
            ref int locationRaw = ref Unsafe.As<Colours, int>(ref location);
            int resultRaw = Interlocked.CompareExchange(ref locationRaw, Unsafe.As<Colours, int>(ref value), Unsafe.As<Colours, int>(ref comparand));
            return Unsafe.As<int, Colours>(ref resultRaw);
        }

        /// <summary>Sets an enumeration value to a specified value and returns the original value, as an atomic operation.</summary>
        /// <param name="location">The variable to set to the specified value.</param>
        /// <param name="value">The value to which the <paramref name="location" /> parameter is set.</param>
        /// <returns>The original value of <paramref name="location" />.</returns>
        public static Colours InterlockedExchange(this ref Colours location, Colours value)
        {
            ref int locationRaw = ref Unsafe.As<Colours, int>(ref location);
            int resultRaw = Interlocked.Exchange(ref locationRaw, Unsafe.As<Colours, int>(ref value));
            return Unsafe.As<int, Colours>(ref resultRaw);
        }
    }
}
