namespace DataLogic.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public bool IsApplied => ApplyDate != null;
        public DateTime? ApplyDate { get; set; }
        public int StatusId { get; set; }
        public int? JobOfferId { get; set; }
        public int? UserId { get; set; }
        public int? HandlerId { get; set; }

        public ApplicationStatus Status { get; set; } = null!;
        public JobOffer? JobOffer { get; set; }
        public User? User { get; set; }
        public Handler? Handler { get; set; }
    }
}
