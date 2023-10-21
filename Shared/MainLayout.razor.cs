using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CustomResumeBlazor.Shared;

public partial class MainLayout
{
    [Inject]
    public ILocalStorageService LocalStorage { get; set; }

    protected async override Task OnInitializedAsync()
    {
        if (await LocalStorage.ContainKeyAsync("theme"))
        {
            _isDarkCurrentTheme = await LocalStorage.GetItemAsync<bool>("theme");
        }
        else
        {
            _isDarkCurrentTheme = true;
        }

        _currentTheme = _isDarkCurrentTheme ? _darkTheme : _lightTheme;
    }

    private void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }

    private async Task ChangeThemeAsync()
    {
        if (!_isDarkCurrentTheme)
        {
            _currentTheme = _darkTheme;
        }
        else
        {
            _currentTheme = _lightTheme;
        }


        _isDarkCurrentTheme = !_isDarkCurrentTheme;
        await LocalStorage.SetItemAsync("theme", _isDarkCurrentTheme);
    }

    #region Private fields
    private MudTheme _currentTheme;
    private MudTheme _darkTheme = new()
    {
        Palette = new()
        {
            AppbarBackground = "#0097FF",
            AppbarText = "#FFFFFF",
            Primary = "#007CD1",
            TextPrimary = "#FFFFFF",
            Background = "#001524",
            TextSecondary = "#E2EEF6",
            DrawerBackground = "#093958",
            DrawerText = "#FFFFFF",
            Surface = "#093958",
            ActionDefault = "#0C1217",
            ActionDisabled = "#2F678C",
            TextDisabled = "#B0B0B0"
        }
    };
    private MudTheme _lightTheme = new MudTheme
    {
        Palette = new Palette
        {
            AppbarBackground = "#0097FF",
            AppbarText = "#FFFFFF",
            Primary = "#007CD1",
            TextPrimary = "#0C1217",
            Background = "#F4FDFF",
            TextSecondary = "#0C1217",
            DrawerBackground = "#C5E5FF",
            DrawerText = "#0C1217",
            Surface = "#E4FAFF",
            ActionDefault = "#0C1217",
            ActionDisabled = "#2F678C",
            TextDisabled = "#676767",
        }
    };
    private bool _isDarkCurrentTheme = true;
    private bool _drawerOpen = true;
    #endregion
}

