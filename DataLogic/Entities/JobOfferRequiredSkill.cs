namespace DataLogic.Entities
{
    public class JobOfferRequiredSkill
    {
        public int JobOfferId { get; set; }
        public int SkillId { get; set; }

        public JobOffer JobOffer { get; set; } = null!;
        public Skill Skill { get; set; } = null!;
    }
}
