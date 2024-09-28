namespace Raiqub.Generators.EnumUtilities.Parsers;

public static partial class EnumStringParser
{
    /// <summary>Tries to parse enum values from a string representation.</summary>
    /// <param name="value">The string representation to parse.</param>
    /// <param name="tryParseSingleValueHandler">A delegate that represents a method for parsing an enumeration value by name.</param>
    /// <param name="comparisonType">An enumeration value that determines how enumeration values are compared.</param>
    /// <param name="throwOnFailure">Indicates whether an exception should be thrown on parsing failure.</param>
    /// <param name="result">When this method returns, contains the parsed enum value if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParseWithFlags(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<byte> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out byte result)
    {
        if (!value.IsEmpty)
        {
            char c = value[0];
            if (char.IsWhiteSpace(c))
            {
                value = value.TrimStart();
                if (value.IsEmpty)
                {
                    goto ParseFailure;
                }

                c = value[0];
            }

            if ((c < '0' || c > '9') && c != '-' && c != '+')
            {
                return TryParseByName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
            }

            return EnumNumericParser.TryParse(value, out result) ||
                TryParseByName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
        }

        ParseFailure:
        if (throwOnFailure)
        {
            ThrowHelper.ThrowInvalidEmptyParseArgument(nameof(value));
        }

        result = 0;
        return false;
    }

    /// <summary>Tries to parse enum values from a string representation.</summary>
    /// <param name="value">The string representation to parse.</param>
    /// <param name="tryParseSingleValueHandler">A delegate that represents a method for parsing an enumeration value by name.</param>
    /// <param name="comparisonType">An enumeration value that determines how enumeration values are compared.</param>
    /// <param name="throwOnFailure">Indicates whether an exception should be thrown on parsing failure.</param>
    /// <param name="result">When this method returns, contains the parsed enum value if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParseWithFlags(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<sbyte> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out sbyte result)
    {
        if (!value.IsEmpty)
        {
            char c = value[0];
            if (char.IsWhiteSpace(c))
            {
                value = value.TrimStart();
                if (value.IsEmpty)
                {
                    goto ParseFailure;
                }

                c = value[0];
            }

            if ((c < '0' || c > '9') && c != '-' && c != '+')
            {
                return TryParseByName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
            }

            return EnumNumericParser.TryParse(value, out result) ||
                TryParseByName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
        }

        ParseFailure:
        if (throwOnFailure)
        {
            ThrowHelper.ThrowInvalidEmptyParseArgument(nameof(value));
        }

        result = 0;
        return false;
    }

    /// <summary>Tries to parse enum values from a string representation.</summary>
    /// <param name="value">The string representation to parse.</param>
    /// <param name="tryParseSingleValueHandler">A delegate that represents a method for parsing an enumeration value by name.</param>
    /// <param name="comparisonType">An enumeration value that determines how enumeration values are compared.</param>
    /// <param name="throwOnFailure">Indicates whether an exception should be thrown on parsing failure.</param>
    /// <param name="result">When this method returns, contains the parsed enum value if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParseWithFlags(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<short> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out short result)
    {
        if (!value.IsEmpty)
        {
            char c = value[0];
            if (char.IsWhiteSpace(c))
            {
                value = value.TrimStart();
                if (value.IsEmpty)
                {
                    goto ParseFailure;
                }

                c = value[0];
            }

            if ((c < '0' || c > '9') && c != '-' && c != '+')
            {
                return TryParseByName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
            }

            return EnumNumericParser.TryParse(value, out result) ||
                TryParseByName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
        }

        ParseFailure:
        if (throwOnFailure)
        {
            ThrowHelper.ThrowInvalidEmptyParseArgument(nameof(value));
        }

        result = 0;
        return false;
    }

