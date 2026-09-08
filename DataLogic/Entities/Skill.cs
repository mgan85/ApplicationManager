namespace DataLogic.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int LevelId { get; set; }

        public SkillLevel Level { get; set; } = null!;
        public ICollection<JobOfferRequiredSkill> JobOfferRequiredSkills { get; set; } = new List<JobOfferRequiredSkill>();
        public ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
    }
}
