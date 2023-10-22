using Blazored.LocalStorage;
using CustomResumeBlazor.Domain;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CustomResumeBlazor.Shared;

public partial class MainLayout
{
    [Inject]
    public ProfileService ProfileService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _preferences = await ProfileService.GetPreferences();
        _isDarkCurrentTheme = _preferences.DarkMode;
        StateHasChanged();
    }

    private void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }

    private async Task ChangeThemeAsync()
    {

        _isDarkCurrentTheme = await ProfileService.ToggleDarkMode();
        StateHasChanged();
    }

    #region Private fields
    private readonly MudTheme _currentTheme = new()
    {
        Palette = new PaletteLight
        {
            AppbarBackground = "#0097FF",
            AppbarText = "#FFFFFF",
            Primary = "#007CD1",
            TextPrimary = "#0C1217",
            Background = "#F4FDFF",
            TextSecondary = "#0C1217",
            DrawerBackground = "#C5E5FF",
            DrawerIcon = "#000000",
            DrawerText = "#0C1217",
            Surface = "#E4FAFF",
            ActionDefault = "#0C1217",
            ActionDisabled = "#2F678C",
            TextDisabled = "#676767",

        },
        PaletteDark = new PaletteDark
        {
            AppbarBackground = "#0097FF",
            AppbarText = "#FFFFFF",
            Primary = "#007CD1",
            Secondary = "#000000",
            TextPrimary = "#FFFFFF",
            Background = "#001524",
            TextSecondary = "#E2EEF6",
            DrawerBackground = "#093958",
            DrawerIcon = "#FFFFFF",
            DrawerText = "#FFFFFF",
            Surface = "#093958",
            ActionDefault = "#0C1217",
            ActionDisabled = "#2F678C",
            TextDisabled = "#B0B0B0"
        }
    };
    private Preferences _preferences = new();
    private bool _isDarkCurrentTheme = true;
    private bool _drawerOpen = true;
    #endregion
}

