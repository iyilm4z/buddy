using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Buddy.Dependency;
using Buddy.Modularity;
using Buddy.ObjectMapping;
using Buddy.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy
{
    public class BuddyCoreModule : BuddyModule
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            RegisterConventionalDependencies(services, Singleton<IAssemblyFinder>.Instance);
        }

        public override void Configure(IApplicationBuilder app)
        {
            AddAutoMapper(Singleton<ITypeFinder>.Instance);

            RunStartupTasks(Singleton<ITypeFinder>.Instance);

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        private static void RegisterConventionalDependencies(IServiceCollection services,
            IAssemblyFinder assemblyFinder)
        {
            foreach (var assembly in assemblyFinder.GetAllAssemblies())
            {
                services.RegisterConventionalDependencyInjection(assembly);
            }
        }

        private static void AddAutoMapper(ITypeFinder typeFinder)
        {
            var mapperConfigurations = typeFinder.FindClassesOfType<IOrderedMapperProfile>();

            var instances = mapperConfigurations
                .Select(mapperConfiguration => (IOrderedMapperProfile)Activator.CreateInstance(mapperConfiguration))
                .OrderBy(mapperConfiguration => mapperConfiguration.Order);

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var instance in instances)
                {
                    cfg.AddProfile(instance.GetType());
                }
            });

            AutoMapperConfiguration.Init(config);
        }

        private static void RunStartupTasks(ITypeFinder typeFinder)
        {
            var startupTasks = typeFinder.FindClassesOfType<IStartupTask>();

            var instances = startupTasks
                .Select(startupTask => (IStartupTask)Activator.CreateInstance(startupTask))
                .OrderBy(startupTask => startupTask.Order);

            foreach (var task in instances)
            {
                task.Execute();
            }
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName == args.Name);
            if (assembly != null)
            {
                return assembly;
            }

            var assemblyFinder = Singleton<IAssemblyFinder>.Instance;
            if (assemblyFinder == null)
            {
                return null;
            }

            assembly = assemblyFinder.GetAllAssemblies().FirstOrDefault(asm => asm.FullName == args.Name);

            return assembly;
        }
    }
}