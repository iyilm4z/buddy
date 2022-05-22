using Buddy.Modularity;
using Buddy.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy;

[DependsOn(
    typeof(BuddyWebCoreModule)
)]
public class BuddyWebMvcSharedModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
    }

    public override void Configure(IApplicationBuilder app)
    {
    }
}