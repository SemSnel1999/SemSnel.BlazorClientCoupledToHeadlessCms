using System.Net.Http.Json;
using System.Text.Json;
using Client.CMS.Models.Content.Abstractions;
using Client.CMS.Wrappers;
using Client.Infrastructure.CMS.Wrappers;
using Client.Shared.Models.Content.Elements;

namespace Client.CMS.Services;

public class ContentDeliveryService
{
    private readonly HttpClient _httpClient;
    
    public ContentDeliveryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<IContentWrapper?> GetByUrl(string url = "/index")
    {
        url = "/index";

        try
        {
            var jsonElement = await _httpClient.GetStreamAsync("sample-data/index.json");

            var result = await JsonSerializer.DeserializeAsync<IContentWrapper>(jsonElement);

            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return null;
    }
}