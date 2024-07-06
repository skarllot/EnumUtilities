using System.Text.Json.Serialization;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

[JsonConverterGenerator(DeserializationFailureFallbackValue = 0, AllowIntegerValues = false)]
[JsonConverter(typeof(ErrorCodeJsonConverter))]
internal enum BigErrorCode : ulong
{
    [JsonPropertyName("NON")]
    None = 0,

    [JsonPropertyName("UNK")]
    Unknown = 1,

    [JsonPropertyName("CNX")]
    ConnectionLost = 100,

    [JsonPropertyName("OUT")]
    OutlierReading = 200_000_000_000
}
