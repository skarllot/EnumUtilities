using Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests;

public class DescriptionTests
{
    [Theory]
    [InlineData(PaymentMethod.Credit, null)]
    [InlineData(PaymentMethod.Debit, null)]
    [InlineData(PaymentMethod.Cash, "The payment by using physical cash")]
    [InlineData(PaymentMethod.Cheque, null)]
    public void GetDescriptionShouldReturnExpectedValue(PaymentMethod paymentMethod, string? expected)
    {
        string? description = paymentMethod.GetDescription();
        Assert.Equal(expected, description);
    }

    [Theory]
    [InlineData("The payment by using physical cash", PaymentMethod.Cash)]
    public void CreateFromDescriptionShouldReturnExpectedValue(string description, PaymentMethod expected)
    {
        var paymentMethod = PaymentMethodFactory.CreateFromDescription(description);
        Assert.Equal(expected, paymentMethod);
    }

    [Theory]
    [InlineData("Any value")]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("the payment by using physical cash")]
    public void CreateFromDescriptionShouldThrowException(string description)
    {
        Assert.Throws<ArgumentException>(() => PaymentMethodFactory.CreateFromDescription(description));
    }

    [Fact]
    public void CreateFromNullDescriptionShouldThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => PaymentMethodFactory.CreateFromDescription(null!));
    }

    [Theory]
    [InlineData("The payment by using physical cash", PaymentMethod.Cash)]
    [InlineData("the payment by using physical cash", PaymentMethod.Cash)]
    [InlineData("THE PAYMENT BY USING PHYSICAL CASH", PaymentMethod.Cash)]
    public void CreateFromDescriptionIgnoringCaseShouldReturnExpectedValue(string description, PaymentMethod expected)
    {
        var paymentMethod = PaymentMethodFactory.CreateFromDescription(description, StringComparison.OrdinalIgnoreCase);
        Assert.Equal(expected, paymentMethod);
    }

    [Theory]
    [InlineData("The payment by using physical cash", PaymentMethod.Cash)]
    public void TryCreateFromDescriptionShouldReturnExpectedValue(string description, PaymentMethod expected)
    {
        var paymentMethod = PaymentMethodFactory.TryCreateFromDescription(description);
        Assert.Equal(expected, paymentMethod);
    }

    [Theory]
    [InlineData("Any value")]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("the payment by using physical cash")]
    public void TryCreateFromDescriptionShouldReturnNull(string description)
    {
        var result = PaymentMethodFactory.TryCreateFromDescription(description);
        Assert.Null(result);
    }
}
