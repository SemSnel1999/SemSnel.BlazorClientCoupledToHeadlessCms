using Client.Infrastructure.CMS.Wrappers;

namespace Client.CMS.Models.Content.Abstractions;

public class PageContentBase
{
    public string SeoTitle { get; set; } = "SeoTitle";
    public string SeoDescription { get; set; }
    public IEnumerable<IContentWrapper> Elements { get; set; }
}