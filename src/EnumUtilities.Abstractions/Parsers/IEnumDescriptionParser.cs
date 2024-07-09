namespace Raiqub.Generators.EnumUtilities.Parsers;

public interface IEnumDescriptionParser<T>
{
    bool TryParseDescription(ReadOnlySpan<char> value, StringComparison comparisonType, out T result);
}
