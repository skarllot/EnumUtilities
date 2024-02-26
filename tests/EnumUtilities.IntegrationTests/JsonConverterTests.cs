using System.Text.Json;
using Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests;

public class JsonConverterTests
{
    [Theory]
    [InlineData(Season.Spring, "\"\\uD83C\\uDF31\"")]
    [InlineData(Season.Summer, "\"\\u2600\\uFE0F\"")]
    [InlineData(Season.Autumn, "\"\\uD83C\\uDF42\"")]
    [InlineData(Season.Winter, "\"\\u26C4\"")]
    public void ShouldSerializeSeasonAsExpected(Season value, string expected)
    {
        string result = JsonSerializer.Serialize(value);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("\"\\uD83C\\uDF31\"", Season.Spring)]
    [InlineData("\"\\u2600\\uFE0F\"", Season.Summer)]
    [InlineData("\"\\uD83C\\uDF42\"", Season.Autumn)]
    [InlineData("\"\\u26C4\"", Season.Winter)]
    [InlineData("1", Season.Spring)]
    [InlineData("2", Season.Summer)]
    [InlineData("3", Season.Autumn)]
    [InlineData("4", Season.Winter)]
    public void ShouldDeserializeSeasonAsExpected(string value, Season expected)
    {
        Season result = JsonSerializer.Deserialize<Season>(value);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(ErrorCode.None, "\"NON\"")]
    [InlineData(ErrorCode.Unknown, "\"UNK\"")]
    [InlineData(ErrorCode.ConnectionLost, "\"CNX\"")]
    [InlineData(ErrorCode.OutlierReading, "\"OUT\"")]
    internal void ShouldSerializeErrorCodeAsExpected(ErrorCode value, string expected)
    {
        string result = JsonSerializer.Serialize(value);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("\"NON\"", ErrorCode.None)]
    [InlineData("\"UNK\"", ErrorCode.Unknown)]
    [InlineData("\"CNX\"", ErrorCode.ConnectionLost)]
    [InlineData("\"OUT\"", ErrorCode.OutlierReading)]
    [InlineData("0", ErrorCode.None)]
    [InlineData("1", ErrorCode.None)]
    [InlineData("7.5", ErrorCode.None)]
    [InlineData("\"TEST\"", ErrorCode.None)]
    internal void ShouldDeserializeErrorCodeAsExpected(string value, ErrorCode expected)
    {
        ErrorCode result = JsonSerializer.Deserialize<ErrorCode>(value);
        Assert.Equal(expected, result);
    }
}
