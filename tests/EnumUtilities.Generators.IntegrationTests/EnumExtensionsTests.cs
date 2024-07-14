using Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests;

public class EnumExtensionsTests
{
    [Theory]
    [InlineData(Colours.Red)]
    [InlineData(Colours.Green)]
    [InlineData(Colours.Green | Colours.Blue)]
    [InlineData((Colours)15)]
    [InlineData((Colours)0)]
    public void FastToStringIsSameAsToStringUsingFlagEnum(Colours value)
    {
        string expected = value.ToString();
        string actual = value.ToStringFast();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(HumanStates.Idle)]
    [InlineData(HumanStates.Working)]
    [InlineData(HumanStates.Sleeping)]
    [InlineData(HumanStates.Eating)]
    [InlineData(HumanStates.Dead)]
    [InlineData((HumanStates)0)]
    [InlineData((HumanStates)100)]
    public void FastToStringIsSameAsToString(HumanStates value)
    {
        string expected = value.ToString();
        string actual = value.ToStringFast();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(HumanStates.Idle)]
    [InlineData(HumanStates.Working)]
    [InlineData(HumanStates.Sleeping)]
    [InlineData(HumanStates.Eating)]
    [InlineData(HumanStates.Dead)]
    [InlineData((HumanStates)0)]
    [InlineData((HumanStates)(-1))]
    [InlineData((HumanStates)10)]
    [InlineData((HumanStates)(-10))]
    [InlineData((HumanStates)100)]
    public void IsDefinedIsSameAsEnumIsDefined(HumanStates value)
    {
        bool expected = Enum.IsDefined(value);
        bool actual = value.IsDefined();

        Assert.Equal(expected, actual);
    }
}
