using Blazored.LocalStorage;

namespace CustomResumeBlazor.Infrastructure;

public interface IProfileService
{
    Task<bool> ToggleDarkMode();
    Task<Preferences> GetPreferences();
}

public class ProfileService : IProfileService
{
    private readonly ILocalStorageService _localStorageService;

    private const string PreferencesKey = nameof(Preferences);

    public ProfileService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public async Task<bool> ToggleDarkMode()
    {
        var preferences = await GetPreferences();
        var newPreferences = preferences with
        {
            DarkMode = !preferences.DarkMode
        };

        await _localStorageService.SetItemAsync(PreferencesKey, newPreferences);

        return newPreferences.DarkMode;
    }

    public async Task<Preferences> GetPreferences()
    {
        return await _localStorageService.GetItemAsync<Preferences>(PreferencesKey) ?? new Preferences();
    }
}

public record Preferences
{
    public bool DarkMode { get; init; } = false;
}