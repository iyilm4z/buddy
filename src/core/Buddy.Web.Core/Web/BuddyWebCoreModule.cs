using Buddy.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Web;

[DependsOn(
    typeof(BuddyCoreModule)
)]
public class BuddyWebCoreModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();
    }
}