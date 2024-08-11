using Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests;

public class EnumMemberTests
{
    [Theory]
    [InlineData(PaymentMethod.Credit, "Credit card")]
    [InlineData(PaymentMethod.Debit, "Debit card")]
    [InlineData(PaymentMethod.Cash, "Cash")]
    [InlineData(PaymentMethod.Cheque, "Cheque")]
    public void ToEnumMemberValueShouldReturnExpectedValue(PaymentMethod paymentMethod, string expected)
    {
        string enumMemberValue = paymentMethod.ToEnumMemberValue();
        Assert.Equal(expected, enumMemberValue);
    }

    [Theory]
    [InlineData("Credit card", PaymentMethod.Credit)]
    [InlineData("Debit card", PaymentMethod.Debit)]
    [InlineData("Cash", PaymentMethod.Cash)]
    [InlineData("Cheque", PaymentMethod.Cheque)]
    public void TryParseFromEnumMemberValueShouldReturnExpectedValue(string value, PaymentMethod expected)
    {
        var enumMemberValue = PaymentMethodFactory.TryParseFromEnumMemberValue(value);
        Assert.Equal(expected, enumMemberValue);
    }

    [Theory]
    [InlineData("Credit")]
    [InlineData("Debit")]
    [InlineData("Physical Cash")]
    [InlineData("The payment by using physical cash")]
    public void TryParseFromEnumMemberValueShouldFail(string value)
    {
        bool isSuccess = PaymentMethodFactory.TryParseFromEnumMemberValue(value, out var result);
        Assert.False(isSuccess);
        Assert.Equal((PaymentMethod)0, result);
    }
}
