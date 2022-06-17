using Buddy.EntityFrameworkCore;
using Buddy.Modularity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.MultiTenancy;

[DependsOn(
    typeof(BuddyEntityFrameworkCoreModule)
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