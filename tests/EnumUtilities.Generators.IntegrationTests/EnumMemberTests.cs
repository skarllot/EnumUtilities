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

    [Theory]
    [InlineData(UserRole.None, UserRoleMetadata.SerializedValue.None)]
    [InlineData(UserRole.NormalUser, UserRoleMetadata.SerializedValue.NormalUser)]
    [InlineData(UserRole.Custodian, UserRoleMetadata.SerializedValue.Custodian)]
    [InlineData(UserRole.Finance, UserRoleMetadata.SerializedValue.Finance)]
    [InlineData(UserRole.SuperUser, UserRoleMetadata.SerializedValue.SuperUser)]
    [InlineData(UserRole.All, UserRoleMetadata.SerializedValue.All)]
    [InlineData(UserRole.NormalUser | UserRole.Finance, "Normal User, Finance")]
    public void ToEnumMemberValueShouldReturnExpectedFlagsValue(UserRole userRole, string expected)
    {
        string enumMemberValue = userRole.ToEnumMemberValue();
        Assert.Equal(expected, enumMemberValue);
    }

    [Theory]
    [InlineData(UserRoleMetadata.SerializedValue.None, UserRole.None)]
    [InlineData(UserRoleMetadata.SerializedValue.NormalUser, UserRole.NormalUser)]
    [InlineData(UserRoleMetadata.SerializedValue.Custodian, UserRole.Custodian)]
    [InlineData(UserRoleMetadata.SerializedValue.Finance, UserRole.Finance)]
    [InlineData(UserRoleMetadata.SerializedValue.SuperUser, UserRole.SuperUser)]
    [InlineData(UserRoleMetadata.SerializedValue.All, UserRole.All)]
    [InlineData("Normal User, Finance", UserRole.NormalUser | UserRole.Finance)]
    [InlineData("Normal User, Finance, Custodian", UserRole.All)]
    public void TryParseFromEnumMemberValueShouldReturnExpectedFlagValue(string value, UserRole userRole)
    {
        var enumMemberValue = UserRoleFactory.TryParseFromEnumMemberValue(value);
        Assert.Equal(userRole, enumMemberValue);
    }
}
