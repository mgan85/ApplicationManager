using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataLogic.Entities;

namespace DataLogic.Configurations;

public class JobOfferRequiredSkillConfiguration : IEntityTypeConfiguration<JobOfferRequiredSkill>
{
    public void Configure(EntityTypeBuilder<JobOfferRequiredSkill> builder)
    {
        builder.HasKey(jrs => new { jrs.JobOfferId, jrs.SkillId });

        builder.HasOne(jrs => jrs.JobOffer)
            .WithMany(j => j.RequiredSkills)
            .HasForeignKey(jrs => jrs.JobOfferId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(jrs => jrs.Skill)
            .WithMany(s => s.JobOfferRequiredSkills)
            .HasForeignKey(jrs => jrs.SkillId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
