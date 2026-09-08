namespace DataLogic.Entities
{
    public class ApplicationStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
