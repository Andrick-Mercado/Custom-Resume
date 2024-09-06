using System.Net.Http.Json;
using System.Text.Json;
using CustomResume.Library.Domain;
using CustomResume.Library.Infrastructure.Extensions;
using CustomResumeBlazor.Domain;

namespace CustomResume.Library.Infrastructure;

public interface IDatabaseService
{
    Task<WebsiteDatabaseData> GetWebsiteDatabaseDataAsync();
}

public class DatabaseService : IDatabaseService
{
    private readonly HttpClient _httpClient;

    public DatabaseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WebsiteDatabaseData> GetWebsiteDatabaseDataAsync()
    {
        return await _httpClient.GetFromJsonAsync<WebsiteDatabaseData>("database/websiteData.json")
               ?? throw new InvalidOperationException();
    }

    
}

public class MockedDatabaseService : IDatabaseService
{
    public async Task<WebsiteDatabaseData> GetWebsiteDatabaseDataAsync()
    {
        var websiteDatabaseData = GetWebsiteDataAsString();

        var websiteDatabaseDataJson = websiteDatabaseData.DeserializeWithCamelCase<WebsiteDatabaseData>();

        return websiteDatabaseDataJson;
    }

    private string GetWebsiteDataAsString()
    {
        return "{\r\n  \"configurations\": {\r\n    \"websiteTheme\": \"Green\",\r\n    \"enableDarkMode\": false\r\n  },\r\n  \"personalInformation\": {\r\n    \"person\": {\r\n      \"firstName\": \"Andrick\",\r\n      \"lastName\": \"Mercado\",\r\n      \"fullName\": \"Andrick Mercado\"\r\n    },\r\n    \"socialMediaLinks\": {\r\n      \"linkedIn\": \"andrick-mercado\",\r\n      \"mail\": \"andrickmercado17@gmail.com\",\r\n      \"twitter\": \"elonmusk\",\r\n      \"github\": \"andrick-mercado\"\r\n    }\r\n  },\r\n  \"websiteData\": {\r\n    \"mainPage\": {\r\n      \"name\": \"My Portfolio\",\r\n      \"title\": \"About Me\",\r\n      \"imageRoute\": \"images/headshot1.jpg\",\r\n      \"icon\": \"AccountCircle\",\r\n      \"paragraphs\": [\r\n        \"I'm Michael Anthony Moreno, a California native who hails from the beautiful city of San Diego. I've always been passionate about finance and economics, which led me to pursue my education at UC Berkeley, where I studied Political Economy. This experience allowed me to delve deep into the world of economics, understanding the intricate connections between policy, finance, and global markets.\",\r\n        \"My education has equipped me with a strong foundation in financial analysis, market trends, and economic theory. I'm not only dedicated to learning but also to applying my knowledge in practical settings. I'm highly motivated and always open to exploring new opportunities, whether in the field of finance or any other sector where I can leverage my skills and make a meaningful impact.\",\r\n        \"I believe that the world of finance and business is dynamic, and I'm excited to be a part of this ever-evolving landscape. I'm constantly seeking new challenges and ways to contribute to the growth and success of the organizations and projects I engage with.\",\r\n        \"If you have an exciting opportunity or project in mind, don't hesitate to reach out. I'm ready to connect, collaborate, and explore new horizons.\"\r\n      ]\r\n    },\r\n    \"otherPages\": [\r\n      {\r\n        \"sortOrder\": 0,\r\n        \"title\": \"Experience\",\r\n        \"endpoint\": \"experience\",\r\n        \"pageFormat\": \"Experience\",\r\n        \"icon\": \"Lightbulb\",\r\n        \"cards\": [\r\n          {\r\n            \"name\": \"A\",\r\n            \"title\": \"B\",\r\n            \"body\": \"C\",\r\n            \"icon\": \"Lightbulb\",\r\n            \"imageUrl\": \"\",\r\n            \"embedUrl\": \"\",\r\n            \"LearnMoreUrl\": \"https://www.google.com\"\r\n          }\r\n        ]\r\n      },\r\n      {\r\n        \"sortOrder\": 1,\r\n        \"title\": \"Activities\",\r\n        \"endpoint\": \"activities\",\r\n        \"pageFormat\": \"Education\",\r\n        \"icon\": \"Construction\",\r\n        \"cards\": [\r\n          {\r\n            \"name\": \"E\",\r\n            \"title\": \"F\",\r\n            \"body\": \"G\",\r\n            \"icon\": \"Lightbulb\",\r\n            \"imageUrl\": \"\",\r\n            \"embedUrl\": \"\",\r\n            \"LearnMoreUrl\": \"https://www.google.com\"\r\n          }\r\n        ]\r\n      },\r\n      {\r\n        \"sortOrder\": 2,\r\n        \"title\": \"Skills\",\r\n        \"endpoint\": \"skills\",\r\n        \"pageFormat\": \"Skill\",\r\n        \"icon\": \"AutoGraph\",\r\n        \"cards\": [\r\n          {\r\n            \"name\": \"Programming\",\r\n            \"title\": \"Python\",\r\n            \"body\": \"I have been using C# for 3 years now, and I have used it to create a variety of applications, including web applications, desktop applications, and games.\",\r\n            \"icon\": \"Lightbulb\",\r\n            \"imageUrl\": \"\",\r\n            \"embedUrl\": \"\",\r\n            \"LearnMoreUrl\": \"\"\r\n          },\r\n          {\r\n            \"name\": \"Programming\",\r\n            \"title\": \"C#\",\r\n            \"body\": \"I have been using C# for 3 years now, and I have used it to create a variety of applications, including web applications, desktop applications, and games.\",\r\n            \"icon\": \"Lightbulb\",\r\n            \"imageUrl\": \"\",\r\n            \"embedUrl\": \"\",\r\n            \"LearnMoreUrl\": \"\"\r\n          },\r\n          {\r\n            \"name\": \"Programming\",\r\n            \"title\": \"Java\",\r\n            \"body\": \"I have been using C# for 3 years now, and I have used it to create a variety of applications, including web applications, desktop applications, and games.\",\r\n            \"icon\": \"Lightbulb\",\r\n            \"imageUrl\": \"\",\r\n            \"embedUrl\": \"\",\r\n            \"LearnMoreUrl\": \"\"\r\n          },\r\n          {\r\n            \"name\": \"Programming\",\r\n            \"title\": \"JavaScript\",\r\n            \"body\": \"I have been using C# for 3 years now, and I have used it to create a variety of applications, including web applications, desktop applications, and games.\",\r\n            \"icon\": \"Lightbulb\",\r\n            \"imageUrl\": \"\",\r\n            \"embedUrl\": \"\",\r\n            \"LearnMoreUrl\": \"\"\r\n          },\r\n          {\r\n            \"name\": \"Programming\",\r\n            \"title\": \"HTML\",\r\n            \"body\": \"I have been using C# for 3 years now, and I have used it to create a variety of applications, including web applications, desktop applications, and games.\",\r\n            \"icon\": \"Lightbulb\",\r\n            \"imageUrl\": \"\",\r\n            \"embedUrl\": \"\",\r\n            \"LearnMoreUrl\": \"\"\r\n          },\r\n          {\r\n            \"name\": \"Programming\",\r\n            \"title\": \"CSS\",\r\n            \"body\": \"I have been using C# for 3 years now, and I have used it to create a variety of applications, including web applications, desktop applications, and games.\",\r\n            \"icon\": \"Lightbulb\",\r\n            \"imageUrl\": \"\",\r\n            \"embedUrl\": \"\",\r\n            \"LearnMoreUrl\": \"\"\r\n          },\r\n          {\r\n            \"name\": \"Programming\",\r\n            \"title\": \"SQL\",\r\n            \"body\": \"I have been using C# for 3 years now, and I have used it to create a variety of applications, including web applications, desktop applications, and games.\",\r\n            \"icon\": \"Lightbulb\",\r\n            \"imageUrl\": \"\",\r\n            \"embedUrl\": \"\",\r\n            \"LearnMoreUrl\": \"\"\r\n          },\r\n          {\r\n            \"name\": \"Languages\",\r\n            \"title\": \"English\",\r\n            \"body\": \"Native\",\r\n            \"icon\": \"Lightbulb\",\r\n            \"imageUrl\": \"\",\r\n            \"embedUrl\": \"\",\r\n            \"LearnMoreUrl\": \"\"\r\n          },\r\n          {\r\n            \"name\": \"Languages\",\r\n            \"title\": \"Spanish\",\r\n            \"body\": \"Native\",\r\n            \"icon\": \"Lightbulb\",\r\n            \"imageUrl\": \"\",\r\n            \"embedUrl\": \"\",\r\n            \"LearnMoreUrl\": \"\"\r\n          }\r\n        ]\r\n      },\r\n      {\r\n        \"sortOrder\": 3,\r\n        \"title\": \"Resume\",\r\n        \"endpoint\": \"https://docs.google.com/document/d/1NzIuVymJB1AxnmTCS_Wprf9u6-O_Qa-7vnFpc8n5guA/edit?usp=sharing\",\r\n        \"pageFormat\": \"ExternalLink\",\r\n        \"icon\": \"InsertDriveFile\",\r\n        \"cards\": [\r\n          {\r\n            \"name\": \"123\",\r\n            \"title\": \"456\",\r\n            \"body\": \"1\",\r\n            \"icon\": \"Lightbulb\",\r\n            \"imageUrl\": \"\",\r\n            \"embedUrl\": \"https://docs.google.com/document/d/1NzIuVymJB1AxnmTCS_Wprf9u6-O_Qa-7vnFpc8n5guA/edit?usp=sharing\"\r\n          }\r\n        ]\r\n      }\r\n    ]\r\n  }\r\n}";
    }
}
