using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;

namespace DataLayer
{
    public class DataSeeder
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;

        public DataSeeder(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void SeedRoles()
        {
            using(var context=new NobatOnlineContext())
            {
                if (!context.Users.Any())
                {
                    AppRole AdminRole = new AppRole {
                        Name = Utilities.RoleNames.Administrator
                    };
                   var AdminResult= roleManager.CreateAsync(AdminRole).Result;
                    if (AdminResult.Succeeded)
                    {
                       AppRole MakeupRole = new AppRole {
                        Name = Utilities.RoleNames.Beautify
                    };
                    var MakeupResult = roleManager.CreateAsync(MakeupRole).Result;
                    if (MakeupResult.Succeeded)
                    {
                            AppRole CustomerRole = new AppRole {
                                Name=Utilities.RoleNames.Customer
                            };
                            var CustomerResult = roleManager.CreateAsync(CustomerRole).Result;
                            if (CustomerResult.Succeeded)
                            {

                            }
                    }
                    }
                    
                }
            }
        }
        public void SeedUser()
        {
            using (var context = new NobatOnlineContext())
            {
                if (!context.Users.Any())
                {
                    AppUser admin = new AppUser
                    {
                        FirstName = "nader",
                        LastName = "bayati",
                        CodeMeli = "5750093824",
                        UserName = "Admin",
                        Active = true,
                        PhoneNumber = "09330920660",
                        Email = "naderbayati1379@gmail.com"
                    };
                    var result = userManager.CreateAsync(admin, "@Admin1379").Result;
                    if (result.Succeeded)
                    {
                        var roleResult = userManager.AddToRoleAsync(admin, Utilities.RoleNames.Administrator).Result;
                        if (!roleResult.Succeeded)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            foreach (var item in roleResult.Errors)
                            {
                                Console.WriteLine(item.Description);
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
               
            }
           
        }
    }
}
