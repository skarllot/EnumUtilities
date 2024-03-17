namespace Raiqub.Generators.EnumUtilities;

internal static class Utf8String
{
    public static ReadOnlySpan<byte> TrimStart(ReadOnlySpan<byte> source)
    {
        while (!source.IsEmpty)
        {
            if (!CodePoint.TryGetFirstCodePoint(source, out var codePoint))
            {
                break;
            }

            if (!codePoint.IsWhiteSpace)
            {
                break;
            }

            source = source.Slice(codePoint.Utf8SequenceLength);
        }

        return source;
    }
}
