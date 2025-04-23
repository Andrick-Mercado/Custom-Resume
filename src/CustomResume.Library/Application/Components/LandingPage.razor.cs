using CustomResume.Library.Domain;
using CustomResume.Library.Infrastructure;
using Microsoft.AspNetCore.Components;

namespace CustomResume.Library.Application.Components;

public partial class LandingPage
{
    [Inject] private IWebsiteRepo WebsiteRepo { get; set; } = default!;

    private bool _hasLoaded = false;
    private WebsiteData _websiteDatabaseData;
    private MainPage _mainPage;

    protected override async Task OnInitializedAsync()
    {
        if (_hasLoaded) return;

        _websiteDatabaseData = await WebsiteRepo.GetWebsiteData();
        _hasLoaded = _websiteDatabaseData is not null;
        _mainPage = _websiteDatabaseData?.MainPage;
        StateHasChanged();
    }
}