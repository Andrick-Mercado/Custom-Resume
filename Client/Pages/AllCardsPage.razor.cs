using CustomResumeBlazor.Domain;
using CustomResumeBlazor.Infrastructure;
using Microsoft.AspNetCore.Components;

namespace CustomResumeBlazor.Pages;

public partial class AllCardsPage
{
    [Parameter]
    public string ClientRouteName { get; set; }

    [Inject]
    private IWebsiteRepo WebsiteRepo { get; set; }

    private bool hasLoaded = false;
    private WebsiteData websiteDatabaseData;
    private OtherPages currentPage;

    protected override async Task OnInitializedAsync()
    {
        if (hasLoaded && ClientRouteName == currentPage.Endpoint) return;

        websiteDatabaseData = await WebsiteRepo.GetWebsiteDataAsync();
        currentPage = websiteDatabaseData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);

        if (currentPage is not null)
            hasLoaded = true;


        StateHasChanged();
    }

    protected override async Task OnParametersSetAsync()
    {
        if (websiteDatabaseData is null)
        {
            websiteDatabaseData = await WebsiteRepo.GetWebsiteDataAsync();
            currentPage = websiteDatabaseData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);
        }

        if (currentPage is not null && ClientRouteName != currentPage.Endpoint)
            currentPage = websiteDatabaseData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);
        else if (currentPage is null)
            currentPage = websiteDatabaseData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);

        if (currentPage is not null)
            hasLoaded = true;
        else
            hasLoaded = false;


        StateHasChanged();
    }

    private IEnumerable<IGrouping<string, Card>> GetCardsGroupedByCardName()
    {
        return currentPage.Cards.GroupBy(x => x.Name);
    }

    private Card GetGoogleDocCard()
    {
        return currentPage.Cards.FirstOrDefault();
    }
}
