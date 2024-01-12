using CustomResumeBlazor.Domain;

namespace CustomResumeBlazor.Infrastructure;

public interface IWebsiteRepo
{
    Task<Configurations> GetConfigurationsAsync();
    Task<PersonalInformation> GetPersonalInformationAsync();
    Task<WebsiteData> GetWebsiteDataAsync();
}

public class WebsiteRepo : IWebsiteRepo
{
    private readonly IDatabaseService _databaseService;

    public WebsiteRepo(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public async Task<Configurations> GetConfigurationsAsync()
    {
        var websiteDatabaseData = await _databaseService.GetWebsiteDatabaseDataAsync();
        return websiteDatabaseData.Configurations;
    }

    public async Task<PersonalInformation> GetPersonalInformationAsync()
    {
        var websiteDatabaseData = await _databaseService.GetWebsiteDatabaseDataAsync();
        return websiteDatabaseData.PersonalInformation;
    }

    public async Task<WebsiteData> GetWebsiteDataAsync()
    {
        var websiteDatabaseData = await _databaseService.GetWebsiteDatabaseDataAsync();
        return websiteDatabaseData.WebsiteData;
    }
}
