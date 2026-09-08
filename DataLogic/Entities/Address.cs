namespace DataLogic.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Line1 { get; set; } = string.Empty;
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }
        public string City { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