    /// <summary>Tries to parse enum values from a string representation.</summary>
    /// <param name="value">The string representation to parse.</param>
    /// <param name="tryParseSingleValueHandler">A delegate that represents a method for parsing an enumeration value by name.</param>
    /// <param name="comparisonType">An enumeration value that determines how enumeration values are compared.</param>
    /// <param name="throwOnFailure">Indicates whether an exception should be thrown on parsing failure.</param>
    /// <param name="result">When this method returns, contains the parsed enum value if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParseWithFlags(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<ushort> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out ushort result)
    {
        if (!value.IsEmpty)
        {
            char c = value[0];
            if (char.IsWhiteSpace(c))
            {
                value = value.TrimStart();
                if (value.IsEmpty)
                {
                    goto ParseFailure;
                }

                c = value[0];
            }

            if ((c < '0' || c > '9') && c != '-' && c != '+')
            {
                return TryParseByName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
            }

            return EnumNumericParser.TryParse(value, out result) ||
                TryParseByName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
        }

        ParseFailure:
        if (throwOnFailure)
        {
            ThrowHelper.ThrowInvalidEmptyParseArgument(nameof(value));
        }

        result = 0;
        return false;
    }

    /// <summary>Tries to parse enum values from a string representation.</summary>
    /// <param name="value">The string representation to parse.</param>
    /// <param name="tryParseSingleValueHandler">A delegate that represents a method for parsing an enumeration value by name.</param>
    /// <param name="comparisonType">An enumeration value that determines how enumeration values are compared.</param>
    /// <param name="throwOnFailure">Indicates whether an exception should be thrown on parsing failure.</param>
    /// <param name="result">When this method returns, contains the parsed enum value if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParseWithFlags(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<int> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out int result)
    {
        if (!value.IsEmpty)
        {
            char c = value[0];
            if (char.IsWhiteSpace(c))
            {
                value = value.TrimStart();
                if (value.IsEmpty)
                {
                    goto ParseFailure;
                }

                c = value[0];
            }

            if ((c < '0' || c > '9') && c != '-' && c != '+')
            {
                return TryParseByName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
            }

            return EnumNumericParser.TryParse(value, out result) ||
                TryParseByName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
        }

        ParseFailure:
        if (throwOnFailure)
        {
            ThrowHelper.ThrowInvalidEmptyParseArgument(nameof(value));
        }

        result = 0;
        return false;
    }

    /// <summary>Tries to parse enum values from a string representation.</summary>
    /// <param name="value">The string representation to parse.</param>
    /// <param name="tryParseSingleValueHandler">A delegate that represents a method for parsing an enumeration value by name.</param>
    /// <param name="comparisonType">An enumeration value that determines how enumeration values are compared.</param>
    /// <param name="throwOnFailure">Indicates whether an exception should be thrown on parsing failure.</param>
    /// <param name="result">When this method returns, contains the parsed enum value if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParseWithFlags(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<uint> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out uint result)
    {
        if (!value.IsEmpty)
        {
            char c = value[0];
            if (char.IsWhiteSpace(c))
            {
                value = value.TrimStart();
                if (value.IsEmpty)
                {
                    goto ParseFailure;
                }

                c = value[0];
            }

            if ((c < '0' || c > '9') && c != '-' && c != '+')
            {
                return TryParseByName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
            }

            return EnumNumericParser.TryParse(value, out result) ||
                TryParseByName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
        }

        ParseFailure:
        if (throwOnFailure)
        {
            ThrowHelper.ThrowInvalidEmptyParseArgument(nameof(value));
        }

        result = 0;
        return false;
    }

    /// <summary>Tries to parse enum values from a string representation.</summary>
    /// <param name="value">The string representation to parse.</param>
    /// <param name="tryParseSingleValueHandler">A delegate that represents a method for parsing an enumeration value by name.</param>
    /// <param name="comparisonType">An enumeration value that determines how enumeration values are compared.</param>
    /// <param name="throwOnFailure">Indicates whether an exception should be thrown on parsing failure.</param>
    /// <param name="result">When this method returns, contains the parsed enum value if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParseWithFlags(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<long> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out long result)
    {
        if (!value.IsEmpty)
        {
            char c = value[0];
            if (char.IsWhiteSpace(c))
            {
                value = value.TrimStart();
                if (value.IsEmpty)
                {
                    goto ParseFailure;
                }

                c = value[0];
            }

            if ((c < '0' || c > '9') && c != '-' && c != '+')
            {
                return TryParseByName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
            }

            return EnumNumericParser.TryParse(value, out result) ||
                TryParseByName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
        }

        ParseFailure:
        if (throwOnFailure)
        {
            ThrowHelper.ThrowInvalidEmptyParseArgument(nameof(value));
        }

        result = 0;
        return false;
    }

