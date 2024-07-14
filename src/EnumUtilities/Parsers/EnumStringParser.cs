using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Raiqub.Generators.EnumUtilities.Parsers;

/// <summary>Provides utility methods for parsing enum values from string representations.</summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public static class EnumStringParser
{
    /// <summary>Tries to parse an enum value from a string representation.</summary>
    /// <typeparam name="TParser">The type of the enum parser.</typeparam>
    /// <typeparam name="TNumber">The underlying numeric type of the enum.</typeparam>
    /// <param name="value">The string representation to parse.</param>
    /// <param name="enumParser">An instance of the enum parser.</param>
    /// <param name="ignoreCase">Indicates whether parsing should be case-insensitive.</param>
    /// <param name="throwOnFailure">Indicates whether an exception should be thrown on parsing failure.</param>
    /// <param name="result">When this method returns, contains the parsed enum value if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParse<TParser, TNumber>(
        ReadOnlySpan<char> value,
        TParser enumParser,
        bool ignoreCase,
        bool throwOnFailure,
        out TNumber result)
        where TParser : IEnumParser<TNumber>
        where TNumber : struct
    {
        switch (AnalyseForParsing(value, out value))
        {
            case ParseAnalysisResult.NotNumeric:
                return TryParseByName(value, enumParser, ignoreCase, throwOnFailure, out result);
            case ParseAnalysisResult.MaybeNumeric:
                return enumParser.TryParseNumber(value, out result)
                       || TryParseByName(value, enumParser, ignoreCase, throwOnFailure, out result);
            case ParseAnalysisResult.Empty:
            default:
                return TryParseEmpty(nameof(value), throwOnFailure, out result);
        }
    }

    public static bool TryParseDescription<TParser, TNumber>(
        ReadOnlySpan<char> description,
        TParser parser,
        StringComparison comparisonType,
        bool throwOnFailure,
        out TNumber result)
        where TParser : IEnumDescriptionParser<TNumber>
        where TNumber : struct
    {
        if (description.IsWhiteSpace())
        {
            return TryParseEmpty(nameof(description), throwOnFailure, out result);
        }

        bool success = parser.TryParseDescription(description, comparisonType, out result);
        if (success)
        {
            return true;
        }

        if (throwOnFailure)
        {
            ThrowValueNotFound(description, nameof(description));
        }

        return false;
    }

    private static bool TryParseByName<TParser, TNumber>(
        ReadOnlySpan<char> value,
        TParser enumParser,
        bool ignoreCase,
        bool throwOnFailure,
        out TNumber result)
        where TParser : IEnumParser<TNumber>
        where TNumber : struct
    {
        bool parsed = true;
        TNumber localResult = default;
        foreach (var item in new FlagsEnumTokenizer(value))
        {
            bool success = enumParser.TryParseSingleName(item, ignoreCase, out TNumber singleValue);
            if (!success)
            {
                parsed = false;
                break;
            }

            localResult = enumParser.BitwiseOr(localResult, singleValue);
        }

        if (parsed)
        {
            result = localResult;
            return true;
        }

        if (throwOnFailure)
        {
            ThrowValueNotFound(value, nameof(value));
        }

        result = default;
        return false;
    }

    private static bool TryParseEmpty<TNumber>(string parameterName, bool throwOnFailure, out TNumber result)
        where TNumber : struct
    {
        if (throwOnFailure)
        {
            ThrowInvalidEmptyParseArgument(parameterName);
        }

        result = default;
        return false;
    }

    private enum ParseAnalysisResult
    {
        Empty,
        NotNumeric,
        MaybeNumeric
    }

    private static ParseAnalysisResult AnalyseForParsing(ReadOnlySpan<char> value, out ReadOnlySpan<char> result)
    {
        if (value.IsEmpty)
        {
            result = default;
            return ParseAnalysisResult.Empty;
        }

        char c = value[0];
        if (char.IsWhiteSpace(c))
        {
            value = value.TrimStart();
            if (value.IsEmpty)
            {
                result = default;
                return ParseAnalysisResult.Empty;
            }

            c = value[0];
        }

        result = value;
        return IsAsciiDigit(c) || c == '-' || c == '+'
            ? ParseAnalysisResult.MaybeNumeric
            : ParseAnalysisResult.NotNumeric;
    }

    private static void ThrowInvalidEmptyParseArgument(string parameterName)
    {
        throw new ArgumentException(
            "Must specify valid information for parsing in the string.",
            parameterName);
    }

    private static void ThrowValueNotFound(ReadOnlySpan<char> value, string parameterName)
    {
#if !NETSTANDARD2_0
        throw new ArgumentException($"Requested value '{value}' was not found.", parameterName);
#else
        throw new ArgumentException($"Requested value '{value.ToString()}' was not found.", parameterName);
#endif
    }

    /// <summary>Indicates whether a character is categorized as an ASCII digit.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsAsciiDigit(char c) => c is >= '0' and <= '9';
}
