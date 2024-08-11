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
    public static partial class HumanStatesEnumInfo
    {
        /// <summary>Provides constant values for <see cref="HumanStates" /> names.</summary>
        public static partial class Name
        {
            /// <summary>Represents the largest possible number of characters produced by converting an <see cref="HumanStates" /> value to string, based on defined members. This field is constant.</summary>
            public const int MaxCharsLength = 8;

            /// <summary>The string representation of <see cref="HumanStates.Idle" /> name.</summary>
            public const string Idle = "Idle";

            /// <summary>The string representation of <see cref="HumanStates.Working" /> name.</summary>
            public const string Working = "Working";

            /// <summary>The string representation of <see cref="HumanStates.Sleeping" /> name.</summary>
            public const string Sleeping = "Sleeping";

            /// <summary>The string representation of <see cref="HumanStates.Eating" /> name.</summary>
            public const string Eating = "Eating";

            /// <summary>The string representation of <see cref="HumanStates.Dead" /> name.</summary>
            public const string Dead = "Dead";

            /// <summary>The string representation of <see cref="HumanStates.Relaxing" /> name.</summary>
            public const string Relaxing = "Relaxing";

            private static string[]? s_names;

            /// <summary>Retrieves the names of the constants in <see cref="HumanStates" /> enumeration.</summary>
            /// <returns>The names of the constants in <see cref="HumanStates" />.</returns>
            public static ReadOnlyMemory<string> GetNames()
            {
                return s_names ??= new string[]
                {
                    "Idle",
                    "Working",
                    "Sleeping",
                    "Eating",
                    "Dead",
                    "Relaxing",
                };
            }
        }

        /// <summary>Provides support for formatting <see cref="HumanStates"/> values.</summary>
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
                    1 => 4,
                    2 => 7,
                    3 => 8,
                    4 => 6,
                    5 => 4,
                    _ => null
                };
            }

            /// <inheritdoc />
            public string? TryGetStringForMember(int value)
            {
                return value switch
                {
                    1 => "Idle",
                    2 => "Working",
                    3 => "Sleeping",
                    4 => "Eating",
                    5 => "Dead",
                    _ => null
                };
            }
        }

        /// <summary>Provides support for parsing <see cref="HumanStates"/> values.</summary>
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
                    case { } when value.SequenceEqual("Idle"):
                        result = 1;
                        return true;
                    case { } when value.SequenceEqual("Working"):
                        result = 2;
                        return true;
                    case { } when value.SequenceEqual("Sleeping"):
                        result = 3;
                        return true;
                    case { } when value.SequenceEqual("Eating"):
                        result = 4;
                        return true;
                    case { } when value.SequenceEqual("Dead"):
                        result = 5;
                        return true;
                    case { } when value.SequenceEqual("Relaxing"):
                        result = 1;
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
                    case { } when value.Equals("Idle", comparisonType):
                        result = 1;
                        return true;
                    case { } when value.Equals("Working", comparisonType):
                        result = 2;
                        return true;
                    case { } when value.Equals("Sleeping", comparisonType):
                        result = 3;
                        return true;
                    case { } when value.Equals("Eating", comparisonType):
                        result = 4;
                        return true;
                    case { } when value.Equals("Dead", comparisonType):
                        result = 5;
                        return true;
                    case { } when value.Equals("Relaxing", comparisonType):
                        result = 1;
                        return true;
                    default:
                        result = 0;
                        return false;
                }
            }
        }
    }
}
