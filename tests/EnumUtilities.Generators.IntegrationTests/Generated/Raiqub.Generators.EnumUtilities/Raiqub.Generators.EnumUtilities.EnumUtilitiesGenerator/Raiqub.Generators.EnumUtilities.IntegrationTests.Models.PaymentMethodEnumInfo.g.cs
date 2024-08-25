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
    public static partial class PaymentMethodMetadata
    {
        /// <summary>Provides constant values for <see cref="PaymentMethod" /> members names.</summary>
        public static partial class Name
        {
            /// <summary>Represents the largest possible number of characters produced by converting an <see cref="PaymentMethod" /> value to string, based on defined members. This field is constant.</summary>
            public const int MaxCharsLength = 6;

            /// <summary>The string representation of <see cref="PaymentMethod.Credit" /> name.</summary>
            public const string Credit = "Credit";

            /// <summary>The string representation of <see cref="PaymentMethod.Debit" /> name.</summary>
            public const string Debit = "Debit";

            /// <summary>The string representation of <see cref="PaymentMethod.Cash" /> name.</summary>
            public const string Cash = "Cash";

            /// <summary>The string representation of <see cref="PaymentMethod.Cheque" /> name.</summary>
            public const string Cheque = "Cheque";
        }

        /// <summary>Provides static values for <see cref="PaymentMethod" /> UTF-8 encoded members names.</summary>
        public static partial class Utf8Name
        {
            /// <summary>Represents the largest possible number of bytes produced by converting an <see cref="PaymentMethod" /> value to UTF-8 string, based on defined members. This field is constant.</summary>
            public const int MaxBytesLength = 6;

            /// <summary>The UTF-8 representation of <see cref="PaymentMethod.Credit" /> name.</summary>
            public static ReadOnlySpan<byte> Credit => new byte[6] { 67, 114, 101, 100, 105, 116 };

            /// <summary>The UTF-8 representation of <see cref="PaymentMethod.Debit" /> name.</summary>
            public static ReadOnlySpan<byte> Debit => new byte[5] { 68, 101, 98, 105, 116 };

            /// <summary>The UTF-8 representation of <see cref="PaymentMethod.Cash" /> name.</summary>
            public static ReadOnlySpan<byte> Cash => new byte[4] { 67, 97, 115, 104 };

            /// <summary>The UTF-8 representation of <see cref="PaymentMethod.Cheque" /> name.</summary>
            public static ReadOnlySpan<byte> Cheque => new byte[6] { 67, 104, 101, 113, 117, 101 };
        }

        /// <summary>Provides constant values for <see cref="PaymentMethod" /> serialized members values.</summary>
        public static partial class SerializedValue
        {
            /// <summary>Represents the largest possible number of characters produced by converting an <see cref="PaymentMethod" /> value to string, based on defined members. This field is constant.</summary>
            public const int MaxCharsLength = 11;

            /// <summary>The string representation of serialized <see cref="PaymentMethod.Credit" /> value.</summary>
            public const string Credit = "Credit card";

            /// <summary>The string representation of serialized <see cref="PaymentMethod.Debit" /> value.</summary>
            public const string Debit = "Debit card";

            /// <summary>The string representation of serialized <see cref="PaymentMethod.Cash" /> value.</summary>
            public const string Cash = "Cash";

            /// <summary>The string representation of serialized <see cref="PaymentMethod.Cheque" /> value.</summary>
            public const string Cheque = "Cheque";
        }

        /// <summary>Provides static values for <see cref="PaymentMethod" /> UTF-8 encoded members serialized values.</summary>
        public static partial class Utf8SerializedValue
        {
            /// <summary>Represents the largest possible number of bytes produced by converting an <see cref="PaymentMethod" /> value to UTF-8 string, based on defined members. This field is constant.</summary>
            public const int MaxBytesLength = 6;

            /// <summary>The UTF-8 representation of serialized <see cref="PaymentMethod.Credit" /> value.</summary>
            public static ReadOnlySpan<byte> Credit => new byte[11] { 67, 114, 101, 100, 105, 116, 32, 99, 97, 114, 100 };

            /// <summary>The UTF-8 representation of serialized <see cref="PaymentMethod.Debit" /> value.</summary>
            public static ReadOnlySpan<byte> Debit => new byte[10] { 68, 101, 98, 105, 116, 32, 99, 97, 114, 100 };

            /// <summary>The UTF-8 representation of serialized <see cref="PaymentMethod.Cash" /> value.</summary>
            public static ReadOnlySpan<byte> Cash => new byte[4] { 67, 97, 115, 104 };

            /// <summary>The UTF-8 representation of serialized <see cref="PaymentMethod.Cheque" /> value.</summary>
            public static ReadOnlySpan<byte> Cheque => new byte[6] { 67, 104, 101, 113, 117, 101 };
        }

        /// <summary>Provides support for formatting <see cref="PaymentMethod"/> values.</summary>
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
                    0 => 6,
                    1 => 5,
                    2 => 4,
                    3 => 6,
                    _ => null
                };
            }

            /// <inheritdoc />
            public string? TryGetStringForMember(int value)
            {
                return value switch
                {
                    0 => "Credit",
                    1 => "Debit",
                    2 => "Cash",
                    3 => "Cheque",
                    _ => null
                };
            }
        }

        /// <summary>Provides support for formatting <see cref="PaymentMethod"/> serialized values.</summary>
        internal sealed partial class SerializationStringFormatter : IEnumFormatter<int>
        {
            /// <summary>Gets the singleton instance of the <see cref="SerializationStringFormatter"/> class.</summary>
            public static SerializationStringFormatter Instance = new SerializationStringFormatter();

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
                    0 => 11,
                    1 => 10,
                    2 => 4,
                    3 => 6,
                    _ => null
                };
            }

            /// <inheritdoc />
            public string? TryGetStringForMember(int value)
            {
                return value switch
                {
                    0 => "Credit card",
                    1 => "Debit card",
                    2 => "Cash",
                    3 => "Cheque",
                    _ => null
                };
            }
        }

        /// <summary>Provides support for parsing <see cref="PaymentMethod"/> values.</summary>
        internal sealed partial class StringParser
            : IEnumParser<int>, IEnumDescriptionParser<int>
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
                    case 'C':
                    case 'c':
                        switch (value)
                        {
                            case { } when value.Equals("Credit", comparisonType):
                                result = 0;
                                return true;
                            case { } when value.Equals("Cash", comparisonType):
                                result = 2;
                                return true;
                            case { } when value.Equals("Cheque", comparisonType):
                                result = 3;
                                return true;
                            default:
                                result = 0;
                                return false;
                        }
                    case 'D':
                    case 'd':
                        switch (value)
                        {
                            case { } when value.Equals("Debit", comparisonType):
                                result = 1;
                                return true;
                            default:
                                result = 0;
                                return false;
                        }
                    default:
                        result = 0;
                        return false;
                }
            }

            /// <inheritdoc />
            public bool TryParseDescription(ReadOnlySpan<char> value, StringComparison comparisonType, out int result)
            {
                switch (value)
                {
                    case { } s when s.Equals("The payment by using physical cash", comparisonType):
                        result = 2;
                        return true;
                    default:
                        result = default;
                        return false;
                }
            }
        }

        /// <summary>Provides support for parsing serialized <see cref="PaymentMethod"/> values.</summary>
        internal sealed partial class SerializationStringParser : IEnumParser<int>
        {
            /// <summary>Gets the singleton instance of the <see cref="StringParser"/> class.</summary>
            public static SerializationStringParser Instance = new SerializationStringParser();

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
                    case 'C':
                    case 'c':
                        switch (value)
                        {
                            case { } when value.Equals("Credit card", comparisonType):
                                result = 0;
                                return true;
                            case { } when value.Equals("Cash", comparisonType):
                                result = 2;
                                return true;
                            case { } when value.Equals("Cheque", comparisonType):
                                result = 3;
                                return true;
                            default:
                                result = 0;
                                return false;
                        }
                    case 'D':
                    case 'd':
                        switch (value)
                        {
                            case { } when value.Equals("Debit card", comparisonType):
                                result = 1;
                                return true;
                            default:
                                result = 0;
                                return false;
                        }
                    default:
                        result = 0;
                        return false;
                }
            }
        }
    }
}
