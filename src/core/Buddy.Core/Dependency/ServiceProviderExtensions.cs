using System;
using Buddy.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Dependency;

public static class ServiceProviderExtensions
{
    public static IAssemblyFinder GetAssemblyFinder(this IServiceProvider serviceProvider)
    {
        return serviceProvider.GetRequiredService<IAssemblyFinder>();
    }

    public static ITypeFinder GetTypeFinder(this IServiceProvider serviceProvider)
    {
        return serviceProvider.GetRequiredService<ITypeFinder>();
    }
}