    /// <summary>Tries to parse enum values from a string representation.</summary>
    /// <param name="value">The string representation to parse.</param>
    /// <param name="tryParseSingleValueHandler">A delegate that represents a method for parsing an enumeration value by name.</param>
    /// <param name="comparisonType">An enumeration value that determines how enumeration values are compared.</param>
    /// <param name="throwOnFailure">Indicates whether an exception should be thrown on parsing failure.</param>
    /// <param name="result">When this method returns, contains the parsed enum value if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParseWithFlags(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<ulong> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out ulong result)
    {
        if (!value.IsEmpty)
        {
            char c = value[0];
            if (char.IsWhiteSpace(c))
            {
                value = value.TrimStart();
                if (value.IsEmpty)
                {
                    goto ParseFailure;
                }

                c = value[0];
            }

            if ((c < '0' || c > '9') && c != '-' && c != '+')
            {
                return TryParseByName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
            }

            return EnumNumericParser.TryParse(value, out result) ||
                TryParseByName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
        }

        ParseFailure:
        if (throwOnFailure)
        {
            ThrowHelper.ThrowInvalidEmptyParseArgument(nameof(value));
        }

        result = 0;
        return false;
    }

    /// <summary>Tries to parse an enum value from a string representation.</summary>
    /// <param name="value">The string representation to parse.</param>
    /// <param name="tryParseSingleValueHandler">A delegate that represents a method for parsing an enumeration value by name.</param>
    /// <param name="comparisonType">An enumeration value that determines how enumeration values are compared.</param>
    /// <param name="throwOnFailure">Indicates whether an exception should be thrown on parsing failure.</param>
    /// <param name="result">When this method returns, contains the parsed enum value if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParse(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<byte> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out byte result)
    {
        if (!value.IsEmpty)
        {
            char c = value[0];
            if (char.IsWhiteSpace(c))
            {
                value = value.TrimStart();
                if (value.IsEmpty)
                {
                    goto ParseFailure;
                }

                c = value[0];
            }

            if ((c < '0' || c > '9') && c != '-' && c != '+')
            {
                return TryParseSingleName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
            }

            return EnumNumericParser.TryParse(value, out result) ||
                TryParseSingleName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
        }

        ParseFailure:
        if (throwOnFailure)
        {
            ThrowHelper.ThrowInvalidEmptyParseArgument(nameof(value));
        }

        result = 0;
        return false;
    }

    /// <summary>Tries to parse an enum value from a string representation.</summary>
    /// <param name="value">The string representation to parse.</param>
    /// <param name="tryParseSingleValueHandler">A delegate that represents a method for parsing an enumeration value by name.</param>
    /// <param name="comparisonType">An enumeration value that determines how enumeration values are compared.</param>
    /// <param name="throwOnFailure">Indicates whether an exception should be thrown on parsing failure.</param>
    /// <param name="result">When this method returns, contains the parsed enum value if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParse(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<sbyte> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out sbyte result)
    {
        if (!value.IsEmpty)
        {
            char c = value[0];
            if (char.IsWhiteSpace(c))
            {
                value = value.TrimStart();
                if (value.IsEmpty)
                {
                    goto ParseFailure;
                }

                c = value[0];
            }

            if ((c < '0' || c > '9') && c != '-' && c != '+')
            {
                return TryParseSingleName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
            }

            return EnumNumericParser.TryParse(value, out result) ||
                TryParseSingleName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
        }

        ParseFailure:
        if (throwOnFailure)
        {
            ThrowHelper.ThrowInvalidEmptyParseArgument(nameof(value));
        }

        result = 0;
        return false;
    }

