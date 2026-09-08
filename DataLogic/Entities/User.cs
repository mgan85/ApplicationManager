namespace DataLogic.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int? AddressId { get; set; }

        public Address? Address { get; set; }
        public ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
        public ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
