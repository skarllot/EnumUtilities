using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Raiqub.Generators.EnumUtilities.Common;
using Raiqub.Generators.EnumUtilities.Models;

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
            .Where(x => (x.SelectedGenerators & SelectedGenerators.MainGenerator) == 0)
            .Collect();

        context.RegisterImplementationSourceOutput(providerForEnumGenerator, Emit);
        context.RegisterImplementationSourceOutput(providerForJsonConverterGenerator, Emit);
#else
        var provider = context.SyntaxProvider
            .CreateSyntaxProvider(IsSyntaxTargetForGeneration, GetSemanticTargetForGeneration)
            .WhereNotNull()
            .Collect()
            .Combine(context.CompilationProvider);

        context.RegisterImplementationSourceOutput(provider, Emit);
#endif
    }
}