    /// <summary>Tries to parse an enum value from a string representation.</summary>
    /// <param name="value">The string representation to parse.</param>
    /// <param name="tryParseSingleValueHandler">A delegate that represents a method for parsing an enumeration value by name.</param>
    /// <param name="comparisonType">An enumeration value that determines how enumeration values are compared.</param>
    /// <param name="throwOnFailure">Indicates whether an exception should be thrown on parsing failure.</param>
    /// <param name="result">When this method returns, contains the parsed enum value if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParse(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<short> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out short result)
    {
        if (!value.IsEmpty)
        {
            char c = value[0];
            if (char.IsWhiteSpace(c))
            {
                value = value.TrimStart();
                if (value.IsEmpty)
                {
                    goto ParseFailure;
                }

                c = value[0];
            }

            if ((c < '0' || c > '9') && c != '-' && c != '+')
            {
                return TryParseSingleName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
            }

            return EnumNumericParser.TryParse(value, out result) ||
                TryParseSingleName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
        }

        ParseFailure:
        if (throwOnFailure)
        {
            ThrowHelper.ThrowInvalidEmptyParseArgument(nameof(value));
        }

        result = 0;
        return false;
    }

    /// <summary>Tries to parse an enum value from a string representation.</summary>
    /// <param name="value">The string representation to parse.</param>
    /// <param name="tryParseSingleValueHandler">A delegate that represents a method for parsing an enumeration value by name.</param>
    /// <param name="comparisonType">An enumeration value that determines how enumeration values are compared.</param>
    /// <param name="throwOnFailure">Indicates whether an exception should be thrown on parsing failure.</param>
    /// <param name="result">When this method returns, contains the parsed enum value if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParse(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<ushort> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out ushort result)
    {
        if (!value.IsEmpty)
        {
            char c = value[0];
            if (char.IsWhiteSpace(c))
            {
                value = value.TrimStart();
                if (value.IsEmpty)
                {
                    goto ParseFailure;
                }

                c = value[0];
            }

            if ((c < '0' || c > '9') && c != '-' && c != '+')
            {
                return TryParseSingleName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
            }

            return EnumNumericParser.TryParse(value, out result) ||
                TryParseSingleName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
        }

        ParseFailure:
        if (throwOnFailure)
        {
            ThrowHelper.ThrowInvalidEmptyParseArgument(nameof(value));
        }

        result = 0;
        return false;
    }

    /// <summary>Tries to parse an enum value from a string representation.</summary>
    /// <param name="value">The string representation to parse.</param>
    /// <param name="tryParseSingleValueHandler">A delegate that represents a method for parsing an enumeration value by name.</param>
    /// <param name="comparisonType">An enumeration value that determines how enumeration values are compared.</param>
    /// <param name="throwOnFailure">Indicates whether an exception should be thrown on parsing failure.</param>
    /// <param name="result">When this method returns, contains the parsed enum value if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParse(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<int> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out int result)
    {
        if (!value.IsEmpty)
        {
            char c = value[0];
            if (char.IsWhiteSpace(c))
            {
                value = value.TrimStart();
                if (value.IsEmpty)
                {
                    goto ParseFailure;
                }

                c = value[0];
            }

            if ((c < '0' || c > '9') && c != '-' && c != '+')
            {
                return TryParseSingleName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
            }

            return EnumNumericParser.TryParse(value, out result) ||
                TryParseSingleName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
        }

        ParseFailure:
        if (throwOnFailure)
        {
            ThrowHelper.ThrowInvalidEmptyParseArgument(nameof(value));
        }

        result = 0;
        return false;
    }

