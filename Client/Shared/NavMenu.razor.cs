using CustomResumeBlazor.Domain;
using CustomResumeBlazor.Infrastructure;
using Microsoft.AspNetCore.Components;

namespace CustomResumeBlazor.Shared;

public partial class NavMenu
{
    [Inject]
    private IDatabaseService DatabaseService { get; set; }

    private bool hasLoaded = false;
    private WebsiteDatabaseData? websiteDatabaseData;

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(3000);
        websiteDatabaseData = await DatabaseService.GetWebsiteDatabaseDataAsync();
        hasLoaded = true;
        StateHasChanged();
    }
}
