using CustomResumeBlazor.Domain;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
namespace CustomResumeBlazor.Infrastructure;

public interface IDatabaseService
{
    Task<WebsiteDatabaseData> GetWebsiteDatabaseDataAsync();
}

public class DatabaseService : IDatabaseService
{
    private readonly HttpClient _httpClient;

    private readonly object _lock = new();
    private WebsiteDatabaseData _websiteData;

    public DatabaseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        //httpClient.BaseAddress = new Uri("https://localhost:44398/");
        httpClient.BaseAddress = new Uri("https://andrick-mercado.github.io/Custom-Resume/");
    }

    public async Task<WebsiteDatabaseData> GetWebsiteDatabaseDataAsync()
    {
        lock (_lock)
        {
            if (_websiteData is not null)
            {
                return _websiteData;
            }
        }

        var websiteData  = await _httpClient.GetFromJsonAsync<WebsiteDatabaseData>("database/websiteData.json");

        if (websiteData is null)
            throw new Exception("Error deserializing website data");

        lock (_lock)
        {
            _websiteData ??= websiteData;
        }

        return _websiteData;
    }
}
