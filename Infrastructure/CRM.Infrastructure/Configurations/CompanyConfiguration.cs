using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasOne(c => c.CreatedBy).WithMany().HasForeignKey(c => c.CreatedById).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.ModifiedBy).WithMany().HasForeignKey(c => c.ModifiedById).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.DeletedBy).WithMany().HasForeignKey(c => c.DeletedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
