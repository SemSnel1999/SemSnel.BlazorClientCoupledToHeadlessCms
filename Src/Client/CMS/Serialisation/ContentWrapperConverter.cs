using System.Text.Json;
using System.Text.Json.Serialization;
using Client.CMS.Models.Content.Abstractions;
using Client.CMS.Wrappers;
using Client.Infrastructure.CMS.Wrappers;
using Client.Shared.Models.Content.Elements;

namespace Client.CMS.Serialisation;

public class ContentWrapperConverter : JsonConverter<IContentWrapper>
{
    public override IContentWrapper? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        
        var element = JsonElement.ParseValue(ref reader);

        var modelElement = element.GetProperty("model");

        var alias = element.GetProperty("contentTypeAlias").ToString();
        
        var modelType = GetModelType(alias);
        
        var model = JsonSerializer.Deserialize(modelElement, modelType, options);

        var wrapperType = GetWrapperType(modelType);

        var result = JsonSerializer.Deserialize(element, wrapperType, options);

        if (result is IContentWrapper contentWrapper)
        {
            
            
            contentWrapper.SetModel(model);
            
            return contentWrapper;
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, IContentWrapper value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize<object>(writer, value, options);
    }

    private string GetAlias(ref Utf8JsonReader reader)
    {
        var element = JsonElement.ParseValue(ref reader);

        var hasAlias = element.TryGetProperty("contentTypeAlias", out var alias);

        return hasAlias ? alias.ToString() : string.Empty;
    }

    private Type GetModelType(string alias)
    {
        // Consider using a injected dictionary for this
        // This is simpler but this shouldn't be considered the converters task
        return @alias switch
        {
            "heroElement" => typeof(HeroElementContent),
            "paragraphElement" => typeof(ParagraphElementContent),
            "callToActionElement" => typeof(CallToActionContent),
            _ => typeof(PageContentBase)
        };
    }

    public Type GetWrapperType(Type modelType)
    {
        var baseType = typeof(ContentWrapper<>);
        
        var wrapperType = baseType
            .GetGenericTypeDefinition()
            .MakeGenericType(modelType);

        return wrapperType;
    }
}