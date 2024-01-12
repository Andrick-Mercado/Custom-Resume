using CustomResumeBlazor.Domain;

namespace CustomResumeBlazor.Pages;

public partial class Activities
{
    private List<ProjectTemplate> ProjectTemplates { get; set; } = new()
    {
        new ()
        {
            Title = "Latino Business Association",
            Description = "Networked with business professionals to advance members while holding the association’s values",
            MoreInfo = "Implemented business analytical skills"
        },
        new ()
        {
            Title = "UC Berkeley Political Economy Student Association",
            Description = "Explored a variety of opportunities in different fields, including finance, international trade, and technology, with respect to the economy",
            MoreInfo = ""
        },
        new ()
        {
            Title = "Nav-Cal",
            Description = "Compiled multiple resources offered within Berkeley to assist students in financial need",
            MoreInfo = "Worked with a committee to search for different funding sources"
        },
        new ()
        {
            Title = "HSF Scholar",
            Description = "I'm proud to say that I've successfully completed both the virtual and in-person components of the HSF 2023 Finance Conference event. It's been an amazing journey, and I'm truly honored to have been selected as one of the 120 HSF Scholars to attend.",
            MoreInfo = "",
            ImageRoute = "images/hsf01.jpg"
        }
    };


}
