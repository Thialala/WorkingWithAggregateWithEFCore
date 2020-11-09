using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AggregateWithEFCore.Infrastructure
{
    // Utiliser uniquement pour les migrations
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite("Data Source=aggregatewithefcore.db");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}