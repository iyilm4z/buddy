using System;
using Buddy.Configuration;
using Buddy.EntityFrameworkCore;
using Buddy.Localization;
using Buddy.Logging;
using Buddy.Modularity;
using Buddy.MultiTenancy;
using Buddy.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Buddy.Web;

[DependsOn(
    typeof(BuddyWebApiCoreModule),
    typeof(BuddyConfigurationModule),
    typeof(BuddyLocalizationModule),
    typeof(BuddyLoggingModule),
    typeof(BuddyMultiTenancyModule),
    typeof(BuddyUsersModule)
)]
public class BuddyWebApiModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();

        var env = serviceProvider.GetService<IWebHostEnvironment>();
        var configuration = serviceProvider.GetService<IConfiguration>();

        services.AddDbContext<BuddyDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddMvc();
        services.AddSwaggerGen();
    }

    public override void Configure(IServiceProvider serviceProvider)
    {
        var app = serviceProvider.GetRequiredApplicationBuilder();
        var env = serviceProvider.GetRequiredWebHostEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
            endpoints.MapControllers();
        });
    }
}