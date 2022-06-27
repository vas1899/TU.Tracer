using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedDateAsync(DataContext datacontext, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any()) {
                var users = new List<AppUser> {
                   new AppUser{DisplayName="Vasil", UserName="vasil", Email="vasil1212@gmail.com"},
                   new AppUser{DisplayName="Vasil", UserName="vasil1", Email="vasil12321312@gmail.com"},
                   new AppUser{DisplayName="Vasil", UserName="vasil2", Email="vasil1213213122@gmail.com"}
                };
                foreach (var user in users) {
                    await userManager.CreateAsync(user, "123456");
                }
            }
        }
    }
}
