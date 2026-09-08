namespace DataLogic.Entities
{
    public class Handler
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int PhoneId { get; set; }
        public string Email { get; set; } = string.Empty;

        public Phone Phone { get; set; } = null!;
        public ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
