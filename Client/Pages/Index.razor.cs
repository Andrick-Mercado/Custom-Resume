using CustomResumeBlazor.Domain;
using CustomResumeBlazor.Infrastructure;
using Microsoft.AspNetCore.Components;

namespace CustomResumeBlazor.Pages;

public partial class Index
{
    [Inject]
    private IWebsiteRepo WebsiteRepo { get; set; } = default!;

    private bool hasLoaded = false;
    private WebsiteData? websiteDatabaseData;
    private MainPage? mainPage;

    protected override void OnInitialized()
    {
        if (hasLoaded) return;

        websiteDatabaseData = WebsiteRepo.GetWebsiteData();
        hasLoaded = websiteDatabaseData is not null;
        mainPage = websiteDatabaseData?.MainPage;
        StateHasChanged();
    }
}

