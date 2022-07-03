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
        public static async Task SeedDateAsync(DataContext dataContext, UserManager<AppUser> userManager)
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

            if (!dataContext.Packets.Any()) {
                var Packets = new List<Packet>
                {
                    new Packet
                    {
                        Title = "Past Packet 1",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Packet 2 months ago",
                        Category = "drinks",

                        IsDelivered = false,
                    },
                    new Packet
                    {
                        Title = "Past Packet 2",
                        Date = DateTime.Now.AddMonths(-1),
                        Description = "Packet 1 month ago",
                        Category = "culture",
                        IsDelivered = false,

                    },
                    new Packet
                    {
                        Title = "Future Packet 1",
                        Date = DateTime.Now.AddMonths(1),
                        Description = "Packet 1 month in future",
                        Category = "culture",

                        IsDelivered = false,


                    },
                    new Packet
                    {
                        Title = "Future Packet 2",
                        Date = DateTime.Now.AddMonths(2),
                        Description = "Packet 2 months in future",
                        Category = "music",

                        IsDelivered = false,


                    },
                    new Packet
                    {
                        Title = "Future Packet 3",
                        Date = DateTime.Now.AddMonths(3),
                        Description = "Packet 3 months in future",
                        Category = "drinks",

                        IsDelivered = false,


                    },
                    new    Packet
                    {
                        Title = "Future Packet 4",
                        Date = DateTime.Now.AddMonths(4),
                        Description = "Packet 4 months in future",
                        Category = "drinks",

                        IsDelivered = false,


                    },
                    new Packet
                    {
                        Title = "Future Packet 5",
                        Date = DateTime.Now.AddMonths(5),
                        Description = "Packet 5 months in future",
                        Category = "drinks",

                        IsDelivered = false,


                    },
                    new Packet
                    {
                        Title = "Future Packet 6",
                        Date = DateTime.Now.AddMonths(6),
                        Description = "Packet 6 months in future",
                        Category = "music",

                        IsDelivered = false,

                    },
                    new Packet
                    {
                        Title = "Future Packet 7",
                        Date = DateTime.Now.AddMonths(7),
                        Description = "Packet 2 months ago",
                        Category = "travel",

                        IsDelivered = false,

                    },
                    new Packet
                    {
                        Title = "Future Packet 8",
                        Date = DateTime.Now.AddMonths(8),
                        Description = "Packet 8 months in future",
                        Category = "film",

                        IsDelivered = false,

                    }
                };

                dataContext.Packets.AddRange(Packets);
                dataContext.SaveChanges();
            }

        }
    }
}
