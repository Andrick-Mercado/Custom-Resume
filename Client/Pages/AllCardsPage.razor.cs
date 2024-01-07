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
        if (hasLoaded) return;

        await Task.Delay(3000);
        websiteDatabaseData = await DatabaseService.GetWebsiteDatabaseDataAsync();
        currentPage = websiteDatabaseData.WebsiteData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);

        if (currentPage is not null)
            hasLoaded = true;


        StateHasChanged();
    }
}
