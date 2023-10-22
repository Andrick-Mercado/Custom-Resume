namespace CustomResumeBlazor.Domain.Mappers;

public static class RouteMapper
{
    public static string GetAllCardsRoute(string endpoint) => $"defaultviewer/{endpoint}";
}

