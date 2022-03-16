using Client.Shared.Models.Content.Abstractions;

namespace Client.Shared.Models.Content.Elements;

public class HeroElementContent : SectionContent
{
    public string Text { get; set; }
    public string ImageSrc { get; set; }
}