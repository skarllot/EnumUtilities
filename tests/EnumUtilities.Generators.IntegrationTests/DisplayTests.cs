using Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests;

public class DisplayTests
{
    [Theory]
    [InlineData(PaymentMethod.Credit, "Credit Card")]
    [InlineData(PaymentMethod.Debit, "Debit Card")]
    [InlineData(PaymentMethod.Cash, "Physical Cash")]
    [InlineData(PaymentMethod.Cheque, "Cheque")]
    public void GetDisplayNameShouldReturnExpectedValue(PaymentMethod paymentMethod, string expected)
    {
        string displayName = paymentMethod.GetDisplayName();
        Assert.Equal(expected, displayName);
    }

    [Theory]
    [InlineData(WeekDays.Monday, "Monday")]
    [InlineData(WeekDays.Tuesday, "Tuesday")]
    [InlineData(WeekDays.Wednesday, "Wednesday")]
    [InlineData(WeekDays.Thursday, "Thursday")]
    [InlineData(WeekDays.Friday, "Friday")]
    [InlineData(WeekDays.Saturday, "Saturday")]
    [InlineData(WeekDays.Sunday, "Sunday")]
    public void GetDisplayNameShouldReturnResourceValue(WeekDays weekDays, string expected)
    {
        string displayName = weekDays.GetDisplayName();
        Assert.Equal(expected, displayName);
    }

    [Theory]
    [InlineData(WeekDays.Monday, "Mon")]
    [InlineData(WeekDays.Tuesday, "Tue")]
    [InlineData(WeekDays.Wednesday, "Wednesday")]
    [InlineData(WeekDays.Thursday, "Thursday")]
    [InlineData(WeekDays.Friday, "Fri")]
    [InlineData(WeekDays.Saturday, "Sat")]
    [InlineData(WeekDays.Sunday, "Sunday")]
    public void GetDisplayShortNameShouldReturnResourceValue(WeekDays weekDays, string expected)
    {
        string displayName = weekDays.GetDisplayShortName();
        Assert.Equal(expected, displayName);
    }

    [Theory]
    [InlineData(WeekDays.Monday, "The first day of the week")]
    [InlineData(WeekDays.Tuesday, null)]
    [InlineData(WeekDays.Wednesday, null)]
    [InlineData(WeekDays.Thursday, null)]
    [InlineData(WeekDays.Friday, null)]
    [InlineData(WeekDays.Saturday, "Almost the last day of the week")]
    [InlineData(WeekDays.Sunday, "The last day of the week")]
    public void GetDescriptionShouldReturnResourceValue(WeekDays weekDays, string? expected)
    {
        string? description = weekDays.GetDescription();
        Assert.Equal(expected, description);
    }

    [Theory]
    [InlineData("Credit Card", PaymentMethod.Credit)]
    [InlineData("Debit Card", PaymentMethod.Debit)]
    [InlineData("Physical Cash", PaymentMethod.Cash)]
    [InlineData("Cheque", PaymentMethod.Cheque)]
    public void TryCreateFromDisplayNameShouldReturnExpectedValue(string value, PaymentMethod expected)
    {
        var enumMemberValue = PaymentMethodFactory.TryCreateFromDisplayName(value);
        Assert.Equal(expected, enumMemberValue);
    }

    [Theory]
    [InlineData("Credit")]
    [InlineData("Debit")]
    [InlineData("Cash")]
    [InlineData("Credit card")]
    [InlineData("Debit card")]
    [InlineData("The payment by using physical cash")]
    public void TryCreateFromDisplayNameShouldFail(string value)
    {
        bool isSuccess = PaymentMethodFactory.TryCreateFromDisplayName(value, out var result);
        Assert.False(isSuccess);
        Assert.Equal((PaymentMethod)0, result);
    }
}
