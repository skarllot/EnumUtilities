using System.Reflection;
using System.Text;

namespace Raiqub.Generators.EnumUtilities;

public static class ResourceProvider
{
    private const string ResourcePrefix = "Raiqub.Generators.EnumUtilities.Resources.";
    private static readonly Assembly ThisAssembly = typeof(ResourceProvider).Assembly;
    private static string? enumExtensions;
    private static string? enumFactory;
    private static string? enumValidation;

    public static string EnumExtensions =>
        enumExtensions ??= LoadEmbeddedResource(ResourcePrefix + "EnumExtensions.mustache");

    public static string EnumFactory =>
        enumFactory ??= LoadEmbeddedResource(ResourcePrefix + "EnumFactory.mustache");

    public static string EnumValidation =>
        enumValidation ??= LoadEmbeddedResource(ResourcePrefix + "EnumValidation.mustache");

    private static string LoadEmbeddedResource(string resourceName)
    {
        using var stream = ThisAssembly.GetManifestResourceStream(resourceName);
        if (stream is null)
        {
            string[] resourceNames = ThisAssembly.GetManifestResourceNames();
            throw new ArgumentException(
                $"Could not find embedded resource {resourceName}. " +
                $"Available names: {string.Join(", ", resourceNames)}.");
        }

        using var reader = new StreamReader(stream, Encoding.UTF8);
        return reader.ReadToEnd();
    }
}