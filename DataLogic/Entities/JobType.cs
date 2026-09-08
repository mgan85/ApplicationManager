namespace DataLogic.Entities
{
    public class JobType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<JobOffer> JobOffers { get; set; } = new List<JobOffer>();
    }
}
