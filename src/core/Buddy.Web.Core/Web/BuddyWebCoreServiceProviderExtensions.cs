using System;
using Buddy.Dependency;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Web;

public static class BuddyWebCoreServiceProviderExtensions
{
    public static IApplicationBuilder GetRequiredApplicationBuilder(this IServiceProvider serviceProvider)
    {
        return serviceProvider.GetRequiredService<ObjectAccessor<IApplicationBuilder>>().Value;
    }

    public static IWebHostEnvironment GetRequiredWebHostEnvironment(this IServiceProvider serviceProvider)
    {
        return serviceProvider.GetRequiredService<IWebHostEnvironment>();
    }
}