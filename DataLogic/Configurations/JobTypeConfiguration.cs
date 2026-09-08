using DataLogic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLogic.Configurations;

public class JobTypeConfiguration : IEntityTypeConfiguration<JobType>
{
    public void Configure(EntityTypeBuilder<JobType> builder)
    {
        builder.HasKey(jt => jt.Id);

        builder.Property(jt => jt.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}