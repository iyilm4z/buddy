using Buddy.Configuration;
using Buddy.Localization;
using Buddy.Logging;
using Buddy.Modularity;
using Buddy.MultiTenancy;
using Buddy.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Web.Mvc;

[DependsOn(
    typeof(BuddyWebMvcCoreModule),
    typeof(BuddyConfigurationModule),
    typeof(BuddyLocalizationModule),
    typeof(BuddyLoggingModule),
    typeof(BuddyMultiTenancyModule),
    typeof(BuddyUsersModule)
)]
public class BuddyWebMvcLocalizationModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
    }

    public override void Configure(IApplicationBuilder app)
    {
    }
}