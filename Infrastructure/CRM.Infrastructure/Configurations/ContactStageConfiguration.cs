using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Configurations
{
    public class ContactStageConfiguration : IEntityTypeConfiguration<ContactStage>
    {
        public void Configure(EntityTypeBuilder<ContactStage> builder)
        {
            builder.ToTable("ContactStages");

            builder.Property(cs => cs.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(cs => cs.Leads)
                .WithOne(l => l.ContactStage)
                .HasForeignKey(l => l.StageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
