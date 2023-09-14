using System.Text;
using Stubble.Core.Contexts;
using Stubble.Core.Parser;
using Stubble.Core.Renderers.StringRenderer;
using Stubble.Core.Settings;
using Stubble.Core.Tokens;

namespace Raiqub.Generators.EnumUtilities;

public class FastStubbleRenderer
{
    private static readonly RendererSettings _settings = new RendererSettingsBuilder().BuildSettings();

    private readonly MustacheTemplate _enumExtensionsTemplate;

    public FastStubbleRenderer(string template)
    {
        _enumExtensionsTemplate = MustacheParser.Parse(
            template,
            _settings.DefaultTags,
            pipeline: _settings.ParserPipeline);
    }

    public string Render(object view)
    {
        var sb = new StringBuilder();
        var writer = new StringWriter(sb);
        var renderer = new StringRender(writer, _settings.RendererPipeline, _settings.MaxRecursionDepth);

        renderer.Render(_enumExtensionsTemplate, new Context(view, _settings, _settings.RenderSettings));

        return sb.ToString();
    }
}