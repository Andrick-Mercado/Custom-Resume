namespace CustomResumeBlazor.Domain;

public class DTOs { }

public class ExperienceTemplate
{
    public string? JobTitle { get; set; }
    public string? JobDescription { get; set; }
    public string? MoreInfo { get; set; }
    public string? ImageRoute { get; set; }
}

public class ProjectTemplate
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? MoreInfo { get; set; }
    public string? ImageRoute { get; set; }
}

public class SkillTemplate
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
}

public class AboutMeDTO
{
    public List<string> Paragraphs { get; set; } = new();
}

