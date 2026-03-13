using JobsMarketPlaceAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace JobsMarketPlaceAPI.Data
{
    public class MarketplaceDbContext : DbContext
    {
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Contractor> Contractors => Set<Contractor>();
        public DbSet<Job> Jobs => Set<Job>();
        public DbSet<JobOffer> JobOffers => Set<JobOffer>();

        public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasIndex(x => x.LastName);

            modelBuilder.Entity<Contractor>()
                .HasIndex(x => x.Name);

            modelBuilder.Entity<Job>()
                .HasIndex(x => x.CustomerId);
        }
    }

}
