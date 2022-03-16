using System.Text.Json.Serialization;
using Client.CMS.Serialisation;

namespace Client.Infrastructure.CMS.Wrappers;

/// <summary>
/// Wraps a converted content model, sot that the model can be converted to json
/// </summary>
[JsonConverter(typeof(ContentWrapperConverter))]
public interface IContentWrapper
{
    public Guid Id { get; set; }
    public string ContentTypeAlias { get; set; }
    public string Url { get; set; }
    public object? GetModel();
    public void SetModel(object model);
}


public interface IContentWrapper<TModel> : IContentWrapper
{
    public TModel? Model { get; set; }
}