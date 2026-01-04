using Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests;

public class EnumExtensionsTests
{
    [Theory]
    [InlineData(Colours.Red)]
    [InlineData(Colours.Green)]
    [InlineData(Colours.Green | Colours.Blue)]
    [InlineData(Colours.Green | Colours.Blue | Colours.Red)]
    [InlineData((Colours)10)]
    [InlineData((Colours)15)]
    [InlineData((Colours)0)]
    public void FastToStringIsSameAsToStringUsingFlagEnum(Colours value)
    {
        string expected = value.ToString();
        string actual = value.ToStringFast();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(UserRole.None)]
    [InlineData(UserRole.NormalUser)]
    [InlineData(UserRole.Custodian)]
    [InlineData(UserRole.Finance)]
    [InlineData(UserRole.SuperUser)]
    [InlineData(UserRole.All)]
    [InlineData(UserRole.NormalUser | UserRole.Finance)]
    [InlineData(UserRole.NormalUser | UserRole.Custodian)]
    [InlineData((UserRole)10)]
    [InlineData((UserRole)15)]
    public void FastToStringWithZeroIsSameAsToStringUsingFlagEnum(UserRole value)
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
    [InlineData(Colours.Red)]
    [InlineData(Colours.Green)]
    [InlineData(Colours.Green | Colours.Blue)]
    [InlineData(Colours.Green | Colours.Blue | Colours.Red)]
    [InlineData((Colours)10)]
    [InlineData((Colours)15)]
    [InlineData((Colours)0)]
    public void GetStringLengthIsSameAsToStringUsingFlagEnum(Colours value)
    {
        int expected = value.ToString().Length;
        int actual = value.GetStringLength();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(UserRole.None)]
    [InlineData(UserRole.NormalUser)]
    [InlineData(UserRole.Custodian)]
    [InlineData(UserRole.Finance)]
    [InlineData(UserRole.SuperUser)]
    [InlineData(UserRole.All)]
    [InlineData(UserRole.NormalUser | UserRole.Finance)]
    [InlineData(UserRole.NormalUser | UserRole.Custodian)]
    [InlineData((UserRole)10)]
    [InlineData((UserRole)15)]
    public void GetStringLengthWithZeroIsSameAsToStringUsingFlagEnum(UserRole value)
    {
        int expected = value.ToString().Length;
        int actual = value.GetStringLength();

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
    public void GetStringLengthIsSameAsToString(HumanStates value)
    {
        int expected = value.ToString().Length;
        int actual = value.GetStringLength();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(Colours.Red | Colours.Blue | Colours.Green, Colours.Red)]
    [InlineData(Colours.Red | Colours.Blue | Colours.Green, Colours.Blue)]
    [InlineData(Colours.Red | Colours.Blue | Colours.Green, Colours.Green)]
    [InlineData(Colours.Red | Colours.Blue, Colours.Red)]
    [InlineData(Colours.Red | Colours.Blue, Colours.Blue)]
    [InlineData(Colours.Red | Colours.Blue, Colours.Green)]
    [InlineData(Colours.Red | Colours.Green, Colours.Red)]
    [InlineData(Colours.Red | Colours.Green, Colours.Blue)]
    [InlineData(Colours.Red | Colours.Green, Colours.Green)]
    [InlineData(Colours.Blue | Colours.Green, Colours.Red)]
    [InlineData(Colours.Blue | Colours.Green, Colours.Blue)]
    [InlineData(Colours.Blue | Colours.Green, Colours.Green)]
    [InlineData(Colours.Blue | Colours.Green, Colours.Green | Colours.Blue)]
    [InlineData(Colours.Blue | Colours.Green, Colours.Green | Colours.Red)]
    [InlineData(Colours.Blue, Colours.Red)]
    [InlineData(Colours.Blue, Colours.Red | Colours.Green)]
    [InlineData(Colours.Blue, Colours.Blue)]
    [InlineData((Colours)0, Colours.Red)]
    [InlineData((Colours)0, Colours.Blue)]
    [InlineData((Colours)0, Colours.Green)]
    [InlineData(Colours.Red, (Colours)0)]
    [InlineData(Colours.Blue, (Colours)0)]
    [InlineData(Colours.Green, (Colours)0)]
    public void HasFlagIsSameAsEnumHasFlag(Colours value, Colours flag)
    {
        bool expected = value.HasFlag(flag);
        bool actual = value.HasFlagFast(flag);

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

    [Theory]
    [InlineData(Colours.Red)]
    [InlineData(Colours.Blue)]
    [InlineData(Colours.Green)]
    [InlineData((Colours)0)]
    [InlineData(Colours.Red | Colours.Blue)]
    [InlineData(Colours.Red | Colours.Blue | Colours.Green)]
    [InlineData((Colours)15)]
    public void IsDefinedUsingFlagsIsSameAsEnumIsDefined(Colours value)
    {
        bool expected = Enum.IsDefined(value);
        bool actual = value.IsDefined();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(HumanStates.Idle, "1")]
    [InlineData(HumanStates.Working, "2")]
    [InlineData(HumanStates.Sleeping, "3")]
    [InlineData(HumanStates.Eating, "4")]
    [InlineData(HumanStates.Dead, "5")]
    public void MatchReturnsInlinedValue(HumanStates value, string expected)
    {
        var result = value.Match(Idle: "1", Working: "2", Sleeping: "3", Eating: "4", Dead: "5");

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(HumanStates.Idle)]
    [InlineData(HumanStates.Working)]
    [InlineData(HumanStates.Sleeping)]
    [InlineData(HumanStates.Eating)]
    [InlineData(HumanStates.Dead)]
    public void MatchReturnsCalculatedValue(HumanStates value)
    {
        var result = value.Match(
            Idle: v => v + "1",
            Working: v => v + "2",
            Sleeping: v => v + "3",
            Eating: v => v + "4",
            Dead: v => v + "5"
        );

        Assert.Equal($"{value.ToString()}{(int)value}", result);
    }
}
