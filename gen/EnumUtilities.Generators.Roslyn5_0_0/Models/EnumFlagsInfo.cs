using Raiqub.Generators.EnumUtilities.Common;

namespace Raiqub.Generators.EnumUtilities.Models;

public sealed class EnumFlagsInfo(EnumToGenerate model)
{
    public List<EnumValue> BitValues =>
        field ??= model.UniqueValues.Where(x => BitOperations.IsPow2(x.RealMemberValue)).ToList();

    public List<EnumValue> CompositeValues =>
        field ??= model.UniqueValues.Where(x => (x.RealMemberValue & (x.RealMemberValue - 1)) != 0).ToList();

    public bool HasFewCombinations => model.GetMappedBitCount() <= 8;

    public bool IsAllBitsDefined =>
        model.BitCount switch
        {
            8 => ValidFlagsMask == byte.MaxValue,
            16 => ValidFlagsMask == ushort.MaxValue,
            32 => ValidFlagsMask == uint.MaxValue,
            _ => ValidFlagsMask == ulong.MaxValue,
        };

    public ulong ValidFlagsMask => model.Values.Aggregate(0ul, static (acc, cur) => acc | cur.RealMemberValue);

    public IEnumerable<EnumValue> GetMatchingValues(ulong value)
    {
        var composite = CompositeValues.Find(x => x.RealMemberValue == value);
        if (composite is not null)
            return [composite];

        var popCount = BitOperations.PopCount(value);
        var matchingValues = BitValues
            .Where(x => x.RealMemberValue > 0 && (value & x.RealMemberValue) == x.RealMemberValue)
            .ToList();

        return matchingValues.Count == popCount ? matchingValues : [];
    }
}
