using Buddy.Configuration;
using Buddy.Localization;
using Buddy.Logging;
using Buddy.Modularity;
using Buddy.MultiTenancy;
using Buddy.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.EntityFrameworkCore
{
    [DependsOn(
        typeof(BuddyConfigurationSharedModule),
        typeof(BuddyLocalizationSharedModule),
        typeof(BuddyLoggingSharedModule),
        typeof(BuddyMultiTenancySharedModule),
        typeof(BuddyUsersSharedModule)
    )]
    public class BuddyEntityFrameworkCoreModule : BuddyModule
    {
        public override void ConfigureServices(IServiceCollection services)
        {
        }

        public override void Configure(IApplicationBuilder app)
        {
        }
    }
}