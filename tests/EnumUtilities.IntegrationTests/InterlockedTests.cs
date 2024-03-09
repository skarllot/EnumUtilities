using Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests;

public class InterlockedTests
{
    [Fact]
    public void ShouldAndColour()
    {
        const Colours red = Colours.Red;
        const Colours blue = Colours.Blue;
        const Colours green = Colours.Green;

        var target = red | blue | green;
        var result = target.InterlockedAnd(blue);

        Assert.Equal(blue, target);
        Assert.Equal(red | blue | green, result);
    }

    [Fact]
    public void ShouldOrColour()
    {
        Colours target = 0;
        var result1 = target.InterlockedOr(Colours.Blue);

        Assert.Equal(Colours.Blue, target);
        Assert.Equal((Colours)0, result1);

        var result2 = target.InterlockedOr(Colours.Green);

        Assert.Equal(Colours.Blue | Colours.Green, target);
        Assert.Equal(Colours.Blue, result2);
    }

    [Fact]
    public void ShouldCompareExchangeHumanStates()
    {
        var target = HumanStates.Idle;
        var result1 = target.InterlockedCompareExchange(HumanStates.Working, HumanStates.Idle);

        Assert.Equal(HumanStates.Working, target);
        Assert.Equal(HumanStates.Idle, result1);

        var result2 = target.InterlockedCompareExchange(HumanStates.Sleeping, HumanStates.Idle);

        Assert.Equal(HumanStates.Working, target);
        Assert.Equal(HumanStates.Working, result2);

        var result3 = target.InterlockedCompareExchange(HumanStates.Eating, HumanStates.Working);

        Assert.Equal(HumanStates.Eating, target);
        Assert.Equal(HumanStates.Working, result3);
    }
}
