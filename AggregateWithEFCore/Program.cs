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
            // Create an user aggregate and save it
            using (var dbContext = new AppDbContext())
            {
                dbContext.Database.EnsureCreated();

                var user = new UserAggregateRoot("Ousmane", "Barry", new Address("MyStreetName"));
                user.AddRole(new Role("Admin"));

                dbContext.Users.Add(user);

                var numberOfSavedEntities = await dbContext.SaveChangesAsync();


                Debug.Assert(numberOfSavedEntities == 2);
            }

            // Retrieve the previous saved user
            using (var dbContext = new AppDbContext())
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
