﻿// <auto-generated />
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using Raiqub.Generators.EnumUtilities.Parsers;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.10.0.0")]
    internal static partial class ErrorCodeFactory
    {

        /// <summary>
        /// Converts the string representation of the serialized JSON value to an equivalent enumerated object.
        /// </summary>
        /// <param name="value">The string representation of the enumeration serialized JSON value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <returns>The value represented by the specified serialized value. Note that this value need not be a member of the ErrorCode enumeration.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not represent a valid value.</exception>
        public static ErrorCode ParseJsonString(string value, bool ignoreCase = false)
        {
            if (value is null) ThrowHelper.ThrowArgumentNullException(nameof(value));
            TryParseJsonString(value.AsSpan(), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: true, out var result);
            return (ErrorCode)result;
        }

        /// <summary>
        /// Converts the string representation of the serialized JSON value to an equivalent enumerated object.
        /// </summary>
        /// <param name="value">The string representation of the enumeration serialized JSON value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <returns>The value represented by the specified serialized value. Note that this value need not be a member of the ErrorCode enumeration.</returns>
        /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not represent a valid value.</exception>
        public static ErrorCode ParseJsonString(ReadOnlySpan<char> value, bool ignoreCase = false)
        {
            TryParseJsonString(value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: true, out var result);
            return (ErrorCode)result;
        }

        /// <summary>
        /// Converts the string representation of the serialized JSON value to an equivalent enumerated object.
        /// </summary>
        /// <param name="value">The string representation of the enumeration serialized JSON value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <returns>The value represented by the specified serialized value or null. Note that this value need not be a member of the ErrorCode enumeration.</returns>
        /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not represent a valid value.</exception>
        [return: NotNullIfNotNull("value")]
        public static ErrorCode? ParseJsonStringOrNull(string? value, bool ignoreCase = false)
        {
            if (value is null) return null;
            TryParseJsonString(value.AsSpan(), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: true, out var result);
            return (ErrorCode)result;
        }

        /// <summary>
        /// Converts the string representation of the serialized JSON value to an equivalent enumerated object.
        /// The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="value">The string representation of the enumeration serialized JSON value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type ErrorCode whose value is represented by a
        /// serialized JSON value if the parse operation succeeds. If the parse operation fails, result contains the default
        /// value of the underlying type of ErrorCode. Note that this value need not be a member of the ErrorCode enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseJsonString([NotNullWhen(true)] string? value, bool ignoreCase, out ErrorCode result)
        {
            Unsafe.SkipInit(out result);
            return TryParseJsonString(value.AsSpan(), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: false, out Unsafe.As<ErrorCode, ushort>(ref result));
        }

        /// <summary>
        /// Converts the string representation of the serialized JSON value to an equivalent enumerated object.
        /// The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="value">The string representation of the enumeration serialized JSON value to convert.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type ErrorCode whose value is represented by a
        /// serialized JSON value if the parse operation succeeds. If the parse operation fails, result contains the default
        /// value of the underlying type of ErrorCode. Note that this value need not be a member of the ErrorCode enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseJsonString([NotNullWhen(true)] string? value, out ErrorCode result)
        {
            Unsafe.SkipInit(out result);
            return TryParseJsonString(value.AsSpan(), StringComparison.Ordinal, throwOnFailure: false, out Unsafe.As<ErrorCode, ushort>(ref result));
        }

        /// <summary>
        /// Converts the string representation of the serialized JSON value to an equivalent enumerated object.
        /// </summary>
        /// <param name="value">The string representation of the enumeration serialized JSON value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <returns>
        /// Contains an object of type ErrorCode whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains a null value.
        /// </returns>
        public static ErrorCode? TryParseJsonString(string? value, bool ignoreCase = false)
        {
            return TryParseJsonString(value.AsSpan(), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: false, out var result) ? (ErrorCode?)result : null;
        }

        /// <summary>
        /// Converts the string representation of the serialized JSON value to an equivalent enumerated object.
        /// The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="value">The string representation of the enumeration serialized JSON value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type ErrorCode whose value is represented by a
        /// serialized JSON value if the parse operation succeeds. If the parse operation fails, result contains the default
        /// value of the underlying type of ErrorCode. Note that this value need not be a member of the ErrorCode enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseJsonString(ReadOnlySpan<char> value, bool ignoreCase, out ErrorCode result)
        {
            Unsafe.SkipInit(out result);
            return TryParseJsonString(value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: false, out Unsafe.As<ErrorCode, ushort>(ref result));
        }

        /// <summary>
        /// Converts the string representation of the serialized JSON value to an equivalent enumerated object.
        /// The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="value">The string representation of the enumeration serialized JSON value to convert.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type ErrorCode whose value is represented by a
        /// serialized JSON value if the parse operation succeeds. If the parse operation fails, result contains the default
        /// value of the underlying type of ErrorCode. Note that this value need not be a member of the ErrorCode enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseJsonString(ReadOnlySpan<char> value, out ErrorCode result)
        {
            Unsafe.SkipInit(out result);
            return TryParseJsonString(value, StringComparison.Ordinal, throwOnFailure: false, out Unsafe.As<ErrorCode, ushort>(ref result));
        }

        /// <summary>
        /// Converts the string representation of the serialized JSON value to an equivalent enumerated object.
        /// </summary>
        /// <param name="value">The string representation of the enumeration serialized JSON value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <returns>
        /// Contains an object of type ErrorCode whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains a null value.
        /// </returns>
        public static ErrorCode? TryParseJsonString(ReadOnlySpan<char> value, bool ignoreCase = false)
        {
            return TryParseJsonString(value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: false, out var result) ? (ErrorCode?)result : null;
        }

        private static bool TryParseJsonString(ReadOnlySpan<char> value, StringComparison comparisonType, bool throwOnFailure, out ushort result)
        {
            if (!value.IsEmpty)
            {
                return TryParseNonNumericJsonString(value, comparisonType, throwOnFailure, out result);
            }

            if (throwOnFailure)
            {
                ThrowHelper.ThrowInvalidEmptyParseArgument(nameof(value));
            }

            result = 0;
            return false;
        }

        private static bool TryParseNonNumericJsonString(ReadOnlySpan<char> value, StringComparison comparisonType, bool throwOnFailure, out ushort result)
        {
            bool success = TryParseSingleJsonString(value, comparisonType, out result);
            if (success)
            {
                return true;
            }

            if (throwOnFailure)
            {
                ThrowHelper.ThrowValueNotFound(value, nameof(value));
            }

            return false;
        }

        private static bool TryParseSingleJsonString(ReadOnlySpan<char> value, StringComparison comparisonType, out ushort result)
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
                        case { } when value.Equals("CNX", comparisonType):
                            result = 100;
                            return true;
                    }
                    break;
                case 'N':
                case 'n':
                    switch (value)
                    {
                        case { } when value.Equals("NON", comparisonType):
                            result = 0;
                            return true;
                    }
                    break;
                case 'O':
                case 'o':
                    switch (value)
                    {
                        case { } when value.Equals("OUT", comparisonType):
                            result = 200;
                            return true;
                    }
                    break;
                case 'U':
                case 'u':
                    switch (value)
                    {
                        case { } when value.Equals("UNK", comparisonType):
                            result = 1;
                            return true;
                    }
                    break;
            }

            result = 0;
            return false;
        }
    }
}
