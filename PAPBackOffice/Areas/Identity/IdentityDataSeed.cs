using Microsoft.AspNetCore.Identity;

namespace PAPBackOffice.Areas.Identity
{
    public static class IdentityDataSeed
    {
        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("ricardochelas637@gmail.com").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "ricardochelas637@gmail.com",
                    Email = "ricardochelas637@gmail.com",
                    Name = "Ricardo Almeida"
                };

                var result = userManager.CreateAsync(user, "Admin123!").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"Super Administrador").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Super Administrador").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Super Administrador"
                };
                var roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Administrador").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrador"
                };
                var roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Gestor Pedidos").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Gestor Pedidos"
                };
                var roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Funcionario").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Funcionario"
                };
                var roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
