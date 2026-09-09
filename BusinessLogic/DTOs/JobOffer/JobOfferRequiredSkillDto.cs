namespace BusinessLogic.DTOs.JobOffer;

public class JobOfferRequiredSkillDto
{
    public int SkillId { get; set; }
    public string SkillName { get; set; } = string.Empty;

    public int SkillLevelId { get; set; }
    public string SkillLevelName { get; set; } = string.Empty;
}
