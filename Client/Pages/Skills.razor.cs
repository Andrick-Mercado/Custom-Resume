using CustomResumeBlazor.Domain;
using MudBlazor;

namespace CustomResumeBlazor.Pages;

public partial class Skills
{

    private List<SkillTemplate> SkillsProgramming = new()
    {
        new ()
        {
            Name = "Python",
            Description = "I have been using C# for 3 years now, and I have used it to create a variety of applications, including web applications, desktop applications, and games.",
            Icon = Icons.Material.Filled.Code
        },
        new ()
        {
            Name = "R",
            Description = "I have been using HTML for 3 years now, and I have used it to create a variety of applications, including web applications, desktop applications, and games.",
            Icon = Icons.Material.Filled.Code
        }
    };

    private List<SkillTemplate> SkillsTechnologies = new()
    {
        new ()
        {
            Name = "Windows",
            Description = "",
            Icon = Icons.Custom.Brands.MicrosoftWindows
        },
        new SkillTemplate()
        {
            Name = "Microsoft Excel",
            Description = "",
            Icon = Icons.Custom.FileFormats.FileExcel
        }
    };

    private List<SkillTemplate> SkillsLanguages = new()
    {
        new ()
        {
            Name = "English",
            Description = "",
            Icon = Icons.Material.Filled.Language
        },
        new ()
        {
            Name = "Spanish",
            Description = "",
            Icon = Icons.Material.Filled.Language
        }
    };
}


