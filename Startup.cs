using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestaurantTimBaig.Domain.DB;
using RestaurantTimBaig.Domain.Model;
using RestaurantTimBaig.Infrastructure;
using RestaurantTimBaig.Infrastructure.Guarantors;
using System;

namespace RestaurantTimBaig
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<RestaurantDBContext>(options =>
                options.UseNpgsql("Username=ksenia; Database=RestaurantTimBaig; Password=ksenia; Host=localhost"));
            services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<RestaurantDBContext>();

            //Добавление безопасности
            services.AddControllersWithViews();

            var serviceProvider = services.BuildServiceProvider();
            var guarantor = new SeedDataGuarantor(serviceProvider);
            guarantor.EnsureAsync();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope=app.ApplicationServices.CreateScope())
            {
                var guarantors = scope.ServiceProvider.GetServices<IStartupPreConditionGuarantor>();
                try
                {
                    Console.WriteLine("Startup guarantors started");
                    foreach (var guarantor in guarantors)
                        guarantor.Ensure(scope.ServiceProvider);

                    Console.WriteLine("Startup guarantors executed successfuly");
                }
                catch (StartupPreConditionException)
                {
                    Console.WriteLine("Startup guarantors  failed");
                    throw;
                }

            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
