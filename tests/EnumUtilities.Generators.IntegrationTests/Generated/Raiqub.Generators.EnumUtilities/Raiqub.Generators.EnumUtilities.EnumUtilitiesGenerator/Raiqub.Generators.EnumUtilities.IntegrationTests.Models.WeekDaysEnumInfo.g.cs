﻿// <auto-generated />
#nullable enable

using System;
using System.Runtime.CompilerServices;
using Raiqub.Generators.EnumUtilities.Formatters;
using Raiqub.Generators.EnumUtilities.Parsers;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.8.0.0")]
    public static partial class WeekDaysMetadata
    {
        /// <summary>Provides constant values for <see cref="WeekDays" /> members names.</summary>
        public static partial class Name
        {
            /// <summary>Represents the largest possible number of characters produced by converting an <see cref="WeekDays" /> value to string, based on defined members. This field is constant.</summary>
            public const int MaxCharsLength = 9;

            /// <summary>The string representation of <see cref="WeekDays.Monday" /> name.</summary>
            public const string Monday = "Monday";

            /// <summary>The string representation of <see cref="WeekDays.Tuesday" /> name.</summary>
            public const string Tuesday = "Tuesday";

            /// <summary>The string representation of <see cref="WeekDays.Wednesday" /> name.</summary>
            public const string Wednesday = "Wednesday";

            /// <summary>The string representation of <see cref="WeekDays.Thursday" /> name.</summary>
            public const string Thursday = "Thursday";

            /// <summary>The string representation of <see cref="WeekDays.Friday" /> name.</summary>
            public const string Friday = "Friday";

            /// <summary>The string representation of <see cref="WeekDays.Saturday" /> name.</summary>
            public const string Saturday = "Saturday";

            /// <summary>The string representation of <see cref="WeekDays.Sunday" /> name.</summary>
            public const string Sunday = "Sunday";
        }

        /// <summary>Provides static values for <see cref="WeekDays" /> UTF-8 encoded members names.</summary>
        public static partial class Utf8Name
        {
            /// <summary>Represents the largest possible number of bytes produced by converting an <see cref="WeekDays" /> value to UTF-8 string, based on defined members. This field is constant.</summary>
            public const int MaxBytesLength = 9;

            /// <summary>The UTF-8 representation of <see cref="WeekDays.Monday" /> name.</summary>
            public static ReadOnlySpan<byte> Monday => new byte[6] { 77, 111, 110, 100, 97, 121 };

            /// <summary>The UTF-8 representation of <see cref="WeekDays.Tuesday" /> name.</summary>
            public static ReadOnlySpan<byte> Tuesday => new byte[7] { 84, 117, 101, 115, 100, 97, 121 };

            /// <summary>The UTF-8 representation of <see cref="WeekDays.Wednesday" /> name.</summary>
            public static ReadOnlySpan<byte> Wednesday => new byte[9] { 87, 101, 100, 110, 101, 115, 100, 97, 121 };

            /// <summary>The UTF-8 representation of <see cref="WeekDays.Thursday" /> name.</summary>
            public static ReadOnlySpan<byte> Thursday => new byte[8] { 84, 104, 117, 114, 115, 100, 97, 121 };

            /// <summary>The UTF-8 representation of <see cref="WeekDays.Friday" /> name.</summary>
            public static ReadOnlySpan<byte> Friday => new byte[6] { 70, 114, 105, 100, 97, 121 };

            /// <summary>The UTF-8 representation of <see cref="WeekDays.Saturday" /> name.</summary>
            public static ReadOnlySpan<byte> Saturday => new byte[8] { 83, 97, 116, 117, 114, 100, 97, 121 };

            /// <summary>The UTF-8 representation of <see cref="WeekDays.Sunday" /> name.</summary>
            public static ReadOnlySpan<byte> Sunday => new byte[6] { 83, 117, 110, 100, 97, 121 };
        }

        /// <summary>Provides support for formatting <see cref="WeekDays"/> values.</summary>
        public sealed partial class StringFormatter : IEnumFormatter<int>
        {
            /// <summary>Gets the singleton instance of the <see cref="StringFormatter"/> class.</summary>
            public static StringFormatter Instance = new StringFormatter();

            /// <inheritdoc />
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int GetStringLengthForNumber(int value) => EnumNumericFormatter.GetStringLength(value);

            /// <inheritdoc />
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public string GetStringForNumber(int value) => value.ToString();

            /// <inheritdoc />
            public int? TryGetStringLengthForMember(int value)
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

            /// <inheritdoc />
            public string? TryGetStringForMember(int value)
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
        }

        /// <summary>Provides support for parsing <see cref="WeekDays"/> values.</summary>
        public sealed partial class StringParser
            : IEnumParser<int>
        {
            /// <summary>Gets the singleton instance of the <see cref="StringParser"/> class.</summary>
            public static StringParser Instance = new StringParser();

            /// <inheritdoc />
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int BitwiseOr(int value1, int value2) => unchecked((int)(value1 | value2));

            /// <inheritdoc />
            public bool TryParseNumber(ReadOnlySpan<char> value, out int result) => EnumNumericParser.TryParse(value, out result);

            /// <inheritdoc />
            public bool TryParseSingleName(ReadOnlySpan<char> value, bool ignoreCase, out int result)
            {
                return ignoreCase
                    ? TryParse(value, out result)
                    : TryParse(value, StringComparison.OrdinalIgnoreCase, out result);
            }

            /// <inheritdoc />
            public bool TryParseSingleName(ReadOnlySpan<char> value, StringComparison comparisonType, out int result)
            {
                return TryParse(value, comparisonType, out result);
            }

            private bool TryParse(ReadOnlySpan<char> value, out int result)
            {
                switch (value)
                {
                    case { } when value.SequenceEqual("Monday"):
                        result = 0;
                        return true;
                    case { } when value.SequenceEqual("Tuesday"):
                        result = 1;
                        return true;
                    case { } when value.SequenceEqual("Wednesday"):
                        result = 2;
                        return true;
                    case { } when value.SequenceEqual("Thursday"):
                        result = 3;
                        return true;
                    case { } when value.SequenceEqual("Friday"):
                        result = 4;
                        return true;
                    case { } when value.SequenceEqual("Saturday"):
                        result = 5;
                        return true;
                    case { } when value.SequenceEqual("Sunday"):
                        result = 6;
                        return true;
                    default:
                        result = 0;
                        return false;
                }
            }

            private bool TryParse(ReadOnlySpan<char> value, StringComparison comparisonType, out int result)
            {
                switch (value)
                {
                    case { } when value.Equals("Monday", comparisonType):
                        result = 0;
                        return true;
                    case { } when value.Equals("Tuesday", comparisonType):
                        result = 1;
                        return true;
                    case { } when value.Equals("Wednesday", comparisonType):
                        result = 2;
                        return true;
                    case { } when value.Equals("Thursday", comparisonType):
                        result = 3;
                        return true;
                    case { } when value.Equals("Friday", comparisonType):
                        result = 4;
                        return true;
                    case { } when value.Equals("Saturday", comparisonType):
                        result = 5;
                        return true;
                    case { } when value.Equals("Sunday", comparisonType):
                        result = 6;
                        return true;
                    default:
                        result = 0;
                        return false;
                }
            }
        }
    }
}
