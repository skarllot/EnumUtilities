using System.Diagnostics.CodeAnalysis;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

[EnumGenerator]
[JsonConverterGenerator]
[SuppressMessage("Naming", "CA1708:Identifiers should differ by more than case")]
public enum Bug357
{
    Py1,
    pay,
    PAY,
    John,
    john,
    JOHN,
}
