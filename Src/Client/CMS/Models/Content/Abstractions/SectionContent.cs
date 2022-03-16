using Client.CMS.Models.Content;

namespace Client.Shared.Models.Content.Abstractions;

public class SectionContent
{
    public string Title { get; set; } 
    public string SubTitle { get; set; }
    public string LeadText { get; set; }
    public bool SplitterVisible { get; set; } = false;

    public IEnumerable<ActionContent> Actions { get; set; } = new List<ActionContent>();
}