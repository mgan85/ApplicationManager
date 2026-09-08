using DataLogic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLogic.Configurations;

public class JobOfferConfiguration : IEntityTypeConfiguration<JobOffer>
{
    public void Configure(EntityTypeBuilder<JobOffer> builder)
    {
        builder.HasKey(j => j.Id);

        builder.Property(j => j.Salary)
            .HasPrecision(18, 2);

        builder.Property(j => j.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(j => j.CompanyName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(j => j.Platform)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(j => j.JobType)
            .WithMany(jt => jt.JobOffers)
            .HasForeignKey(j => j.JobTypeId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}