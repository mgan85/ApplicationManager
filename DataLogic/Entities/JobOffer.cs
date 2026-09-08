namespace DataLogic.Entities
{
    public class JobOffer
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public decimal? Salary { get; set; }
        public string? Platform { get; set; }
        public int? JobTypeId { get; set; }

        public JobType? JobType { get; set; }
        public ICollection<JobOfferRequiredSkill> RequiredSkills { get; set; } = new List<JobOfferRequiredSkill>();
        public ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
