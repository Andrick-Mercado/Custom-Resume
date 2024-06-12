using CustomResumeBlazor.Domain;
using CustomResumeBlazor.Infrastructure;
using Microsoft.AspNetCore.Components;

namespace CustomResume.Blazor.Shared
{
    public partial class NavMenu
    {
        [Inject]
        private IWebsiteRepo WebsiteRepo { get; set; } = default!;

        private bool hasLoaded = false;
        private WebsiteData? websiteData;
        private IOrderedEnumerable<OtherPages>? sortedOtherPages;

        protected override void OnInitialized()
        {
            if (hasLoaded) return;

            websiteData = WebsiteRepo.GetWebsiteData();
            hasLoaded = websiteData is not null;
            sortedOtherPages = websiteData?.OtherPages?.OrderBy(x => x.SortOrder);
            StateHasChanged();
        }
    }
}