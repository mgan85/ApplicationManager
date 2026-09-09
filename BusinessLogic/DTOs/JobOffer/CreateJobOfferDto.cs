namespace BusinessLogic.DTOs.JobOffer;

public class CreateJobOfferDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public decimal? Salary { get; set; }
    public string? Platform { get; set; }
    public int? JobTypeId { get; set; }

    public List<int> RequiredSkillIds { get; set; } = new();
}
