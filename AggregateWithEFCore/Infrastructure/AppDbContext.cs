using AggregateWithEFCore.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace AggregateWithEFCore.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserAggregateRoot> Users { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
