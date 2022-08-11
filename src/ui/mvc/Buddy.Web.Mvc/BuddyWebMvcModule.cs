using System;
using Buddy.EntityFrameworkCore;
using Buddy.Modularity;
using Buddy.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Buddy.Web;

[DependsOn(
    typeof(BuddyWebMvcCoreModule),
    typeof(BuddyUsersModule)
)]
public class BuddyWebMvcModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();

        var configuration = serviceProvider.GetService<IConfiguration>();

        services.AddDbContext<BuddyDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddControllersWithViews();

        services.AddRazorPages(options => { options.Conventions.AuthorizeAreaFolder("Admin", "/"); })
            .AddRazorRuntimeCompilation();

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie();
    }

    public override void Configure(IServiceProvider serviceProvider)
    {
        var app = serviceProvider.GetRequiredApplicationBuilder();
        var env = serviceProvider.GetRequiredWebHostEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );
            endpoints.MapRazorPages();
        });
    }
}