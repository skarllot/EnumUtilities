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
    public static partial class HumanStatesMetadata
    {
        /// <summary>Provides constant values for <see cref="HumanStates" /> members names.</summary>
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
        }

        /// <summary>Provides static values for <see cref="HumanStates" /> UTF-8 encoded members names.</summary>
        public static partial class Utf8Name
        {
            /// <summary>Represents the largest possible number of bytes produced by converting an <see cref="HumanStates" /> value to UTF-8 string, based on defined members. This field is constant.</summary>
            public const int MaxBytesLength = 8;

            /// <summary>The UTF-8 representation of <see cref="HumanStates.Idle" /> name.</summary>
            public static ReadOnlySpan<byte> Idle => new byte[4] { 73, 100, 108, 101 };

            /// <summary>The UTF-8 representation of <see cref="HumanStates.Working" /> name.</summary>
            public static ReadOnlySpan<byte> Working => new byte[7] { 87, 111, 114, 107, 105, 110, 103 };

            /// <summary>The UTF-8 representation of <see cref="HumanStates.Sleeping" /> name.</summary>
            public static ReadOnlySpan<byte> Sleeping => new byte[8] { 83, 108, 101, 101, 112, 105, 110, 103 };

            /// <summary>The UTF-8 representation of <see cref="HumanStates.Eating" /> name.</summary>
            public static ReadOnlySpan<byte> Eating => new byte[6] { 69, 97, 116, 105, 110, 103 };

            /// <summary>The UTF-8 representation of <see cref="HumanStates.Dead" /> name.</summary>
            public static ReadOnlySpan<byte> Dead => new byte[4] { 68, 101, 97, 100 };

            /// <summary>The UTF-8 representation of <see cref="HumanStates.Relaxing" /> name.</summary>
            public static ReadOnlySpan<byte> Relaxing => new byte[8] { 82, 101, 108, 97, 120, 105, 110, 103 };
        }

        /// <summary>Provides support for formatting <see cref="HumanStates"/> values.</summary>
        internal sealed partial class StringFormatter : IEnumFormatter<int>
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
        internal sealed partial class StringParser
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
            public bool TryParseSingleName(ReadOnlySpan<char> value, StringComparison comparisonType, out int result)
            {
                if (value.IsEmpty)
                {
                    result = 0;
                    return false;
                }

                switch (value[0])
                {
                    case 'I':
                    case 'i':
                        switch (value)
                        {
                            case { } when value.Equals("Idle", comparisonType):
                                result = 1;
                                return true;
                        }
                        goto default;
                    case 'W':
                    case 'w':
                        switch (value)
                        {
                            case { } when value.Equals("Working", comparisonType):
                                result = 2;
                                return true;
                        }
                        goto default;
                    case 'S':
                    case 's':
                        switch (value)
                        {
                            case { } when value.Equals("Sleeping", comparisonType):
                                result = 3;
                                return true;
                        }
                        goto default;
                    case 'E':
                    case 'e':
                        switch (value)
                        {
                            case { } when value.Equals("Eating", comparisonType):
                                result = 4;
                                return true;
                        }
                        goto default;
                    case 'D':
                    case 'd':
                        switch (value)
                        {
                            case { } when value.Equals("Dead", comparisonType):
                                result = 5;
                                return true;
                        }
                        goto default;
                    case 'R':
                    case 'r':
                        switch (value)
                        {
                            case { } when value.Equals("Relaxing", comparisonType):
                                result = 1;
                                return true;
                        }
                        goto default;
                    default:
                        result = 0;
                        return false;
                }
            }
        }
    }
}
