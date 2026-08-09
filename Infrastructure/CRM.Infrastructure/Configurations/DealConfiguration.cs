using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Configurations
{
    public class DealConfiguration : IEntityTypeConfiguration<Deal>
    {
        public void Configure(EntityTypeBuilder<Deal> builder)
        {
            builder.ToTable("Deals");

            builder.HasIndex(d => d.Id);

            builder.Property(d => d.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(255)")
                .IsRequired();
                
            builder.HasKey(d => d.Id);

            builder.HasIndex(x => new { x.PipelineId, x.StageId });

            builder.HasOne(d => d.Pipeline)
                .WithMany(p => p.Deals)
                .HasForeignKey(d => d.PipelineId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Stage)
                .WithMany(s => s.Deals)
                .HasForeignKey(d => d.StageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(d => d.Value).HasColumnName("Value").HasColumnType("money");


        }
    }
}
