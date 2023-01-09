using Raiqub.Generators.EnumUtilities.Common;

namespace Raiqub.Generators.EnumUtilities.Models;

public sealed record EnumToGenerate(string Namespace, string Name, string UnderlyingType, List<EnumValue> Values)
{
    public IEnumerable<EnumValue> UniqueValues =>
        Values.DistinctBy(static it => it.MemberValue, StringComparer.Ordinal);

    public bool HasSerializationValue =>
        Values.Any(static it => it.SerializationValue != null);

    public bool HasDisplayValue =>
        Values.Any(static it => it.DisplayValue != null);
}