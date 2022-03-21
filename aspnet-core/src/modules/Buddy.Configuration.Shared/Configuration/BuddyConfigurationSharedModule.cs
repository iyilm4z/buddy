using Buddy.Modularity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Configuration
{
    [DependsOn(
        typeof(BuddyCoreModule)
    )]
    public class BuddyConfigurationSharedModule : BuddyModule
    {
        public override void ConfigureServices(IServiceCollection services)
        {
        }

        public override void Configure(IApplicationBuilder app)
        {
        }
    }
}