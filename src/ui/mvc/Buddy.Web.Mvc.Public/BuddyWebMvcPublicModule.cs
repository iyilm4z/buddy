using Buddy.Modularity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy;

[DependsOn(
    typeof(BuddyWebMvcSharedModule)
)]
public class BuddyWebMvcPublicModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
    }

    public override void Configure(IApplicationBuilder app)
    {
    }
}