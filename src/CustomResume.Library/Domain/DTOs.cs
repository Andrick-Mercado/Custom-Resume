using System.Text.Json.Serialization;

namespace CustomResumeBlazor.Domain;

public class DTOs { }

public class WebsiteDatabaseData
{
    public Configurations Configurations { get; set; }
    public PersonalInformation PersonalInformation { get; set; }
    public WebsiteData WebsiteData { get; set; }
}
public class Configurations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public WebsiteTheme WebsiteTheme { get; set; }
    public bool EnableDarkMode { get; set; }
}

public class PersonalInformation
{
    public Person Person { get; set; }
    public SocialMediaLinks SocialMediaLinks { get; set; }
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
}

public class SocialMediaLinks
{
    public string LinkedIn { get; set; }
    public string Mail { get; set; }
    public string Twitter { get; set; }
    public string Github { get; set; }
}

public class WebsiteData
{
    public MainPage MainPage { get; set; }
    public List<OtherPages> OtherPages { get; set; }
}

public class MainPage
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string ImageRoute { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Icon Icon { get; set; }
    public List<string> Paragraphs { get; set; }
}

public class OtherPages
{
    public int SortOrder { get; set; }
    public string Title { get; set; }
    public string Endpoint { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CardType PageFormat { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Icon Icon { get; set; }
    public List<Card> Cards { get; set; }
}

public class Card
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Icon Icon { get; set; }
    public string ImageUrl { get; set; }
    public string EmbedUrl { get; set; }
    public string LearnMoreUrl { get; set; }
}


#region Enums

public enum WebsiteTheme
{
    Blue,
    Green
}

public enum CardType
{
    Skill,
    Experience,
    Education,
    Project,
    ExternalLink
}

public enum Icon
{
    AccountCircle,
    Lightbulb,
    Construction,
    AutoGraph,
    InsertDriveFile
}

#endregion

