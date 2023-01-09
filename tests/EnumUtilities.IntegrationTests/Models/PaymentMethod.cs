using System.Runtime.Serialization;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

[EnumGenerator]
public enum PaymentMethod
{
    [EnumMember(Value = "Credit card")]
    Credit,
    [EnumMember(Value = "Debit card")]
    Debit,
    Cash
}