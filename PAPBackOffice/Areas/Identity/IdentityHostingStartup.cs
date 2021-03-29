using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PAPBackOffice.Data;

[assembly: HostingStartup(typeof(PAPBackOffice.Areas.Identity.IdentityHostingStartup))]
namespace PAPBackOffice.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<IdentityDatabaseContext>(options =>
                            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")))
                        .AddLogging();

                //services.AddDbContextFactory<IdentityDatabaseContext>(
                //            options => options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")))
                //        .AddLogging();

                services.AddDefaultIdentity<ApplicationUser>(options => { options.SignIn.RequireConfirmedAccount = false; })
                        .AddRoles<IdentityRole>()
                        .AddEntityFrameworkStores<IdentityDatabaseContext>();

                //services.AddAuthorization(options =>
                //{
                //    options.FallbackPolicy = new AuthorizationPolicyBuilder()
                //        .RequireAuthenticatedUser()
                //        .Build();
                //});
            });
        }
    }
}