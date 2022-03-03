using ClinicAPIv1.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClinicAPIv1.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<ClinicUser> userManager,
            RoleManager<ClinicRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<ClinicUser>>(userData);
            if (users == null) return;

            var roles = new List<ClinicRole>
            {
                new ClinicRole{Name = "Patient"},
                new ClinicRole{Name = "Doctor"},
                new ClinicRole{Name = "Admin"},
                new ClinicRole{Name = "WardClerk"}
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach(var user in users)
            {
                user.UserName = user.UserName.ToLower();
                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Patient");
            }

            var admin = new ClinicUser
            {
                UserName = "admin"
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRoleAsync(admin, "Admin");

            var wardclerk = new ClinicUser
            {
                UserName = "wardclerk"
            };

            await userManager.CreateAsync(wardclerk, "Pa$$w0rd");
            await userManager.AddToRoleAsync(wardclerk, "WardClerk");
        }
    }
}
