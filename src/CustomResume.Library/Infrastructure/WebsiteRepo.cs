using CustomResume.Library.Domain;
using CustomResume.Library.Infrastructure.Repo;
using CustomResumeBlazor.Domain;

namespace CustomResume.Library.Infrastructure;

public interface IWebsiteRepo
{
    Task<Configurations> GetConfigurations();
    Task<PersonalInformation> GetPersonalInformation();
    Task<WebsiteData> GetWebsiteData();
}

public class WebsiteRepo : IWebsiteRepo
{
    private readonly IDatabaseService _databaseService;
    private WebsiteDatabaseData _websiteDatabaseData = default!;
    private bool _initialized = false;

    public WebsiteRepo(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public async Task EnsureInitializedAsync()
    {
        if (_initialized is false)
        {
            _websiteDatabaseData = await _databaseService.GetWebsiteDatabaseDataAsync();
            _initialized = true;
        }
    }

    public async Task<Configurations> GetConfigurations()
    {
        await EnsureInitializedAsync();
        return _websiteDatabaseData.Configurations;
    }

    public async Task<PersonalInformation> GetPersonalInformation()
    {
        await EnsureInitializedAsync();
        return _websiteDatabaseData.PersonalInformation;
    }

    public async Task<WebsiteData> GetWebsiteData()
    {
        await EnsureInitializedAsync();
        return _websiteDatabaseData.WebsiteData;
    }
}