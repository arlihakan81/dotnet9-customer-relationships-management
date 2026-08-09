using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Configurations
{
    public class IndustryConfiguration : IEntityTypeConfiguration<Industry>
    {
        public void Configure(EntityTypeBuilder<Industry> builder)
        {
            builder.ToTable("Industries");

            builder.Property(i => i.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("nvarchar(255)");

            builder.HasMany(i => i.Companies)
                .WithOne(c => c.Industry)
                .HasForeignKey(c => c.IndustryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(i => i.Leads)
                .WithOne(l => l.Industry)
                .HasForeignKey(l => l.IndustryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData([
                new Industry {
                    Id = Guid.Parse("97a92ec2-44cb-4c51-bde8-30e59c80f136"),
                    Name = "Perakende E-Ticaret",
                    Status = true
                },
                new Industry {
                    Id = Guid.Parse("4e2fe32d-d574-46d2-89b9-6dc4b5aba976"),
                    Name = "Gayrimenkul",
                    Status = true
                },
                new Industry {
                    Id = Guid.Parse("04333d8d-f676-41d9-b4e7-b9ded1eee930"),
                    Name = "Üretim",
                    Status = true
                },
                new Industry {
                    Id = Guid.Parse("2363cc8c-4f2b-4104-a375-6f5f66235e33"),
                    Name = "Sağlık",
                    Status = true
                },
                new Industry {
                    Id = Guid.Parse("77b7e8e7-a371-49d6-8db1-895baaaa991e"),
                    Name = "Turizm",
                    Status = true
                }
                ]);

        }
    }
}
