using Raiqub.Generators.EnumUtilities.Common;

namespace Raiqub.Generators.EnumUtilities.Models;

public sealed class EnumFlagsInfo(EnumToGenerate model)
{
    public List<EnumValue> BitValues =>
        field ??= model.UniqueValues.Where(x => BitOperations.IsPow2(x.RealMemberValue)).ToList();

    public List<EnumValue> InvertedCompositeValues =>
        field ??= model
            .UniqueValues.Where(static x => (x.RealMemberValue & (x.RealMemberValue - 1)) != 0)
            .OrderByDescending(static x => x.RealMemberValue)
            .ToList();

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
        var composite = model.UniqueValues.Find(x => x.RealMemberValue == value);
        if (composite is not null)
        {
            return [composite];
        }

        var remaining = value;
        var found = new List<EnumValue>(model.UniqueValues.Count);
        foreach (var item in model.InvertedValues)
        {
            if (item.RealMemberValue <= 0 || (value & item.RealMemberValue) != item.RealMemberValue)
            {
                continue;
            }

            remaining -= item.RealMemberValue;
            found.Add(item);

            if (remaining == 0)
            {
                break;
            }
        }

        found.Reverse();
        return remaining == 0 ? found : [];
    }
}
