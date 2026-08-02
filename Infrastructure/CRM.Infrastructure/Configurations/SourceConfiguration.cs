using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Configurations
{
    public class SourceConfiguration : IEntityTypeConfiguration<Source>
    {
        public void Configure(EntityTypeBuilder<Source> builder)
        {
            builder.ToTable("Sources");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(s => s.Description)
                .HasMaxLength(500);
            builder.Property(s => s.Status)
                .IsRequired();
            // Configure the relationship with Company
            builder.HasMany(s => s.Companies)
                .WithOne(c => c.Source)
                .HasForeignKey(c => c.SourceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
