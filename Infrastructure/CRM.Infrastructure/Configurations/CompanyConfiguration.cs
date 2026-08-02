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
            builder.HasOne(c => c.Owner).WithMany(c => c.Companies).HasForeignKey(c => c.OwnerId).OnDelete(DeleteBehavior.Restrict);
            builder.OwnsOne(c => c.Phone, phone =>
            {
                phone.Property(p => p.Value).HasColumnName("Phone").IsRequired();
            });

            builder.OwnsOne(c => c.AlternatePhone, phone =>
            {
                phone.Property(p => p.Value).HasColumnName("AlternatePhone");
            });

            builder.OwnsOne(c => c.Fax, fax =>
            {
                fax.Property(p => p.Value).HasColumnName("Fax");
            });

            builder.OwnsOne(c => c.Email, email =>
            {
                email.Property(e => e.Value).HasColumnName("Email").IsRequired();
            });

        }
    }
}
