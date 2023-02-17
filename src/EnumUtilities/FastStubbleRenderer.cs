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
    private readonly StringBuilder _stringBuilder;
    private readonly StringRender _renderer;

    public FastStubbleRenderer(string template)
    {
        _enumExtensionsTemplate = MustacheParser.Parse(
            template,
            _settings.DefaultTags,
            pipeline: _settings.ParserPipeline);

        _stringBuilder = new StringBuilder();
        var writer = new StringWriter(_stringBuilder);
        _renderer = new StringRender(writer, _settings.RendererPipeline, _settings.MaxRecursionDepth);
    }

    public string Render(object view)
    {
        _stringBuilder.Clear();

        _renderer.Render(_enumExtensionsTemplate, new Context(view, _settings, _settings.RenderSettings));

        return _stringBuilder.ToString();
    }
}