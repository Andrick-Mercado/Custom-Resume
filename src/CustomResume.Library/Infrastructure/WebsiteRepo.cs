using CustomResumeBlazor.Domain;

namespace CustomResumeBlazor.Infrastructure;

public interface IWebsiteRepo
{
    Configurations GetConfigurations();
    PersonalInformation GetPersonalInformation();
    WebsiteData GetWebsiteData();
}

public class WebsiteRepo : IWebsiteRepo
{
    private readonly IDatabaseService _databaseService;
    private WebsiteDatabaseData _websiteDatabaseData = default!;

    public WebsiteRepo(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public async Task InitializeAsync()
    {
        _websiteDatabaseData = await _databaseService.GetWebsiteDatabaseDataAsync();
    }

    public Configurations GetConfigurations()
    {
        return _websiteDatabaseData.Configurations;
    }

    public PersonalInformation GetPersonalInformation()
    {
        return _websiteDatabaseData.PersonalInformation;
    }

    public WebsiteData GetWebsiteData()
    {
        return _websiteDatabaseData.WebsiteData;
    }
}