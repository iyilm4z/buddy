using System;
using System.Linq;
using System.Reflection;
using Buddy.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Dependency;

public static class ServiceCollectionExtensions
{
    public static void RegisterConventionalDependencyInjection(this IServiceCollection services, Assembly assembly)
    {
        typeof(ITransientDependency)
            .AssignedTypesInAssembly(assembly)
            .ForEach(assignedType =>
            {
                services.AddTransient(assignedType);

                assignedType
                    .GetDefaultInterfaces()
                    .ForEach(defaultInterface => { services.AddTransient(defaultInterface, assignedType); });
            });

        typeof(ISingletonDependency)
            .AssignedTypesInAssembly(assembly)
            .ForEach(assignedType =>
            {
                services.AddSingleton(assignedType);

                assignedType
                    .GetDefaultInterfaces()
                    .ForEach(defaultInterface => { services.AddSingleton(defaultInterface, assignedType); });
            });

        typeof(IScopedDependency)
            .AssignedTypesInAssembly(assembly)
            .ForEach(assignedType =>
            {
                services.AddScoped(assignedType);

                assignedType
                    .GetDefaultInterfaces()
                    .ForEach(defaultInterface => { services.AddScoped(defaultInterface, assignedType); });
            });
    }

    public static T GetSingletonInstanceOrNull<T>(this IServiceCollection services)
    {
        return (T)services
            .FirstOrDefault(d => d.ServiceType == typeof(T))
            ?.ImplementationInstance;
    }

    public static T GetSingletonInstance<T>(this IServiceCollection services)
    {
        var service = services.GetSingletonInstanceOrNull<T>();
        if (service == null)
        {
            throw new InvalidOperationException("Could not find singleton service: " + typeof(T).AssemblyQualifiedName);
        }

        return service;
    }

    public static IAssemblyFinder GetAssemblyFinder(this IServiceCollection services)
    {
        return services.GetSingletonInstance<IAssemblyFinder>();
    }

    public static ITypeFinder GetTypeFinder(this IServiceCollection services)
    {
        return services.GetSingletonInstance<ITypeFinder>();
    }
}