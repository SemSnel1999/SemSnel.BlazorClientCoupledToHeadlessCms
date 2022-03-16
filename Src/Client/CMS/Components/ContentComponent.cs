using Client.Infrastructure.CMS.Wrappers;
using Microsoft.AspNetCore.Components;

namespace Client.CMS.Components;

public abstract class ContentComponent<TContent> : ComponentBase
{
    private TContent? _model;
    [Parameter] 
    public IContentWrapper<TContent>? ContentWrapper { get; set; }

    [Parameter]
    public TContent? Model
    {
        get => _model ??= ContentWrapper.Model;
        set => _model = value;
    }
}