    /// <summary>Tries to parse an enum value from a string representation.</summary>
    /// <param name="value">The string representation to parse.</param>
    /// <param name="tryParseSingleValueHandler">A delegate that represents a method for parsing an enumeration value by name.</param>
    /// <param name="comparisonType">An enumeration value that determines how enumeration values are compared.</param>
    /// <param name="throwOnFailure">Indicates whether an exception should be thrown on parsing failure.</param>
    /// <param name="result">When this method returns, contains the parsed enum value if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParse(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<uint> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out uint result)
    {
        if (!value.IsEmpty)
        {
            char c = value[0];
            if (char.IsWhiteSpace(c))
            {
                value = value.TrimStart();
                if (value.IsEmpty)
                {
                    goto ParseFailure;
                }

                c = value[0];
            }

            if ((c < '0' || c > '9') && c != '-' && c != '+')
            {
                return TryParseSingleName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
            }

            return EnumNumericParser.TryParse(value, out result) ||
                TryParseSingleName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
        }

        ParseFailure:
        if (throwOnFailure)
        {
            ThrowHelper.ThrowInvalidEmptyParseArgument(nameof(value));
        }

        result = 0;
        return false;
    }

    /// <summary>Tries to parse an enum value from a string representation.</summary>
    /// <param name="value">The string representation to parse.</param>
    /// <param name="tryParseSingleValueHandler">A delegate that represents a method for parsing an enumeration value by name.</param>
    /// <param name="comparisonType">An enumeration value that determines how enumeration values are compared.</param>
    /// <param name="throwOnFailure">Indicates whether an exception should be thrown on parsing failure.</param>
    /// <param name="result">When this method returns, contains the parsed enum value if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParse(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<long> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out long result)
    {
        if (!value.IsEmpty)
        {
            char c = value[0];
            if (char.IsWhiteSpace(c))
            {
                value = value.TrimStart();
                if (value.IsEmpty)
                {
                    goto ParseFailure;
                }

                c = value[0];
            }

            if ((c < '0' || c > '9') && c != '-' && c != '+')
            {
                return TryParseSingleName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
            }

            return EnumNumericParser.TryParse(value, out result) ||
                TryParseSingleName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
        }

        ParseFailure:
        if (throwOnFailure)
        {
            ThrowHelper.ThrowInvalidEmptyParseArgument(nameof(value));
        }

        result = 0;
        return false;
    }

    /// <summary>Tries to parse an enum value from a string representation.</summary>
    /// <param name="value">The string representation to parse.</param>
    /// <param name="tryParseSingleValueHandler">A delegate that represents a method for parsing an enumeration value by name.</param>
    /// <param name="comparisonType">An enumeration value that determines how enumeration values are compared.</param>
    /// <param name="throwOnFailure">Indicates whether an exception should be thrown on parsing failure.</param>
    /// <param name="result">When this method returns, contains the parsed enum value if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParse(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<ulong> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out ulong result)
    {
        if (!value.IsEmpty)
        {
            char c = value[0];
            if (char.IsWhiteSpace(c))
            {
                value = value.TrimStart();
                if (value.IsEmpty)
                {
                    goto ParseFailure;
                }

                c = value[0];
            }

            if ((c < '0' || c > '9') && c != '-' && c != '+')
            {
                return TryParseSingleName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
            }

            return EnumNumericParser.TryParse(value, out result) ||
                TryParseSingleName(value, tryParseSingleValueHandler, comparisonType, throwOnFailure, out result);
        }

        ParseFailure:
        if (throwOnFailure)
        {
            ThrowHelper.ThrowInvalidEmptyParseArgument(nameof(value));
        }

        result = 0;
        return false;
    }

    private static bool TryParseByName(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<byte> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out byte result)
    {
        bool parsed = true;
        byte localResult = 0;
        foreach (var item in new FlagsEnumTokenizer(value))
        {
            bool success = tryParseSingleValueHandler(item, comparisonType, out byte singleValue);
            if (!success)
            {
                parsed = false;
                break;
            }

            localResult |= singleValue;
        }

        if (parsed)
        {
            result = localResult;
            return true;
        }

        if (throwOnFailure)
        {
            ThrowHelper.ThrowValueNotFound(value, nameof(value));
        }

        result = 0;
        return false;
    }

