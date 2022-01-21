using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RestaurantTimBaig.Domain.DB;
using RestaurantTimBaig.Domain.Model;
using RestaurantTimBaig.Security;

namespace RestaurantTimBaig.Infrastructure.Guarantors
{
    /// <summary>
    /// Заполнение данных для DbContext
    /// </summary>
    public class SeedDataGuarantor
    {
        private readonly IServiceProvider _serviceProvider;
        public SeedDataGuarantor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Проверка данных
        /// </summary>
        public async Task EnsureAsync()
        {
            var context = _serviceProvider.GetService<RestaurantDBContext>();
            var userManager = _serviceProvider.GetService<UserManager<User>>();
            var roleManager = _serviceProvider.GetService<RoleManager<IdentityRole<int>>>();

            await AssertRoleExistenceAsync(roleManager, context);

            context.SaveChanges();

            var adminUser = userManager.FindByNameAsync(SecurityConstants.AdminUserName).Result;
            if (adminUser == null)
            {

                var profile = new Employee
                {
                    FirstName = SecurityConstants.AdminFirstName,
                    Surname = SecurityConstants.AdminSurName
                };

                adminUser = new User
                {
                    Email = SecurityConstants.AdminEmail,
                    UserName = SecurityConstants.AdminUserName,
                    Employee = profile
                };

                var passwordHasher = new PasswordHasher<User>();

                adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, SecurityConstants.AdminPassword);

                await userManager.CreateAsync(adminUser);
            }

            if (!userManager.IsInRoleAsync(adminUser, SecurityConstants.AdminRole).Result)
                userManager.AddToRoleAsync(adminUser, SecurityConstants.AdminRole).Wait();


            context.SaveChanges();
        }
        private static async Task AssertRoleExistenceAsync(RoleManager<IdentityRole<int>> roleManager, RestaurantDBContext context)
        {
            var roles = new List<IdentityRole<int>>
            {
                new IdentityRole<int> { Name = SecurityConstants.AdminRole, NormalizedName = "ADMIN" },
                new IdentityRole<int> { Name = SecurityConstants.CustomerRole, NormalizedName = "CUSTOMER" }
            };

            foreach (var role in roles)
            {
                var roleExit = await roleManager.RoleExistsAsync(role.Name);
                if (!roleExit)
                {
                    context.Roles.Add(role);
                    context.SaveChanges();
                }
            }

        }
    }
}
