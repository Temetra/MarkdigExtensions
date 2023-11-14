using Markdig.Helpers;
using Markdig.Syntax.Inlines;

namespace MarkdigExtensions.Wikilink;

public class WikilinkInline : ContainerInline
{
	public bool IsImage { get; set; }
	public StringSlice Link { get; set; }
	public StringSlice Label { get; set; }
}
