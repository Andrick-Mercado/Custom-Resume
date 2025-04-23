using CustomResume.Library.Domain;
using CustomResume.Library.Infrastructure;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CustomResume.Library.Application.Components;

public partial class MainLayoutPage
{
    protected override async Task OnInitializedAsync()
    {
        _preferences = await ProfileService.GetPreferences();
        _isDarkCurrentTheme = _preferences.DarkMode;

        _websiteDatabaseData = await WebsiteRepo.GetWebsiteData();
        _configurations = await WebsiteRepo.GetConfigurations();
        _personalInformation = await WebsiteRepo.GetPersonalInformation();
        _mainPage = _websiteDatabaseData.MainPage;

        _hasLoaded = true;
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

    private MudTheme _currentTheme => ThemeManager.GetMudTheme(_configurations?.WebsiteTheme ?? WebsiteTheme.Blue);
    private bool _hasLoaded;
    private WebsiteData _websiteDatabaseData;
    private PersonalInformation _personalInformation;
    private Configurations _configurations;
    private MainPage _mainPage;
    private Preferences _preferences = new();
    private bool _isDarkCurrentTheme = false;
    private bool _drawerOpen = true;

    #endregion

    #region Public fields

    public MudTheme CurrentTheme => _currentTheme;

    public bool IsDarkCurrentTheme => _isDarkCurrentTheme;

    #endregion

    #region Injected services

    [Inject] public IProfileService ProfileService { get; set; } = default!;
    [Inject] private IWebsiteRepo WebsiteRepo { get; set; } = default!;

    #endregion
}