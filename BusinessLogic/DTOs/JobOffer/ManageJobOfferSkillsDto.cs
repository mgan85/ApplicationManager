namespace BusinessLogic.DTOs.JobOffer;

public class ManageJobOfferSkillsDto
{
    public int JobOfferId { get; set; }

    public List<int> SkillIds { get; set; } = new();
}