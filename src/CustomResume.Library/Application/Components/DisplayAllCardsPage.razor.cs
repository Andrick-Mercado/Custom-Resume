using CustomResume.Library.Domain;
using CustomResume.Library.Infrastructure;
using CustomResumeBlazor.Domain;
using Microsoft.AspNetCore.Components;

namespace CustomResume.Library.Application.Components;

public partial class DisplayAllCardsPage
{
    [Parameter] public string ClientRouteName { get; set; } = default!;

    [Inject] private IWebsiteRepo WebsiteRepo { get; set; } = default!;

    private bool _hasLoaded = false;
    private WebsiteData? _websiteDatabaseData;
    private OtherPages? _currentPage;

    protected override async Task OnInitializedAsync()
    {
        if (_hasLoaded && ClientRouteName == _currentPage?.Endpoint) return;

        _websiteDatabaseData = await WebsiteRepo.GetWebsiteData();
        _currentPage = _websiteDatabaseData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);

        _hasLoaded = _currentPage is not null;
        StateHasChanged();
    }

    protected override async Task OnParametersSetAsync()
    {
        if (_websiteDatabaseData is null)
        {
            _websiteDatabaseData = await WebsiteRepo.GetWebsiteData();
            _currentPage = _websiteDatabaseData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);
        }
        else if (_currentPage is not null && ClientRouteName != _currentPage.Endpoint)
        {
            _currentPage = _websiteDatabaseData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);
        }
        else
        {
            _currentPage ??= _websiteDatabaseData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);
        }

        _hasLoaded = _currentPage is not null;
        StateHasChanged();
    }

    private IEnumerable<IGrouping<string, Card>> GetCardsGroupedByCardName()
    {
        return _currentPage?.Cards.GroupBy(x => x.Name) ?? Array.Empty<IGrouping<string, Card>>();
    }

    private Card GetFirstCard()
    {
        return _currentPage?.Cards.FirstOrDefault() ?? new Card();
    }
}