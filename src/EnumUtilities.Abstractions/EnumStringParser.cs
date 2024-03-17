using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Raiqub.Generators.EnumUtilities;

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
        switch (AnalyseForParsing(ref value))
        {
            case ParseAnalysisResult.NotNumeric:
                return TryParseByName(value, enumParser, ignoreCase, throwOnFailure, out result);
            case ParseAnalysisResult.MaybeNumeric:
                return enumParser.TryParseNumber(value, out result)
                       || TryParseByName(value, enumParser, ignoreCase, throwOnFailure, out result);
            case ParseAnalysisResult.Empty:
            default:
                return TryParseEmpty(throwOnFailure, out result);
        }
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
            ThrowValueNotFound(value);
        }

        result = default;
        return false;
    }

    private static bool TryParseEmpty<TNumber>(bool throwOnFailure, out TNumber result)
        where TNumber : struct
    {
        if (throwOnFailure)
        {
            ThrowInvalidEmptyParseArgument();
        }

        result = default;
        return false;
    }

    private enum ParseAnalysisResult
    {
        Empty,
        Invalid,
        NotNumeric,
        MaybeNumeric
    }

    private static ParseAnalysisResult AnalyseForParsing(ref ReadOnlySpan<char> value)
    {
        if (value.IsEmpty)
        {
            return ParseAnalysisResult.Empty;
        }

        value = value.TrimStart();
        if (value.IsEmpty)
        {
            return ParseAnalysisResult.Empty;
        }

        if (!CodePoint.TryGetCodePointAt(value, 0, out var rune))
        {
            return ParseAnalysisResult.Invalid;
        }

        return rune.IsAsciiDigit || rune == '-' || rune == '+'
            ? ParseAnalysisResult.MaybeNumeric
            : ParseAnalysisResult.NotNumeric;
    }

    private static ParseAnalysisResult AnalyseForParsing(ref ReadOnlySpan<byte> value)
    {
        if (value.IsEmpty)
        {
            return ParseAnalysisResult.Empty;
        }

        value = Utf8String.TrimStart(value);
        if (value.IsEmpty)
        {
            return ParseAnalysisResult.Empty;
        }

        if (!CodePoint.TryGetFirstCodePoint(value, out var rune))
        {
            return ParseAnalysisResult.Invalid;
        }

        return rune.IsAsciiDigit || rune == '-' || rune == '+'
            ? ParseAnalysisResult.MaybeNumeric
            : ParseAnalysisResult.NotNumeric;
    }

    [SuppressMessage("ReSharper", "NotResolvedInText")]
    private static void ThrowInvalidEmptyParseArgument()
    {
        throw new ArgumentException(
            "Must specify valid information for parsing in the string.",
            "value");
    }

    private static void ThrowValueNotFound(ReadOnlySpan<char> value)
    {
#if !NETSTANDARD2_0
        throw new ArgumentException($"Requested value '{value}' was not found.", nameof(value));
#else
        throw new ArgumentException($"Requested value '{value.ToString()}' was not found.", nameof(value));
#endif
    }
}
