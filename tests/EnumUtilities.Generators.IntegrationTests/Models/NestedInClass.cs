using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

public class NestedInClass
{
    [EnumGenerator]
    internal enum MyEnum1
    {
        Zero,
        One,
        Two,
    }

    [EnumGenerator]
    internal enum MyEnum2
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
        Cheque,
    }

    [EnumGenerator]
    public enum MyEnum3
    {
        [Display(
            Name = nameof(Strings.MondayFull),
            ShortName = nameof(Strings.MondayShort),
            Description = nameof(Strings.MondayDescription),
            ResourceType = typeof(Strings)
        )]
        Monday,

        [Display(ShortName = "Tue")]
        Tuesday,

        [Display]
        Wednesday,

        [Display(Name = "Thursday")]
        Thursday,

        [Display(Name = "Friday", ShortName = "Fri")]
        Friday,

        [Display(ShortName = "Sat", Description = "Almost the last day of the week")]
        Saturday,

        [Display(Description = "The last day of the week")]
        Sunday,
    }

    [EnumGenerator]
    private enum MyEnum4
    {
        Zero,
        One,
        Two,
    }

    [EnumGenerator]
    enum MyEnum5
    {
        Zero,
        One,
        Two,
    }
}
