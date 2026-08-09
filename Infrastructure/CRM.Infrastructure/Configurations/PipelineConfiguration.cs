using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Configurations
{
    public class PipelineConfiguration : IEntityTypeConfiguration<Pipeline>
    {
        public void Configure(EntityTypeBuilder<Pipeline> builder)
        {
            builder.ToTable("Pipelines");

            builder.HasIndex(p => p.Id);

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            builder.HasMany(p => p.Stages)
                .WithOne(s => s.Pipeline)
                .HasForeignKey(s => s.PipelineId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Deals)
                .WithOne(d => d.Pipeline)
                .HasForeignKey(d => d.PipelineId)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);


        }
    }
}
