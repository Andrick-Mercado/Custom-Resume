using CustomResumeBlazor.Domain;
using CustomResumeBlazor.Infrastructure;
using Microsoft.AspNetCore.Components;

namespace CustomResumeBlazor.Pages;

public partial class Index
{
    [Inject]
    private IWebsiteRepo WebsiteRepo { get; set; }

    private bool hasLoaded = false;
    private WebsiteData websiteDatabaseData;
    private MainPage mainPage;

    protected override async Task OnInitializedAsync()
    {
        if (hasLoaded) return;

        websiteDatabaseData = await WebsiteRepo.GetWebsiteDataAsync();
        hasLoaded = websiteDatabaseData is not null;
        mainPage = websiteDatabaseData?.MainPage;
        StateHasChanged();
    }
}

