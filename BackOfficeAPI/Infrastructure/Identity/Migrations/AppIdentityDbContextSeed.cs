using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Migrations
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    DisplayName = "Hamza",
                    Email = "Hamzasheikh0101@hotmail.com",
                    UserName = "Hamza0101",
                    Address = new Address
                    {
                        FirstName = "Hamza",
                        LastName = "Sheikh",
                        Street = "10 The street",
                        City = "Lahore",
                        State = "punjab",
                        ZipCode = "54000"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
