using Buddy.Modularity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Localization
{
    [DependsOn(
        typeof(BuddyCoreModule)
    )]
    public class BuddyLocalizationSharedModule : BuddyModule
    {
        public override void ConfigureServices(IServiceCollection services)
        {
        }

        public override void Configure(IApplicationBuilder app)
        {
        }
    }
}