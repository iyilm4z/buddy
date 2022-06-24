using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Modularity;

public abstract class BuddyModule
{
    public virtual void ConfigureServices(IServiceCollection services)
    {
    }

    public virtual void Configure(IServiceProvider serviceProvider)
    {
    }

    public static bool IsBuddyModule(Type type)
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