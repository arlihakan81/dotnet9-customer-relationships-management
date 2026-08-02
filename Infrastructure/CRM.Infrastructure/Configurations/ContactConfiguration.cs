using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(c => c.Id);

            builder.OwnsOne(c => c.Email, email =>
            {
                email.Property(e => e.Value)
                    .HasColumnName("Email")
                    .IsRequired()
                    .HasMaxLength(20);
            });

            builder.OwnsOne(c => c.Mobile, mobile =>
            {
                mobile.Property(e => e.Value)
                    .HasColumnName("Mobile")
                    .IsRequired()
                    .HasMaxLength(20);
            });

            builder.OwnsOne(c => c.Phone, phone =>
            {
                phone.Property(e => e.Value)
                    .HasColumnName("Phone")
                    .HasMaxLength(20);
            });

            builder.HasOne(c => c.CreatedBy)
                .WithMany()
                .HasForeignKey(c => c.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.ModifiedBy)
                .WithMany()
                .HasForeignKey(c => c.ModifiedById);

            builder.HasOne(c => c.DeletedBy)
                .WithMany()
                .HasForeignKey(c => c.DeletedById);

            builder.HasOne(c => c.Company)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.City)
                .WithMany()
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Country)
                .WithMany()
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
