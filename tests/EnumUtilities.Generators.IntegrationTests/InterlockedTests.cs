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

    [Fact]
    public void ShouldExchangePaymentMethod()
    {
        var target = PaymentMethod.Credit;
        var result1 = target.InterlockedExchange(PaymentMethod.Cash);

        Assert.Equal(PaymentMethod.Cash, target);
        Assert.Equal(PaymentMethod.Credit, result1);

        var result2 = target.InterlockedExchange(PaymentMethod.Cheque);

        Assert.Equal(PaymentMethod.Cheque, target);
        Assert.Equal(PaymentMethod.Cash, result2);
    }

    [Fact]
    public void ShouldRead64BitUserRole()
    {
        var target = UserRole.SuperUser;
        var result = target.InterlockedRead();

        Assert.Equal(UserRole.SuperUser, target);
        Assert.Equal(UserRole.SuperUser, result);
    }

    [Fact]
    public void ShouldAddWeekDays()
    {
        var target = WeekDays.Monday;
        var result1 = target.InterlockedAdd(3);

        Assert.Equal(WeekDays.Thursday, target);
        Assert.Equal(WeekDays.Thursday, result1);

        var result2 = target.InterlockedAdd(-1);

        Assert.Equal(WeekDays.Wednesday, target);
        Assert.Equal(WeekDays.Wednesday, result2);
    }

    [Fact]
    public void ShouldDecrementWeekDays()
    {
        var target = WeekDays.Sunday;
        var result1 = target.InterlockedDecrement();

        Assert.Equal(WeekDays.Saturday, target);
        Assert.Equal(WeekDays.Saturday, result1);

        var result2 = target.InterlockedDecrement();

        Assert.Equal(WeekDays.Friday, target);
        Assert.Equal(WeekDays.Friday, result2);
    }

    [Fact]
    public void ShouldIncrementWeekDays()
    {
        var target = WeekDays.Wednesday;
        var result1 = target.InterlockedIncrement();

        Assert.Equal(WeekDays.Thursday, target);
        Assert.Equal(WeekDays.Thursday, result1);

        var result2 = target.InterlockedIncrement();

        Assert.Equal(WeekDays.Friday, target);
        Assert.Equal(WeekDays.Friday, result2);
    }
}
