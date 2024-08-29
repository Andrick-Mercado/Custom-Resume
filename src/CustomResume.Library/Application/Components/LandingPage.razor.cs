using CustomResume.Library.Domain;
using CustomResume.Library.Infrastructure;
using CustomResumeBlazor.Domain;
using Microsoft.AspNetCore.Components;

namespace CustomResume.Library.Application.Components;

public partial class LandingPage
{
    [Inject] private IWebsiteRepo WebsiteRepo { get; set; } = default!;

    private bool hasLoaded = false;
    private WebsiteData? websiteDatabaseData;
    private MainPage? mainPage;

    protected override async Task OnInitializedAsync()
    {
        if (hasLoaded) return;

        websiteDatabaseData = await WebsiteRepo.GetWebsiteData();
        hasLoaded = websiteDatabaseData is not null;
        mainPage = websiteDatabaseData?.MainPage;
        StateHasChanged();
    }
}