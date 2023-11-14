using Markdig;
using Markdig.Parsers.Inlines;
using Markdig.Renderers;

namespace MarkdigExtensions.Wikilink;

public class WikilinkExtension : IMarkdownExtension
{
	public void Setup(MarkdownPipelineBuilder pipeline)
	{
		pipeline.InlineParsers.InsertBefore<LinkInlineParser>(new WikilinkParser());
	}

	public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
	{
		renderer.ObjectRenderers.Add(new WikilinkRenderer());
	}
}

public static class WikilinkPipelineBuilder
{
	public static MarkdownPipelineBuilder UseWikilinks(this MarkdownPipelineBuilder builder)
	{
		builder.Extensions.Add(new WikilinkExtension());
		return builder;
	}
}