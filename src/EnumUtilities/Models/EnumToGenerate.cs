namespace Raiqub.Generators.EnumUtilities.Models;

public sealed record EnumToGenerate(string Namespace, string Name, string UnderlyingType, List<EnumValue> Values)
{
    public IEnumerable<EnumValue> UniqueValues => Values.DistinctBy(static it => it.MemberValue);
}