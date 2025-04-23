using Microsoft.AspNetCore.Components;

namespace CustomResume.Maui.Components.Pages;

public partial class AllCardsPage
{
    [Parameter]
    public string ClientRouteName { get; set; } = default!;
}
