using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using CRM.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Contexts
{
    public class AppDbContext(IOrganizationService organizationService = null!) : DbContext
    {
        private readonly IOrganizationService _organizationService = organizationService;

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=CRMDb; Trusted_Connection=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            modelBuilder.Entity<Company>().HasQueryFilter(c => c.OrganizationId == _organizationService.GetCurrentOrganizationId() && !c.IsDeleted);
            modelBuilder.Entity<Contact>().HasQueryFilter(c => c.OrganizationId == _organizationService.GetCurrentOrganizationId() && !c.IsDeleted);
            modelBuilder.Entity<Source>().HasQueryFilter(s => s.OrganizationId == _organizationService.GetCurrentOrganizationId() && !s.IsDeleted);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity<Guid>>().Where(x => x.State == EntityState.Added ||  x.State == EntityState.Modified || x.State == EntityState.Deleted);

            Guid currentUserId = _organizationService.GetLoggedInUserId();
            Guid organizationId = _organizationService.GetCurrentOrganizationId();

            foreach(var entry in entries)
            {
                if(_organizationService.IsAuthenticated())
                {
                    if(entry.State == EntityState.Added)
                    {
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.CreatedById = currentUserId;
                        entry.Entity.OrganizationId = organizationId;
                    }
                    if (entry.State == EntityState.Modified)
                    {
                        entry.Entity.ModifiedAt = DateTime.Now;
                        entry.Entity.ModifiedById = currentUserId;
                    }
                    if (entry.State == EntityState.Deleted)
                    {
                        entry.Entity.DeletedAt = DateTime.Now;
                        entry.Entity.DeletedById = currentUserId;
                    }
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }


    }
}
