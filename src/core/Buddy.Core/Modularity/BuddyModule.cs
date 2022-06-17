using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Modularity;

public abstract class BuddyModule
{
    public virtual void ConfigureServices(IServiceCollection services)
    {
    }

    public virtual void Configure(IApplicationBuilder app)
    {
    }

    public static bool IsIyModule(Type type)
    {
        var typeInfo = type.GetTypeInfo();
        return
            typeInfo.IsClass &&
            !typeInfo.IsAbstract &&
            !typeInfo.IsGenericType &&
            typeof(BuddyModule).IsAssignableFrom(type);
    }

    public virtual Assembly[] GetAdditionalAssemblies()
    {
        return Array.Empty<Assembly>();
    }
}