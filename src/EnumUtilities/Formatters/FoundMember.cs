namespace Raiqub.Generators.EnumUtilities.Formatters;

public readonly struct FoundMember(bool isComposite, int memberIndex)
{
    public readonly bool IsComposite = isComposite;
    public readonly int MemberIndex = memberIndex;
}
