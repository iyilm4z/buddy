using Buddy.EntityFrameworkCore;
using Buddy.Modularity;
using Buddy.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.MultiTenancy
{
    [DependsOn(
        typeof(BuddyEntityFrameworkCoreModule),
        typeof(BuddyWebCoreModule)
    )]
    public class BuddyMultiTenancyModule : BuddyModule
    {
        public override void ConfigureServices(IServiceCollection services)
        {
        }

        public override void Configure(IApplicationBuilder app)
        {
        }
    }
}