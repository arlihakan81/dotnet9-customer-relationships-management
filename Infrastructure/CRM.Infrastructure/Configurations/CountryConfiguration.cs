using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Code).IsRequired().HasMaxLength(10);
            builder.Property(c => c.IsActive).IsRequired();

            builder.HasData([
                new Country { Id = Guid.Parse("45bfd61d-9433-4471-9465-bd1baa24b7ef"), Name = "Amerika Birleşik Devletleri", Code = "US", IsActive = true,
                    PhoneCode = "+1"
                },
                new Country { Id = Guid.Parse("132144df-5225-4408-826d-fcc378c0f74f"), Name = "Türkiye", Code = "TR", PhoneCode = "+90", IsActive = true,
                },
                new Country { Id = Guid.Parse("bfc27405-1111-42d8-8888-1292364f5c42"), Name = "Almanya", Code = "DE", PhoneCode = "+49", IsActive = true,
                },
                new Country { Id = Guid.Parse("72f3a930-add3-484a-af1a-9a9d61785ec4"), Name = "Fransa", Code = "FR", PhoneCode = "+33", IsActive = true,
                },
                new Country { Id = Guid.Parse("1b1da575-eabe-4d8c-8c29-daa4ab7f5432"), Name = "İngiltere", Code = "GB", PhoneCode = "+44", IsActive = true,
                }
            ]);



        }
    }
}
