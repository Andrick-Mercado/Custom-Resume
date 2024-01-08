using CustomResumeBlazor.Domain;
using CustomResumeBlazor.Infrastructure;
using Microsoft.AspNetCore.Components;

namespace CustomResumeBlazor.Pages;

public partial class Index
{
    [Inject]
    private IDatabaseService DatabaseService { get; set; }

    private bool hasLoaded = false;
    private WebsiteDatabaseData websiteDatabaseData;

    protected override async Task OnInitializedAsync()
    {
        if (hasLoaded) return;

        websiteDatabaseData = await DatabaseService.GetWebsiteDatabaseDataAsync();
        hasLoaded = websiteDatabaseData is not null;
        StateHasChanged();
    }
}

