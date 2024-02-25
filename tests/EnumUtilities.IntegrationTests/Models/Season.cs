using System.Runtime.Serialization;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

[EnumGenerator(GenerateJsonConverter = true)]
internal enum Season
{
    Spring,
    Summer,
    Autumn,
    [EnumMember(Value = "\u26c4")]
    Winter
}
