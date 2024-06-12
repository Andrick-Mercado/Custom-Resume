using CustomResumeBlazor.Domain;
using System.Net.Http.Json;
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
    }

    public async Task<WebsiteDatabaseData> GetWebsiteDatabaseDataAsync()
    {
        return await _httpClient.GetFromJsonAsync<WebsiteDatabaseData>("database/websiteData.json")
               ?? throw new InvalidOperationException();
    }
}
