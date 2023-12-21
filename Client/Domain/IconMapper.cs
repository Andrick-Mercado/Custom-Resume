using MudBlazor;

namespace CustomResumeBlazor.Domain;

public static class IconMapper
{
    public static string GetIcon(string name) => name switch
    {
        "AccountCircle" => Icons.Material.Filled.AccountCircle,
        "Lightbulb" => Icons.Material.Filled.Lightbulb,
        "Construction" => Icons.Material.Filled.Construction,
        "AutoGraph" => Icons.Material.Filled.AutoGraph,
        "InsertDriveFile" => Icons.Material.Filled.InsertDriveFile,
        _ => Icons.Material.Filled.DeviceUnknown
    };
}
