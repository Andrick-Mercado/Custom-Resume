using CustomResumeBlazor.Domain;
using CustomResumeBlazor.Infrastructure;
using Microsoft.AspNetCore.Components;

namespace CustomResumeBlazor.Pages;

public partial class AllCardsPage
{
    [Parameter]
    public string ClientRouteName { get; set; }

    [Inject]
    private IDatabaseService DatabaseService { get; set; }

    private bool hasLoaded = false;
    private WebsiteDatabaseData websiteDatabaseData;
    private OtherPages currentPage;

    protected override async Task OnInitializedAsync()
    {
        if (hasLoaded && ClientRouteName == currentPage.Endpoint) return;

        websiteDatabaseData = await DatabaseService.GetWebsiteDatabaseDataAsync();
        currentPage = websiteDatabaseData.WebsiteData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);

        if (currentPage is not null)
            hasLoaded = true;


        StateHasChanged();
    }

    protected override async Task OnParametersSetAsync()
    {
        websiteDatabaseData = websiteDatabaseData is null ?
           await DatabaseService.GetWebsiteDatabaseDataAsync() :
            websiteDatabaseData;

        if (currentPage is not null && ClientRouteName != currentPage.Endpoint)
            currentPage = websiteDatabaseData.WebsiteData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);
        else if (currentPage is null)
            currentPage = websiteDatabaseData.WebsiteData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);

        if (currentPage is not null)
            hasLoaded = true;
        else
            hasLoaded = false;


        StateHasChanged();
    }
}
