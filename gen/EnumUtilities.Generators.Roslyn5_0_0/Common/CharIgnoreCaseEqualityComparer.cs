namespace Raiqub.Generators.EnumUtilities.Common;

public sealed class CharIgnoreCaseEqualityComparer : IEqualityComparer<char>
{
    public static CharIgnoreCaseEqualityComparer Instance { get; } = new();

    public bool Equals(char x, char y) => NormalizeChar(x) == NormalizeChar(y);

    public int GetHashCode(char obj) => NormalizeChar(obj).GetHashCode();

    private static char NormalizeChar(char ch) =>
        char.IsSurrogate(ch) || char.IsControl(ch) ? ch : char.ToUpperInvariant(ch);
}
