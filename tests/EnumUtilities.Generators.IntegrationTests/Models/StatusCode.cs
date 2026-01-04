using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

[EnumGenerator]
public enum StatusCode
{
    Unknown = -1,
    Success = 0,
    Error = -2,

    [EnumMember(Value = "Not Found")]
    NotFound = -3,
    Timeout = -4,
    Unauthorized = -5,
    Forbidden = -6,
    Conflict = -7,
    Gone = -8,

    [Display(Name = "Invalid request", Description = "The request is invalid")]
    InvalidRequest = -9,

    ServerError = -10,
}
