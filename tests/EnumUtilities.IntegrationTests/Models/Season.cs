using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

[JsonConverterGenerator]
[JsonConverter(typeof(SeasonJsonConverter))]
public enum Season
{
    [EnumMember(Value = "\ud83c\udf31")]
    Spring = 1,
    [EnumMember(Value = "\u2600\ufe0f")]
    Summer,
    [EnumMember(Value = "\ud83c\udf42")]
    Autumn,
    [EnumMember(Value = "\u26c4")]
    Winter
}
