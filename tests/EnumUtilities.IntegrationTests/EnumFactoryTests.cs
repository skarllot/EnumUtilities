using Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests;

public class EnumFactoryTests
{
    [Theory]
    [InlineData(nameof(Colours.Red))]
    [InlineData(nameof(Colours.Green))]
    [InlineData($" {nameof(Colours.Blue)}")]
    [InlineData($"{nameof(Colours.Green)}, {nameof(Colours.Blue)}")]
    [InlineData($"{nameof(Colours.Green)},")]
    [InlineData($"{nameof(Colours.Green)}, ")]
    [InlineData("15")]
    [InlineData("0")]
    [InlineData("ThisIsNotValid")]
    [InlineData($"ThisIsNotValid,{nameof(Colours.Blue)}")]
    [InlineData($"{nameof(Colours.Blue)},ThisIsNotValid")]
    [InlineData(",")]
    [InlineData(",,")]
    public void TryParseBitFlagsIsSameAsEnumParse(string value)
    {
        bool expectedSuccess = Enum.TryParse(value, out Colours expectedResult);
        bool actualSuccess = ColoursFactory.TryParse(value, out var actualResult);

        Assert.Equal(expectedSuccess, actualSuccess);
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData(nameof(Categories.Arts))]
    [InlineData(nameof(Categories.Fashion))]
    [InlineData($" {nameof(Categories.Automotive)}")]
    [InlineData($"{nameof(Categories.Electronics)}, {nameof(Categories.BeautyCare)}")]
    [InlineData($"{nameof(Categories.BeautyCare)},")]
    [InlineData($"{nameof(Categories.Arts)}, ")]
    [InlineData("15")]
    [InlineData("0")]
    [InlineData("ThisIsNotValid")]
    [InlineData($"ThisIsNotValid,{nameof(Categories.Arts)}")]
    [InlineData($"{nameof(Categories.Electronics)},ThisIsNotValid")]
    [InlineData(",")]
    [InlineData(",,")]
    public void TryParseIsSameAsEnumParse(string value)
    {
        bool expectedSuccess = Enum.TryParse(value, out Categories expectedResult);
        bool actualSuccess = CategoriesFactory.TryParse(value, out var actualResult);

        Assert.Equal(expectedSuccess, actualSuccess);
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void GetValuesIsSameAsEnumGetValues()
    {
        var expectedValues = Enum.GetValues<Categories>();
        var actualValues = CategoriesFactory.GetValues();

        Assert.Equal(expectedValues, actualValues);
    }

    [Fact]
    public void GetNamesIsSameAsEnumGetNames()
    {
        string[] expectedValues = Enum.GetNames<Categories>();
        string[] actualValues = CategoriesFactory.GetNames();

        Assert.Equal(expectedValues, actualValues);
    }
}
