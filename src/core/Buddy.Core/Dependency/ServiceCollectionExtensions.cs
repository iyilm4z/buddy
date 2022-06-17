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
                    .ForEach(defaultInterface =>
                    {
                        services.AddTransient(defaultInterface, assignedType);
                    });
            });

        typeof(ISingletonDependency)
            .AssignedTypesInAssembly(assembly)
            .ForEach(assignedType =>
            {
                services.AddSingleton(assignedType);

                assignedType
                    .GetDefaultInterfaces()
                    .ForEach(defaultInterface =>
                    {
                        services.AddSingleton(defaultInterface, assignedType);
                    });
            });

        typeof(IScopedDependency)
            .AssignedTypesInAssembly(assembly)
            .ForEach(assignedType =>
            {
                services.AddScoped(assignedType);

                assignedType
                    .GetDefaultInterfaces()
                    .ForEach(defaultInterface =>
                    {
                        services.AddScoped(defaultInterface, assignedType);
                    });
            });
    }
}