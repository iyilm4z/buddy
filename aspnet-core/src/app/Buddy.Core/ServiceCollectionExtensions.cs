using Buddy.Dependency;
using Buddy.Modularity;
using Buddy.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBuddy<TStartupModule>(this IServiceCollection services)
            where TStartupModule : BuddyModule
        {
            var buddyApp = new BuddyApplication(typeof(TStartupModule), services);
            buddyApp.LoadModules();

            // create and register the service locator
            // force to keep these codes just before returning the services 
            var serviceLocator = BuddyServiceLocator.Create();
            services.AddSingleton(serviceLocator);

            return services;
        }

        public static void AddCoreModuleServices(this IServiceCollection services,
            IBuddyModuleContainer moduleContainer)
        {
            // register assembly provider
            var assemblyProvider = new BuddyAssemblyFinder(moduleContainer);
            Singleton<IAssemblyFinder>.Instance = assemblyProvider;
            services.AddSingleton<IAssemblyFinder>(assemblyProvider);

            // register type finder
            var typeFinder = new BuddyTypeFinder(assemblyProvider);
            Singleton<ITypeFinder>.Instance = typeFinder;
            services.AddSingleton<ITypeFinder>(typeFinder);
        }
    }
}