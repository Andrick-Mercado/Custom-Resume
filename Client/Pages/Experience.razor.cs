using CustomResumeBlazor.Domain;

namespace CustomResumeBlazor.Pages;

public partial class Experience
{
    private List<ExperienceTemplate> ExperienceTemplates { get; set; } = new()
    {
        new ()
        {
            JobTitle = "Library Security - UC Berkeley",
            JobDescription = "Implemented and maintained security protocols to safeguard library resources.",
            MoreInfo = "Monitored and responded to security incidents promptly and effectively."
        },
        new ()
        {
            JobTitle = "Cook (catering) - Oakland Kitchen",
            JobDescription = "Demonstrated quick learning by acquiring cooking proficiency within weeks, adapted to fast-paced kitchenenvironments, and efficiently handled diverse cooking tasks.",
            MoreInfo = "Assisted in meal preparation while maintaining a clean and organized kitchen space, optimizing workflow."
        }
    };
}
