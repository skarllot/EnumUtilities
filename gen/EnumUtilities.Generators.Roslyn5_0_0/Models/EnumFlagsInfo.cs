using System.Globalization;
using Raiqub.Generators.EnumUtilities.Common;

namespace Raiqub.Generators.EnumUtilities.Models;

public sealed class EnumFlagsInfo(EnumToGenerate model)
{
    public List<EnumValue> BitValues =>
        field ??= model.UniqueValues.Where(x => BitOperations.IsPow2(x.BinaryValue)).ToList();

    public List<EnumValue> InvertedCompositeValues =>
        field ??= model
            .UniqueValues.Where(static x => (x.BinaryValue & (x.BinaryValue - 1)) != 0)
            .OrderByDescending(static x => x.BinaryValue)
            .ToList();

    public bool HasFewCombinations => model.GetMappedBitCount() <= 8;

    public bool IsAllSingleBitsDefined => model.GetMappedBitCount() == BitValues.Count;

    public bool IsAllBitsDefined =>
        ValidFlagsMask switch
        {
            byte n => n == byte.MaxValue,
            sbyte n => n == -1,
            short n => n == -1,
            ushort n => n == ushort.MaxValue,
            int n => n == -1,
            uint n => n == uint.MaxValue,
            long n => n == -1L,
            ulong n => n == ulong.MaxValue,
            _ => throw new InvalidOperationException($"Unexpected constant value type: {ValidFlagsMask.GetType()}"),
        };

    public object ValidFlagsMask =>
        field ??= model.UnderlyingType switch
        {
            "byte" => model.Values.Aggregate((byte)0, (acc, cur) => (byte)(acc | (byte)cur.ConstantValue)),
            "sbyte" => model.Values.Aggregate((sbyte)0, (acc, cur) => (sbyte)(acc | (sbyte)cur.ConstantValue)),
            "short" => model.Values.Aggregate((short)0, (acc, cur) => (short)(acc | (short)cur.ConstantValue)),
            "ushort" => model.Values.Aggregate((ushort)0, (acc, cur) => (ushort)(acc | (ushort)cur.ConstantValue)),
            "int" => model.Values.Aggregate(0, (acc, cur) => acc | (int)cur.ConstantValue),
            "uint" => model.Values.Aggregate(0u, (acc, cur) => acc | (uint)cur.ConstantValue),
            "long" => model.Values.Aggregate(0L, (acc, cur) => acc | (long)cur.ConstantValue),
            "ulong" => model.Values.Aggregate(0ul, (acc, cur) => acc | (ulong)cur.ConstantValue),
            _ => throw new InvalidOperationException($"Unexpected constant value type: {model.UnderlyingType}"),
        };

    public ulong ValidFlagsMaskUnsigned => Convert.ToUInt64(ValidFlagsMask, CultureInfo.InvariantCulture);
    public long ValidFlagsMaskSigned => Convert.ToInt64(ValidFlagsMask, CultureInfo.InvariantCulture);

    public IEnumerable<EnumValue> GetMatchingValues(ulong value)
    {
        var composite = model.UniqueValues.Find(x => x.BinaryValue == value);
        if (composite is not null)
        {
            return [composite];
        }

        var remaining = value;
        var found = new List<EnumValue>(model.UniqueValues.Count);
        foreach (var item in model.InvertedValues)
        {
            if (item.BinaryValue == 0 || (remaining & item.BinaryValue) != item.BinaryValue)
            {
                continue;
            }

            remaining -= item.BinaryValue;
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
