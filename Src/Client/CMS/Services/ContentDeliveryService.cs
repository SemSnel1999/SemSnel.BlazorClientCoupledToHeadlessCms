using System.Net.Http.Json;
using Client.CMS.Models.Content.Abstractions;
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
            var result = await _httpClient.GetFromJsonAsync<IContentWrapper>("sample-data/index.json");

            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return null;
    }
}