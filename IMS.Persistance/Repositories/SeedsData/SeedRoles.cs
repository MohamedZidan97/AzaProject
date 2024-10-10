using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Persistance.Repositories.SeedsData
{
    public static class SeedRoles
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var Roles = await roleManager.Roles.CountAsync();
            if (Roles <= 0)
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Admin", ConcurrencyStamp = "ed56a98a-62a0-4052-935c-85df0d7b45d1" });
            }
        }
    }
}
