using AggregateWithEFCore.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace AggregateWithEFCore.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserAggregateRoot> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=aggregatewithefcore.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
