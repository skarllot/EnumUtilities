using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Raiqub.Generators.EnumUtilities.Common;

namespace Raiqub.Generators.EnumUtilities;

[Generator(LanguageNames.CSharp)]
public partial class EnumUtilitiesGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
#if Roslyn_440
        var providerForEnumGenerator = context.SyntaxProvider
            .ForAttributeWithMetadataName(
                EnumGeneratorAttributeName,
                IsSyntaxTargetForGeneration,
                GetSemanticTargetForGeneration)
            .WithTrackingName(TrackingNames.ExtractForEnumGeneratorAttribute)
            .WhereNotNull()
            .WithTrackingName(TrackingNames.RemoveNulls)
            .Collect();

        var providerForJsonConverterGenerator = context.SyntaxProvider
            .ForAttributeWithMetadataName(
                JsonConverterGeneratorAttribute,
                IsSyntaxTargetForGeneration,
                GetSemanticTargetForGeneration)
            .WithTrackingName(TrackingNames.ExtractForJsonConverterGeneratorAttribute)
            .WhereNotNull()
            .WithTrackingName(TrackingNames.RemoveNulls)
            .Collect();

        context.RegisterImplementationSourceOutput(providerForEnumGenerator, Emit);
        context.RegisterImplementationSourceOutput(providerForJsonConverterGenerator, Emit);
#else
        var compilation = context.CompilationProvider
            .Select((c, _) => c as CSharpCompilation);

        var provider = context.SyntaxProvider
            .CreateSyntaxProvider(IsSyntaxTargetForGeneration, GetSemanticTargetForGeneration)
            .WhereNotNull()
            .Collect()
            .Combine(compilation);

        context.RegisterImplementationSourceOutput(provider, Emit);
#endif
    }
}
