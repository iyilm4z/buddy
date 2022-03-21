using System;
using System.Collections.Generic;
using System.Linq;
using Buddy.Collections.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Modularity
{
    internal static class BuddyModuleLoader
    {
        public static List<BuddyModuleInfo> LoadModules(IServiceCollection services, Type startupModuleType)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (startupModuleType == null)
            {
                throw new ArgumentNullException(nameof(startupModuleType));
            }

            var modules = GetModuleInfos(services, startupModuleType);

            modules = SortByDependency(modules, startupModuleType);

            return modules;
        }

        private static List<BuddyModuleInfo> GetModuleInfos(IServiceCollection services, Type startupModuleType)
        {
            var modules = new List<BuddyModuleInfo>();

            FillModules(modules, services, startupModuleType);
            SetDependencies(modules);

            return modules;
        }

        private static List<BuddyModuleInfo> SortByDependency(List<BuddyModuleInfo> modules, Type startupModuleType)
        {
            var sortedModules = modules.SortByDependencies(x => x.Dependencies);

            EnsureCoreModuleToBeFirst(sortedModules);
            EnsureStartupModuleToBeLast(sortedModules, startupModuleType);

            return sortedModules;
        }

        private static void FillModules(List<BuddyModuleInfo> modules, IServiceCollection services,
            Type startupModuleType)
        {
            var moduleTypes = BuddyModuleHelper.FindAllModuleTypes(startupModuleType);

            foreach (var moduleType in moduleTypes)
            {
                var module = (BuddyModule)Activator.CreateInstance(moduleType);

                services.AddSingleton(moduleType, module);

                var moduleInfo = new BuddyModuleInfo(moduleType, module);

                modules.Add(moduleInfo);
            }
        }

        private static void SetDependencies(List<BuddyModuleInfo> modules)
        {
            foreach (var module in modules)
            {
                SetDependencies(modules, module);
            }
        }

        private static void SetDependencies(List<BuddyModuleInfo> modules, BuddyModuleInfo module)
        {
            var dependedModuleTypes = BuddyModuleHelper.FindDependedModuleTypes(module.Type);

            foreach (var dependedModuleType in dependedModuleTypes)
            {
                var dependedModule = modules.FirstOrDefault(x => x.Type == dependedModuleType);

                if (dependedModule == null)
                {
                    throw new Exception("Could not find a depended module "
                                        + dependedModuleType.AssemblyQualifiedName
                                        + " for " + module.Type.AssemblyQualifiedName);
                }

                module.AddDependency(dependedModule);
            }
        }

        private static void EnsureCoreModuleToBeFirst(List<BuddyModuleInfo> modules)
        {
            var coreModuleIndex = modules.FindIndex(x => x.Type == typeof(BuddyCoreModule));
            if (coreModuleIndex <= 0)
            {
                //It's already the first!
                return;
            }

            var coreModule = modules[coreModuleIndex];
            modules.RemoveAt(coreModuleIndex);
            modules.Insert(0, coreModule);
        }

        private static void EnsureStartupModuleToBeLast(List<BuddyModuleInfo> modules, Type startupModuleType)
        {
            var startupModuleIndex = modules.FindIndex(x => x.Type == startupModuleType);
            if (startupModuleIndex >= modules.Count - 1)
            {
                //It's already the last!
                return;
            }

            var startupModule = modules[startupModuleIndex];
            modules.RemoveAt(startupModuleIndex);
            modules.Add(startupModule);
        }
    }
}