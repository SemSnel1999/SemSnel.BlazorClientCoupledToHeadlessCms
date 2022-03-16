using Client.CMS.Wrappers;
using Client.Components.Content.Elements;
using Client.Infrastructure.CMS.Wrappers;
using Client.Shared.Models.Content.Elements;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Client.CMS.Components
{
    public class ContentElementTemplateSelector : ComponentBase
    {
        [Parameter] public IEnumerable<IContentWrapper> Elements { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            StateHasChanged();
            this.ShouldRender();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if(Elements is null)
                return;
            
            foreach (var element in Elements)
            {
                RenderElement(element, builder);
            }
        }

        private void RenderElement(IContentWrapper content, RenderTreeBuilder builder)
        {
            var alias = content.ContentTypeAlias;

            var hasTemplate = this.TryGetComponentType(alias, out var type);

            if (!hasTemplate)
            {
                type = typeof(UnknownElement);
            }

            builder.OpenComponent(0, type);
            builder.AddAttribute(1, nameof(ContentComponent<object>.ContentWrapper), content);
            builder.AddAttribute(2, nameof(ContentComponent<object>.Model), content.GetModel());
            builder.CloseComponent();
        }

        private bool TryGetComponentType(string alias, out Type type)
        {
            type = null;

            // I prefer to use a injected dictionary for storing types, but for simplicity we are using a switch case
            switch (@alias)
            {
                case "heroElement":
                    type = typeof(HeroElement);
                    return true;
                case "callToActionElement":
                    type = typeof(CallToAction);
                    return true;
                case "paragraphElement":
                    type = typeof(Paragraph);
                    return true;
            }
        
            return false;
        }
    }
}