using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

public class PaymentMethodEnumMemberValueConverter : ValueConverter<PaymentMethod, string>
{
    public PaymentMethodEnumMemberValueConverter()
        : base(
            model => model.ToEnumMemberValue(),
            provider =>
                PaymentMethodFactory.TryParseFromEnumMemberValue(provider, true) ?? 0)
    {
    }
}
