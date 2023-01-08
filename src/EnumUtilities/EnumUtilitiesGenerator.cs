using Microsoft.CodeAnalysis;
using Raiqub.Generators.EnumUtilities.Common;

namespace Raiqub.Generators.EnumUtilities;

[Generator]
public partial class EnumUtilitiesGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var provider = context.SyntaxProvider
            .CreateSyntaxProvider(IsSyntaxTargetForGeneration, GetSemanticTargetForGeneration)
            .WhereNotNull()
            .Collect()
            .Combine(context.CompilationProvider);

        context.RegisterImplementationSourceOutput(provider, Emit);
    }
}