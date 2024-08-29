using CustomResume.Library.Domain;
using MudBlazor;

namespace CustomResumeBlazor.Domain.Mappers;

public static class IconMapper
{
    public static string GetIcon(Icon icon) => icon switch
    {
        Icon.AccountCircle => Icons.Material.Filled.AccountCircle,
        Icon.Lightbulb => Icons.Material.Filled.Lightbulb,
        Icon.Construction => Icons.Material.Filled.Construction,
        Icon.AutoGraph => Icons.Material.Filled.AutoGraph,
        Icon.InsertDriveFile => Icons.Material.Filled.InsertDriveFile,
        _ => Icons.Material.Filled.DeviceUnknown
    };
}
