using Microsoft.AspNetCore.Components;

namespace CustomResume.Blazor.Pages;

public partial class AllCardsPage
{
    [Parameter]
    public string ClientRouteName { get; set; } = default!;
}