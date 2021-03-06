using System.Net.Http.Json;
using System.Text.Json;
using Client.CMS.Models.Content.Abstractions;
using Client.CMS.Wrappers;
using Client.Infrastructure.CMS.Wrappers;
using Client.Shared.Models.Content.Elements;
using Microsoft.AspNetCore.Components;

namespace Client.CMS.Services;

public class ContentDeliveryService
{
    private readonly HttpClient _httpClient;
    
    public ContentDeliveryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IContentWrapper?> GetByUrl(string url = null)
    {
        if (string.IsNullOrEmpty(url))
        {
            url = "index";
        }

        try
        {
            var jsonElement = await _httpClient.GetStreamAsync($"sample-data/{url}.json");

            var result = await JsonSerializer.DeserializeAsync<IContentWrapper>(jsonElement);

            return result;
        }
        catch (Exception ex)
        {
            throw ex; // Do something with the exception
        }
        return null;
    }
}