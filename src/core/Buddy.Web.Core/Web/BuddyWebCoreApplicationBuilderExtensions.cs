using Buddy.Dependency;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Web;

public static class BuddyWebCoreApplicationBuilderExtensions
{
    public static void UseBuddyWeb(this IApplicationBuilder app)
    {
        app.UseApplicationBuilderAccessor();

        app.ApplicationServices.UseBuddy();
    }
    
    public static void UseApplicationBuilderAccessor(this IApplicationBuilder app)
    {
        app.ApplicationServices.GetRequiredService<ObjectAccessor<IApplicationBuilder>>().Value = app;
    }
}