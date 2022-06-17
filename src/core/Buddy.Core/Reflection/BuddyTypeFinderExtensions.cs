using System;
using System.Collections.Generic;
using System.Linq;

namespace Buddy.Reflection;

public static class BuddyTypeFinderExtensions
{
    public static IEnumerable<Type> FindClassesOfType<T>(this ITypeFinder typeFinder,
        bool onlyConcreteClasses = true)
    {
        return FindClassesOfType(typeFinder, typeof(T), onlyConcreteClasses);
    }

    public static IEnumerable<Type> FindClassesOfType(this ITypeFinder typeFinder, Type assignTypeFrom,
        bool onlyConcreteClasses = true)
    {
        var result = new List<Type>();

        try
        {
            foreach (var type in typeFinder.FindAll())
            {
                if (!assignTypeFrom.IsAssignableFrom(type)
                    && (!assignTypeFrom.IsGenericTypeDefinition
                        || !DoesTypeImplementOpenGeneric(type, assignTypeFrom)))
                {
                    continue;
                }

                if (type.IsInterface)
                {
                    continue;
                }

                if (onlyConcreteClasses)
                {
                    if (type.IsClass && !type.IsAbstract)
                    {
                        result.Add(type);
                    }
                }
                else
                {
                    result.Add(type);
                }
            }
        }
        catch
        {
            // ignored
        }

        return result;
    }

    private static bool DoesTypeImplementOpenGeneric(Type type, Type openGeneric)
    {
        try
        {
            var genericTypeDefinition = openGeneric.GetGenericTypeDefinition();

            return (from implementedInterface in type.FindInterfaces((_, _) => true, null)
                    where implementedInterface.IsGenericType
                    select genericTypeDefinition.IsAssignableFrom(implementedInterface.GetGenericTypeDefinition()))
                .FirstOrDefault();
        }
        catch
        {
            return false;
        }
    }
}