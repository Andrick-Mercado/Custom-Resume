using CustomResume.Library.Domain;
using CustomResume.Library.Infrastructure.FileServices;

namespace CustomResume.Library.Infrastructure.Repo;

public class DesktopDatabaseService : IDatabaseService
{
    private readonly IDirectoryService<WebsiteDatabaseData> _directoryService;
    private const string _websiteDataFilePath = "websiteData.json";

    public DesktopDatabaseService(IDirectoryService<WebsiteDatabaseData> directoryService)
    {
        _directoryService = directoryService;
    }

    public async Task<WebsiteDatabaseData> GetWebsiteDatabaseDataAsync()
    {
        var websiteDatabaseData = await _directoryService.ReadFileAsync(_websiteDataFilePath);
        if (websiteDatabaseData.IsNotSuccessful)
            throw new InvalidOperationException();

        if (websiteDatabaseData.IsFound)
            return websiteDatabaseData.Data;

        var defaultWebsiteDatabaseData = GetWebsiteData();
        var writeResult = await _directoryService.WriteFileAsync(_websiteDataFilePath, defaultWebsiteDatabaseData);
        if (writeResult.IsNotSuccessful)
        {
            throw new InvalidOperationException();
        }

        return defaultWebsiteDatabaseData;
    }

    private static WebsiteDatabaseData GetWebsiteData() => new()
    {
        Configurations = new Configurations
        {
            WebsiteTheme = WebsiteTheme.Green,
            EnableDarkMode = false
        },
        PersonalInformation = new PersonalInformation
        {
            Person = new Person
            {
                FirstName = "Andrick",
                LastName = "Mercado",
                FullName = "Andrick Mercado"
            },
            SocialMediaLinks = new SocialMediaLinks
            {
                LinkedIn = "andrick-mercado",
                Mail = "andrickmercado17@gmail.com",
                Twitter = "elonmusk",
                Github = "andrick-mercado"
            }
        },
        WebsiteData = new WebsiteData
        {
            MainPage = new MainPage
            {
                Name = "My Portfolio",
                Title = "About Me",
                ImageRoute = "images/headshot1.jpg",
                Icon = Icon.AccountCircle,
                Paragraphs = new List<string>
                {
                    "I'm Michael Anthony Moreno, a California native who hails from the beautiful city of San Diego. I've always been passionate about finance and economics, which led me to pursue my education at UC Berkeley, where I studied Political Economy. This experience allowed me to delve deep into the world of economics, understanding the intricate connections between policy, finance, and global markets.",
                    "My education has equipped me with a strong foundation in financial analysis, market trends, and economic theory. I'm not only dedicated to learning but also to applying my knowledge in practical settings. I'm highly motivated and always open to exploring new opportunities, whether in the field of finance or any other sector where I can leverage my skills and make a meaningful impact.",
                    "I believe that the world of finance and business is dynamic, and I'm excited to be a part of this ever-evolving landscape. I'm constantly seeking new challenges and ways to contribute to the growth and success of the organizations and projects I engage with.",
                    "If you have an exciting opportunity or project in mind, don't hesitate to reach out. I'm ready to connect, collaborate, and explore new horizons."
                }
            },
            OtherPages = new List<OtherPages>
            {
                new OtherPages
                {
                    SortOrder = 0,
                    Title = "Experience",
                    Endpoint = "experience",
                    PageFormat = CardType.Experience,
                    Icon = Icon.Lightbulb,
                    Cards = new List<Card>
                    {
                        new Card
                        {
                            Name = "A",
                            Title = "B",
                            Body = "C",
                            Icon = Icon.Lightbulb,
                            ImageUrl = "",
                            EmbedUrl = "",
                            LearnMoreUrl = "https://www.google.com"
                        }
                    }
                },
                new OtherPages
                {
                    SortOrder = 1,
                    Title = "Activities",
                    Endpoint = "activities",
                    PageFormat = CardType.Education,
                    Icon = Icon.Construction,
                    Cards = new List<Card>
                    {
                        new Card
                        {
                            Name = "E",
                            Title = "F",
                            Body = "G",
                            Icon = Icon.Lightbulb,
                            ImageUrl = "",
                            EmbedUrl = "",
                            LearnMoreUrl = "https://www.google.com"
                        }
                    }
                },
                new OtherPages
                {
                    SortOrder = 2,
                    Title = "Skills",
                    Endpoint = "skills",
                    PageFormat = CardType.Skill,
                    Icon = Icon.AutoGraph,
                    Cards = new List<Card>
                    {
                        new Card
                        {
                            Name = "Programming",
                            Title = "Python",
                            Body =
                                "I have been using C# for 3 years now, and I have used it to create a variety of applications, including web applications, desktop applications, and games.",
                            Icon = Icon.Lightbulb,
                            ImageUrl = "",
                            EmbedUrl = "",
                            LearnMoreUrl = ""
                        },
                        new Card
                        {
                            Name = "Programming",
                            Title = "C#",
                            Body =
                                "I have been using C# for 3 years now, and I have used it to create a variety of applications, including web applications, desktop applications, and games.",
                            Icon = Icon.Lightbulb,
                            ImageUrl = "",
                            EmbedUrl = "",
                            LearnMoreUrl = ""
                        },
                        new Card
                        {
                            Name = "Programming",
                            Title = "Java",
                            Body =
                                "I have been using C# for 3 years now, and I have used it to create a variety of applications, including web applications, desktop applications, and games.",
                            Icon = Icon.Lightbulb,
                            ImageUrl = "",
                            EmbedUrl = "",
                            LearnMoreUrl = ""
                        },
                        new Card
                        {
                            Name = "Programming",
                            Title = "JavaScript",
                            Body =
                                "I have been using C# for 3 years now, and I have used it to create a variety of applications, including web applications, desktop applications, and games.",
                            Icon = Icon.Lightbulb,
                            ImageUrl = "",
                            EmbedUrl = "",
                            LearnMoreUrl = ""
                        },
                        new Card
                        {
                            Name = "Programming",
                            Title = "HTML",
                            Body =
                                "I have been using C# for 3 years now, and I have used it to create a variety of applications, including web applications, desktop applications, and games.",
                            Icon = Icon.Lightbulb,
                            ImageUrl = "",
                            EmbedUrl = "",
                            LearnMoreUrl = ""
                        },
                        new Card
                        {
                            Name = "Programming",
                            Title = "CSS",
                            Body =
                                "I have been using C# for 3 years now, and I have used it to create a variety of applications, including web applications, desktop applications, and games.",
                            Icon = Icon.Lightbulb,
                            ImageUrl = "",
                            EmbedUrl = "",
                            LearnMoreUrl = ""
                        },
                        new Card
                        {
                            Name = "Programming",
                            Title = "SQL",
                            Body =
                                "I have been using C# for 3 years now, and I have used it to create a variety of applications, including web applications, desktop applications, and games.",
                            Icon = Icon.Lightbulb,
                            ImageUrl = "",
                            EmbedUrl = "",
                            LearnMoreUrl = ""
                        },
                        new Card
                        {
                            Name = "Languages",
                            Title = "English",
                            Body = "Native",
                            Icon = Icon.Lightbulb,
                            ImageUrl = "",
                            EmbedUrl = "",
                            LearnMoreUrl = ""
                        },
                        new Card
                        {
                            Name = "Languages",
                            Title = "Spanish",
                            Body = "Native",
                            Icon = Icon.Lightbulb,
                            ImageUrl = "",
                            EmbedUrl = "",
                            LearnMoreUrl = ""
                        }
                    }
                },
                new OtherPages
                {
                    SortOrder = 3,
                    Title = "Resume",
                    Endpoint =
                        "https://docs.google.com/document/d/1NzIuVymJB1AxnmTCS_Wprf9u6-O_Qa-7vnFpc8n5guA/edit?usp=sharing",
                    PageFormat = CardType.ExternalLink,
                    Icon = Icon.InsertDriveFile,
                    Cards = new List<Card>
                    {
                        new Card
                        {
                            Name = "123",
                            Title = "456",
                            Body = "1",
                            Icon = Icon.Lightbulb,
                            ImageUrl = "",
                            EmbedUrl =
                                "https://docs.google.com/document/d/1NzIuVymJB1AxnmTCS_Wprf9u6-O_Qa-7vnFpc8n5guA/edit?usp=sharing"
                        }
                    }
                }
            }
        }
    };
}