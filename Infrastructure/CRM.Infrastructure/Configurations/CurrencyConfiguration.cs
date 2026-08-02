using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Currencies");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.Code)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(c => c.Symbol)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(c => c.Status)
                .IsRequired();
            builder.HasMany(c => c.Companies)
                .WithOne(c => c.Currency)
                .HasForeignKey(c => c.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData([
                new Currency
                {
                    Id = Guid.Parse("87f3e85d-c0b0-4b0b-961f-6211c88fb412"),
                    Name = "Amerikan Doları",
                    Code = "USD",
                    Symbol = "$"
                },
                new Currency {
                    Id = Guid.Parse("d1f3e85d-c0b0-4b0b-961f-6211c88fb413"),
                    Name = "Euro",
                    Code = "EUR",
                    Symbol = "€"
                },
                new Currency {
                    Id = Guid.Parse("e2f3e85d-c0b0-4b0b-961f-6211c88fb414"),
                    Name = "İngiliz Sterlini",
                    Code = "GBP",
                    Symbol = "£"
                },
                new Currency {
                    Id = Guid.Parse("f3f3e85d-c0b0-4b0b-961f-6211c88fb415"),
                    Name = "Türk Lirası",
                    Code = "TRY",
                    Symbol = "₺"
                }
            ]);
        }
    }
}
