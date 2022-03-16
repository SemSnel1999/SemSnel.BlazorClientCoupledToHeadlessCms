using System.Text.Json.Serialization;
using Client.CMS.Serialisation;
using Client.Infrastructure.CMS.Wrappers;

namespace Client.CMS.Wrappers;

/// <inheritdoc />
///
public class ContentWrapper : IContentWrapper
{
    private object? _model;
    
    [JsonPropertyOrder(1)]
    public Guid Id { get; set; }

    [JsonPropertyOrder(2)]
    public string ContentTypeAlias { get; set; }
    [JsonPropertyOrder(3)]
    public string Url { get; set; }
    
    [JsonPropertyOrder(4)]
    public string Name { get; set; }

    public virtual object? GetModel()
    {
        return _model;
    }

    public virtual void SetModel(object model)
    {
        _model = model;
    }
}

public class ContentWrapper<TModel> : ContentWrapper, IContentWrapper<TModel> where TModel : class
{
    
    [JsonPropertyOrder(5)]
    public virtual TModel? Model { get; set; }

    public override object? GetModel()
    {
        return Model;
    }

    public override void SetModel(object value)
    {
        if (value is not TModel model)
        {
            throw new ArgumentException($"wrong value type given should be of type: {typeof(TModel).FullName}");
        }
        
        Model = model;
    }
}