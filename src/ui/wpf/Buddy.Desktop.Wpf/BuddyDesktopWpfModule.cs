using System;
using Buddy.EntityFrameworkCore;
using Buddy.Modularity;
using Buddy.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Desktop;

[DependsOn(
    typeof(BuddyDesktopWpfCoreModule),
    typeof(BuddyEntityFrameworkCoreModule),
    typeof(BuddyUsersModule)
)]
public class BuddyDesktopWpfModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();

        var configuration = serviceProvider.GetService<IConfiguration>();

        services.AddDbContext<BuddyDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }

    public override void Configure(IServiceProvider serviceProvider)
    {
    }
}