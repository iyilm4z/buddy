using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Buddy.Collections.Extensions;

namespace Buddy.Reflection;

internal static class TypeExtensions
{
    public static List<Type> GetDefaultInterfaces(this Type @this)
    {
        var orderedInterfaces = @this.GetTypeInfo()
            .GetInterfaces()
            .OrderBy(@interface => @interface.AssemblyQualifiedName, StringComparer.OrdinalIgnoreCase)
            .ToList();

        var defaultInterfaces = orderedInterfaces
            .Where(@interface => @this.Name.Contains(GetInterfaceName(@interface)))
            .ToList();

        return defaultInterfaces;
    }

    public static List<Type> AssignedTypesInAssembly(this Type @this, Assembly assembly, bool includeNonGenericTypes = false)
    {
        var assignedTypes = assembly.GetTypes()
            .Where(type => @this.GetTypeInfo().IsAssignableFrom(type)
                           && type.GetTypeInfo().IsClass
                           && !type.GetTypeInfo().IsAbstract
                           && !type.GetTypeInfo().IsSealed)
            .WhereIf(!includeNonGenericTypes, type => !type.GetTypeInfo().IsGenericType);

        return assignedTypes.ToList();
    }

    private static string GetInterfaceName(MemberInfo @interface)
    {
        var name = @interface.Name;
        if (name.Length > 1 && name[0] == 'I' && char.IsUpper(name[1]))
        {
            name = name.Substring(1);
        }

        return name;
    }
}