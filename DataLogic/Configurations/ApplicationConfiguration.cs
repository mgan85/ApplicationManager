using DataLogic.Entities;
using DataLogic.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLogic.Configurations;

public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Ignore(a => a.IsApplied);

        builder.Property(a => a.StatusId)
               .HasConversion<int>()
               .HasDefaultValue(ApplicationStatusEnum.Draft);

        builder.HasOne(a => a.Status)
            .WithMany(s => s.Applications)
            .HasForeignKey(a => a.StatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.JobOffer)
            .WithMany(j => j.Applications)
            .HasForeignKey(a => a.JobOfferId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(a => a.User)
            .WithMany(u => u.Applications)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(a => a.Handler)
            .WithMany(h => h.Applications)
            .HasForeignKey(a => a.HandlerId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}