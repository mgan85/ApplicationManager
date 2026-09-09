using BusinessLogic.DTOs.Skill;

namespace BusinessLogic.DTOs.JobOffer;

public class JobOfferDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public decimal? Salary { get; set; }
    public string? Platform { get; set; }
    public string? JobTypeName { get; set; }

    public List<SkillDto> RequiredSkills { get; set; } = new();
}