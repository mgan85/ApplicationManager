using DataLogic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLogic.Configurations;

public class HandlerConfiguration : IEntityTypeConfiguration<Handler>
{
    public void Configure(EntityTypeBuilder<Handler> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(h => h.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(h => h.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(h => h.Phone)
            .WithMany(p => p.Handlers)
            .HasForeignKey(h => h.PhoneId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}