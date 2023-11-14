using Markdig.Renderers;
using Markdig.Renderers.Html;

namespace MarkdigExtensions.Wikilink;

public class WikilinkRenderer : HtmlObjectRenderer<WikilinkInline>
{
	public string MediaLocation { get; set; } = "/media/";
	public string PageRoot { get; set; } = "/";
	public string PageExtension { get; set; } = ".html";
	public string IndexPageName { get; set; } = "index";
	public bool ShortenIndexLinks { get; set; } = true;

	protected override void Write(HtmlRenderer renderer, WikilinkInline obj)
	{
		if (renderer.EnableHtmlForInline)
		{
			if (obj.IsImage)
			{
				var link = $"{MediaLocation}{obj.Link}";
				renderer.Write($"<img src=\"{link}\" alt=\"{obj.Label}\" />");
			}
			else
			{
				var link = $"{PageRoot}{obj.Link}{PageExtension}";
				if (ShortenIndexLinks) link = link.Replace($"/{IndexPageName}{PageExtension}", "/");
				renderer.Write($"<a href=\"{link}\">{obj.Label}</a>");
			}
		}
	}
}
