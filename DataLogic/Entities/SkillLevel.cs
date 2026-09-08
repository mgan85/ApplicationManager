namespace DataLogic.Entities
{
    public class SkillLevel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
    }
}
