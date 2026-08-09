using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Configurations
{
    public class StageConfiguration : IEntityTypeConfiguration<Stage>
    {
        public void Configure(EntityTypeBuilder<Stage> builder)
        {
            builder.ToTable("Stages");
            builder.HasIndex(s => s.Id);

            builder.Property(s => s.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(100)")
                .IsRequired();

        }
    }
}
