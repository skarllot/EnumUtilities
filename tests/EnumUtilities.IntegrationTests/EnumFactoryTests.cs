using Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests;

public class EnumFactoryTests
{
    [Theory]
    [InlineData(nameof(Colours.Red))]
    [InlineData(nameof(Colours.Green))]
    [InlineData($"{nameof(Colours.Green)}, {nameof(Colours.Blue)}")]
    [InlineData("15")]
    [InlineData("0")]
    [InlineData("ThisIsNotValid")]
    public void TryParseIsSameAsEnumParse(string value)
    {
        bool expectedSuccess = Enum.TryParse(value, out Colours expectedResult);
        bool actualSuccess = ColoursFactory.TryParse(value, out var actualResult);
        
        Assert.Equal(expectedSuccess, actualSuccess);
        Assert.Equal(expectedResult, actualResult);
    }
}