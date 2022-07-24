using Buddy.Dependency;
using Buddy.Modularity;
using Buddy.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy;

public static class BuddyCoreServiceCollectionExtensions
{
    public static void AddBuddy<TStartupModule>(this IServiceCollection services)
        where TStartupModule : BuddyModule
    {
        var buddyApp = new BuddyApplication(typeof(TStartupModule), services);
        buddyApp.LoadModules();
    }

    public static void AddCoreModuleServices(this IServiceCollection services,
        IBuddyModuleContainer moduleContainer)
    {
        // register assembly provider
        var assemblyProvider = new BuddyAssemblyFinder(moduleContainer);
        services.AddSingleton<IAssemblyFinder>(assemblyProvider);

        // register type finder
        var typeFinder = new BuddyTypeFinder(assemblyProvider);
        services.AddSingleton<ITypeFinder>(typeFinder);
    }

    public static void RegisterConventionalDependencies(this IServiceCollection services)
    {
        var assemblyFinder = services.GetAssemblyFinder();
        foreach (var assembly in assemblyFinder.GetAllAssemblies())
        {
            services.RegisterConventionalDependencyInjection(assembly);
        }
    }
}