    private static bool TryParseByName(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<sbyte> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out sbyte result)
    {
        bool parsed = true;
        sbyte localResult = 0;
        foreach (var item in new FlagsEnumTokenizer(value))
        {
            bool success = tryParseSingleValueHandler(item, comparisonType, out sbyte singleValue);
            if (!success)
            {
                parsed = false;
                break;
            }

            localResult |= singleValue;
        }

        if (parsed)
        {
            result = localResult;
            return true;
        }

        if (throwOnFailure)
        {
            ThrowHelper.ThrowValueNotFound(value, nameof(value));
        }

        result = 0;
        return false;
    }

    private static bool TryParseByName(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<short> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out short result)
    {
        bool parsed = true;
        short localResult = 0;
        foreach (var item in new FlagsEnumTokenizer(value))
        {
            bool success = tryParseSingleValueHandler(item, comparisonType, out short singleValue);
            if (!success)
            {
                parsed = false;
                break;
            }

            localResult |= singleValue;
        }

        if (parsed)
        {
            result = localResult;
            return true;
        }

        if (throwOnFailure)
        {
            ThrowHelper.ThrowValueNotFound(value, nameof(value));
        }

        result = 0;
        return false;
    }

    private static bool TryParseByName(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<ushort> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out ushort result)
    {
        bool parsed = true;
        ushort localResult = 0;
        foreach (var item in new FlagsEnumTokenizer(value))
        {
            bool success = tryParseSingleValueHandler(item, comparisonType, out ushort singleValue);
            if (!success)
            {
                parsed = false;
                break;
            }

            localResult |= singleValue;
        }

        if (parsed)
        {
            result = localResult;
            return true;
        }

        if (throwOnFailure)
        {
            ThrowHelper.ThrowValueNotFound(value, nameof(value));
        }

        result = 0;
        return false;
    }

    private static bool TryParseByName(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<int> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out int result)
    {
        bool parsed = true;
        int localResult = 0;
        foreach (var item in new FlagsEnumTokenizer(value))
        {
            bool success = tryParseSingleValueHandler(item, comparisonType, out int singleValue);
            if (!success)
            {
                parsed = false;
                break;
            }

            localResult |= singleValue;
        }

        if (parsed)
        {
            result = localResult;
            return true;
        }

        if (throwOnFailure)
        {
            ThrowHelper.ThrowValueNotFound(value, nameof(value));
        }

        result = 0;
        return false;
    }

    private static bool TryParseByName(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<uint> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out uint result)
    {
        bool parsed = true;
        uint localResult = 0;
        foreach (var item in new FlagsEnumTokenizer(value))
        {
            bool success = tryParseSingleValueHandler(item, comparisonType, out uint singleValue);
            if (!success)
            {
                parsed = false;
                break;
            }

            localResult |= singleValue;
        }

        if (parsed)
        {
            result = localResult;
            return true;
        }

        if (throwOnFailure)
        {
            ThrowHelper.ThrowValueNotFound(value, nameof(value));
        }

        result = 0;
        return false;
    }

    private static bool TryParseByName(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<long> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out long result)
    {
        bool parsed = true;
        long localResult = 0;
        foreach (var item in new FlagsEnumTokenizer(value))
        {
            bool success = tryParseSingleValueHandler(item, comparisonType, out long singleValue);
            if (!success)
            {
                parsed = false;
                break;
            }

            localResult |= singleValue;
        }

        if (parsed)
        {
            result = localResult;
            return true;
        }

        if (throwOnFailure)
        {
            ThrowHelper.ThrowValueNotFound(value, nameof(value));
        }

        result = 0;
        return false;
    }

    private static bool TryParseByName(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<ulong> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out ulong result)
    {
        bool parsed = true;
        ulong localResult = 0;
        foreach (var item in new FlagsEnumTokenizer(value))
        {
            bool success = tryParseSingleValueHandler(item, comparisonType, out ulong singleValue);
            if (!success)
            {
                parsed = false;
                break;
            }

            localResult |= singleValue;
        }

        if (parsed)
        {
            result = localResult;
            return true;
        }

        if (throwOnFailure)
        {
            ThrowHelper.ThrowValueNotFound(value, nameof(value));
        }

        result = 0;
        return false;
    }

}
