using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CoreUserAuth.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            string[] roles = new string[] { "Organizer", "Team Player", "Contributor", "Observer" };

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);

                if (!context.Roles.Any(r => r.Name == role))
                {
                    var result = roleStore.CreateAsync(new IdentityRole(role){NormalizedName = role.ToUpper()}).Result;
                }
            }
            context.SaveChanges();
        }
    }
}
