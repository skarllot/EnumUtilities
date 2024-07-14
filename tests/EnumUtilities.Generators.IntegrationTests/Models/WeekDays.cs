using System.ComponentModel.DataAnnotations;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

[EnumGenerator]
public enum WeekDays
{
    [Display(
        Name = nameof(Strings.MondayFull),
        ShortName = nameof(Strings.MondayShort),
        Description = nameof(Strings.MondayDescription),
        ResourceType = typeof(Strings))]
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
    Sunday
}