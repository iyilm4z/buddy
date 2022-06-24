using Buddy.Dependency;
using Buddy.Modularity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Web;

public static class BuddyWebCoreServiceCollectionExtensions
{
    public static void AddBuddyWeb<TStartupModule>(this IServiceCollection services)
        where TStartupModule : BuddyModule
    {
        services.AddApplicationBuilderAccessor();

        services.AddBuddy<TStartupModule>();
    }

    public static void AddApplicationBuilderAccessor(this IServiceCollection services)
    {
        services.AddSingleton(new ObjectAccessor<IApplicationBuilder>());
    }
}