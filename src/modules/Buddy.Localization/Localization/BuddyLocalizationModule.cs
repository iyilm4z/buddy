using Buddy.EntityFrameworkCore;
using Buddy.Modularity;
using Buddy.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Localization
{
    [DependsOn(
        typeof(BuddyEntityFrameworkCoreModule),
        typeof(BuddyWebCoreModule)
    )]
    public class BuddyLocalizationModule : BuddyModule
    {
        public override void ConfigureServices(IServiceCollection services)
        {
        }

        public override void Configure(IApplicationBuilder app)
        {
        }
    }
}