using System.Runtime.CompilerServices;

namespace Raiqub.Generators.EnumUtilities.Tests;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Init()
    {
        VerifySourceGenerators.Enable();
    }
}