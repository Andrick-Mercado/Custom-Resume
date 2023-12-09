using CustomResumeBlazor.Domain;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
namespace CustomResumeBlazor.Infrastructure;

public interface IDatabaseService
{
    Task<WebsiteDatabaseData> GetWebsiteDatabaseDataAsync();
}

public class DatabaseService : IDatabaseService
{
    private readonly HttpClient _httpClient;

    public DatabaseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:44398");
    }

    public async Task<WebsiteDatabaseData> GetWebsiteDatabaseDataAsync()
    {
        //var json = await File.ReadAllTextAsync("wwwroot/database/websiteData.json");
        //var websiteData = await JsonSerializer.DeserializeAsync<WebsiteDatabaseData>(new MemoryStream(Encoding.UTF8.GetBytes(json)));

        //if (websiteData is null)
        //    throw new Exception("Error deserializing website data");

        //return websiteData;
        var websiteData = await _httpClient.GetJsonAsync<WebsiteDatabaseData>("database/websiteData.json");

        if (websiteData is null)
            throw new Exception("Error deserializing website data");

        return websiteData;
    }
}
