using CustomResumeBlazor.Domain;

namespace CustomResumeBlazor.Pages;

public partial class Index
{
    private bool hasLoaded = false;

    protected override void OnInitialized()
    {
        hasLoaded = true;
        StateHasChanged();
    }

    private readonly AboutMeDTO AboutMe = new()
    {
        Paragraphs = new List<string>
        {
            "I'm Michael Anthony Moreno, a California native who hails from the beautiful city of San Diego. I've always been passionate about finance and economics, which led me to pursue my education at UC Berkeley, where I studied Political Economy. This experience allowed me to delve deep into the world of economics, understanding the intricate connections between policy, finance, and global markets.",
            "My education has equipped me with a strong foundation in financial analysis, market trends, and economic theory. I'm not only dedicated to learning but also to applying my knowledge in practical settings. I'm highly motivated and always open to exploring new opportunities, whether in the field of finance or any other sector where I can leverage my skills and make a meaningful impact.",
            "I believe that the world of finance and business is dynamic, and I'm excited to be a part of this ever-evolving landscape. I'm constantly seeking new challenges and ways to contribute to the growth and success of the organizations and projects I engage with.",
            "If you have an exciting opportunity or project in mind, don't hesitate to reach out. I'm ready to connect, collaborate, and explore new horizons."
        }
    };
}

