using CustomResumeBlazor.Domain;
using CustomResumeBlazor.Infrastructure;
using Microsoft.AspNetCore.Components;

namespace CustomResumeBlazor.Shared;

public partial class NavMenu
{
    [Inject]
    private IDatabaseService DatabaseService { get; set; }

    private bool hasLoaded = false;
    private WebsiteDatabaseData websiteDatabaseData;
    private IOrderedEnumerable<OtherPages> sortedOtherPages;

    protected override async Task OnInitializedAsync()
    {
        if (hasLoaded) return;

        websiteDatabaseData = await DatabaseService.GetWebsiteDatabaseDataAsync();
        hasLoaded = websiteDatabaseData is not null;
        sortedOtherPages = websiteDatabaseData.WebsiteData.OtherPages.OrderBy(x => x.SortOrder);
        StateHasChanged();
    }
}
