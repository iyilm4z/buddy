using System;
using Buddy.Modularity;
using Buddy.Users;
using Buddy.Web.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Web;

[DependsOn(
    typeof(BuddyWebCoreModule),
    typeof(BuddyUsersModule)
)]
public class BuddyWebApiCoreModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IJwtAuthenticationManager, JwtAuthenticationManager>();
        services.AddHostedService<JwtRefreshTokenCache>();
    }

    public override void Configure(IServiceProvider serviceProvider)
    {
    }
}