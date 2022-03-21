using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Buddy.Collections.Extensions;

namespace Buddy.Modularity;

internal static class BuddyModuleHelper
{
    public static List<Type> FindAllModuleTypes(Type startupModuleType)
    {
        var moduleTypes = new List<Type>();

        AddModuleAndDependenciesRecursively(moduleTypes, startupModuleType);

        moduleTypes.AddIfNotContains(typeof(BuddyCoreModule));

        return moduleTypes;
    }

    public static List<Type> FindDependedModuleTypes(Type moduleType)
    {
        if (!BuddyModule.IsIyModule(moduleType))
        {
            throw new ArgumentNullException(nameof(moduleType));
        }

        var dependencies = new List<Type>();

        if (moduleType.GetTypeInfo().IsDefined(typeof(DependsOnAttribute), true))
        {
            var dependsOnAttributes = moduleType.GetTypeInfo()
                .GetCustomAttributes(typeof(DependsOnAttribute), true)
                .Cast<DependsOnAttribute>();

            foreach (var dependsOnAttribute in dependsOnAttributes)
            {
                dependencies.AddRange(dependsOnAttribute.DependedModuleTypes);
            }
        }

        return dependencies;
    }

    private static void AddModuleAndDependenciesRecursively(List<Type> moduleTypes, Type moduleType)
    {
        if (!BuddyModule.IsIyModule(moduleType))
        {
            throw new ArgumentNullException(nameof(moduleType));
        }

        if (moduleTypes.Contains(moduleType))
        {
            return;
        }

        moduleTypes.Add(moduleType);

        var innerModuleTypes = FindDependedModuleTypes(moduleType);

        foreach (var dependedModuleType in innerModuleTypes)
        {
            AddModuleAndDependenciesRecursively(moduleTypes, dependedModuleType);
        }
    }
}