namespace CustomResume.Library.Infrastructure;

public enum AppInfoRouterType
{
    Maui,
    Blazor
}

public class AppInfoRouter
{
    public bool IsThisMauiApp { get; }
    public bool IsThisBlazorApp { get; }

    public AppInfoRouter(AppInfoRouterType appInfoRouterType)
    {
        IsThisMauiApp = appInfoRouterType is AppInfoRouterType.Maui;
        IsThisBlazorApp = appInfoRouterType is AppInfoRouterType.Blazor;
    }
}