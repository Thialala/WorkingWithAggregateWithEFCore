using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AggregateWithEFCore.DomainModel;
using AggregateWithEFCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AggregateWithEFCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // C'est ici que l'on définit le provider: InMemory, SqlLite, SQL Server, etc....
            // Donc je peux lire un fichier de config et instancier le bon provider
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source = aggregatewithefcore.db").Options;

            // Create an user aggregate and save it
            await using (var dbContext = new AppDbContext(options))
            {
                dbContext.Database.EnsureCreated();

                var user = new UserAggregateRoot("Ousmane", "Barry", new Address("MyStreetName"));
                user.AddRole(new Role("Admin"));

                dbContext.Users.Add(user);

                var numberOfSavedEntities = await dbContext.SaveChangesAsync();


                Debug.Assert(numberOfSavedEntities == 2);
            }

            // Retrieve the previous saved user
            await using (var dbContext = new AppDbContext(options))
            {

                var users = await dbContext.Users
                                                            .AsNoTracking()
                                                            .Include(u => u.Roles).ToListAsync();

                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Id}\t{user.FirstName}\t{user.LastName}\t{user.Address.AddressLine}\t{user.Roles.First().RoleName}");
                }
            }
        }
    }
}
