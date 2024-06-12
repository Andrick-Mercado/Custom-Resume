namespace CustomResumeBlazor.Domain.Mappers;

public static class UriMapper
{
    public static string GetLinkedInUri(string username) => $"https://www.linkedin.com/in/{username}/";

    public static string GetMailUri(string username) => $"mailto:{username}";

    public static string GetTwitterUri(string username) => $"https://twitter.com/{username}";

    public static string GetGitHubUri(string username) => $"https://github.com/{username}";

    public static string GetExternalLinked(string url) => url;
}
