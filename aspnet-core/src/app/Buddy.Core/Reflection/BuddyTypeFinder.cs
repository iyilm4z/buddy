using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Buddy.Reflection
{
    public class BuddyTypeFinder : ITypeFinder
    {
        private readonly IAssemblyProvider _assemblyProvider;

        public BuddyTypeFinder(IAssemblyProvider assemblyProvider)
        {
            _assemblyProvider = assemblyProvider;
        }

        public IEnumerable<Type> FindClassesOfType<T>(bool onlyConcreteClasses = true)
        {
            return FindClassesOfType(typeof(T), onlyConcreteClasses);
        }

        public IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, bool onlyConcreteClasses = true)
        {
            return FindClassesOfType(assignTypeFrom, _assemblyProvider.GetAssemblies(), onlyConcreteClasses);
        }

        public IEnumerable<Type> FindClassesOfType<T>(IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true)
        {
            return FindClassesOfType(typeof(T), assemblies, onlyConcreteClasses);
        }

        public IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true)
        {
            var result = new List<Type>();

            try
            {
                foreach (var assembly in assemblies)
                {
                    Type[] types = null;

                    try
                    {
                        types = assembly.GetTypes();
                    }
                    catch
                    {
                        // ignored
                    }

                    if (types == null)
                    {
                        continue;
                    }

                    foreach (var type in types)
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

                return (from implementedInterface in type.FindInterfaces((objType, objCriteria) => true, null)
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
}