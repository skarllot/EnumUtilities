using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

[EnumGenerator]
public enum PaymentMethod
{
    [Display(Name = "Credit Card")]
    [EnumMember(Value = "Credit card")]
    Credit,
    [EnumMember(Value = "Debit card")]
    [Display(Name = "Debit Card")]
    Debit,
    [Display(Name = "Physical Cash")]
    [Description("The payment by using physical cash")]
    Cash,
    Cheque
}