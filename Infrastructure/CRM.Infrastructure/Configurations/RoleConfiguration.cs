using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(x => x.Id);

            builder.HasData([
                new Role {
                    Id = Guid.Parse("0694ec4c-8e49-4a0e-b93f-79d41fe88bfa"),
                    Name = "Super Admin"
                },
                new Role {
                    Id = Guid.Parse("21f2f8f1-84e2-44d6-847b-b81ebabc2b8b"),
                    Name = "Admin"
                },
                new Role {
                    Id = Guid.Parse("c443f0b1-08dd-4ed7-b72d-4f0255557acd"),
                    Name = "User"
                }
                ]);
        }
    }
}
