namespace DataLogic.Entities
{
    public class Phone
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;

        public ICollection<Handler> Handlers { get; set; } = new List<Handler>();
    }
}
