using Client.Components.Content.Elements;
using Client.Components.Content.Pages;
using Client.Infrastructure.CMS.Wrappers;
using Client.Shared.Models.Content.Elements;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Client.CMS.Components
{
    public class ContentPageTemplateSelector : ComponentBase
    {
        [Parameter] public IContentWrapper ContentWrapper { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var alias = ContentWrapper.ContentTypeAlias;

            var hasTemplate = this.TryGetComponentType(alias, out var type);

            if (!hasTemplate)
            {
                type = typeof(DefaultPage);
            }

            builder.OpenComponent(0, type);
            builder.AddAttribute(1, nameof(ContentComponent<object>.ContentWrapper), ContentWrapper);
            builder.CloseComponent();
        }

        private bool TryGetComponentType(string alias, out Type type)
        {
            type = null;
            
            // In this project I will not be adding custom templates for pages, but it is nice to known where to put it ;)

            return false;
        }
    }
}