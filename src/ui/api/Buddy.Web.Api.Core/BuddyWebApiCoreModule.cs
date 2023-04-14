using System;
using Buddy.Modularity;
using Buddy.Web.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Web;

[DependsOn(
    typeof(BuddyWebCoreModule)
)]
public class BuddyWebApiCoreModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenAuthenticationManager, JwtTokenAuthenticationManager>();
        services.AddHostedService<ClearExpiredRefreshTokensJob>();
    }

    public override void Configure(IServiceProvider serviceProvider)
    {
    }
}