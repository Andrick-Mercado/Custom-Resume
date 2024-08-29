namespace CustomResume.Library.Infrastructure;

public class AppInfoRouter
{ // TODO: Make this enums
    public bool IsThisMauiApp { get; }

    public AppInfoRouter(bool isThisMauiApp)
    {
        IsThisMauiApp = isThisMauiApp;
    }
}