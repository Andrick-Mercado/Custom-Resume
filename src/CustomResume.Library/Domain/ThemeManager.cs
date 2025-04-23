using MudBlazor;

namespace CustomResume.Library.Domain;

public static class ThemeManager
{
    public static MudTheme GetMudTheme(WebsiteTheme websiteTheme)
    {
        MudTheme theme = new MudTheme();

        switch (websiteTheme)
        {
            case WebsiteTheme.Blue:
                theme = new MudTheme
                {
                    PaletteLight = new PaletteLight
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
                break;

            case WebsiteTheme.Green:
                theme = new MudTheme
                {
                    //#00AA44
                    PaletteLight = new PaletteLight
                    {
                        AppbarBackground = "#00AA44",
                        AppbarText = "#FFFFFF",
                        Primary = "#00D100",
                        TextPrimary = "#0C1217",
                        Background = "#F5FFF5",
                        TextSecondary = "#0C1217",
                        DrawerBackground = "#C5FFD5",
                        DrawerIcon = "#000000",
                        DrawerText = "#0C1217",
                        Surface = "#E4FFE9",
                        ActionDefault = "#0C1217",
                        ActionDisabled = "#2F678C",
                        TextDisabled = "#676767",
                    },
                    PaletteDark = new PaletteDark
                    {
                        AppbarBackground = "#00AA44",
                        AppbarText = "#FFFFFF",
                        Primary = "#00D100",
                        Secondary = "#000000",
                        TextPrimary = "#FFFFFF",
                        Background = "#1C6800",
                        TextSecondary = "#E2EEF6",
                        DrawerBackground = "#2EA913",
                        DrawerIcon = "#FFFFFF",
                        DrawerText = "#FFFFFF",
                        Surface = "#0F8C00",
                        ActionDefault = "#0C1217",
                        ActionDisabled = "#2F678C",
                        TextDisabled = "#B0B0B0"
                    }
                };
                break;
        }

        return theme;
    }
}