using CustomResume.Library.Domain;
using CustomResume.Library.Infrastructure;
using CustomResumeBlazor.Domain;
using Microsoft.AspNetCore.Components;

namespace CustomResume.Library.Application.Components;

public partial class SideBarPage
{
    [Inject] private IWebsiteRepo WebsiteRepo { get; set; } = default!;

    private bool hasLoaded = false;
    private WebsiteData websiteData;
    private IOrderedEnumerable<OtherPages> sortedOtherPages;

    protected override async Task OnInitializedAsync()
    {
        if (hasLoaded) return;

        websiteData = await WebsiteRepo.GetWebsiteData();
        hasLoaded = websiteData is not null;
        sortedOtherPages = websiteData?.OtherPages?.OrderBy(x => x.SortOrder);
        StateHasChanged();
    }
}