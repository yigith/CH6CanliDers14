using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityBaslangic.Data
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<IdentityUser> userManager)
        {
            var ornekKullanici = new IdentityUser()
            {
                Email = "demouser@example.com",
                UserName = "demouser@example.com",
                EmailConfirmed = true
            };

            await userManager.CreateAsync(ornekKullanici, "Ankara1.");
        }

        public static async Task SeedAdminRoleAndUserAsync(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            if (!await roleManager.RoleExistsAsync("admin"))
            {
                var adminRole = new IdentityRole("admin");
                await roleManager.CreateAsync(adminRole);
            }

            if (!await userManager.Users.AnyAsync(u => u.UserName == "admin@example.com"))
            {
                var adminKullanici = new IdentityUser()
                {
                    Email = "adminuser@example.com",
                    UserName = "adminuser@example.com",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(adminKullanici, "P@ssword1");
                await userManager.AddToRoleAsync(adminKullanici, "admin");
            }
        }
    }
}
