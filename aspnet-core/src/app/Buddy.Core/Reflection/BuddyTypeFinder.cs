using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Buddy.Collections.Extensions;

namespace Buddy.Reflection
{
    public class BuddyTypeFinder : ITypeFinder
    {
        private readonly IAssemblyFinder _assemblyFinder;
        private readonly object _syncObj = new();
        private Type[] _types;

        public BuddyTypeFinder(IAssemblyFinder assemblyFinder)
        {
            _assemblyFinder = assemblyFinder;
        }

        public Type[] Find(Func<Type, bool> predicate)
        {
            return GetAllTypes().Where(predicate).ToArray();
        }

        public Type[] FindAll()
        {
            return GetAllTypes().ToArray();
        }

        private Type[] GetAllTypes()
        {
            if (_types != null)
            {
                return _types;
            }

            lock (_syncObj)
            {
                _types ??= CreateTypeList().ToArray();
            }

            return _types;
        }

        private List<Type> CreateTypeList()
        {
            var allTypes = new List<Type>();

            var assemblies = _assemblyFinder.GetAllAssemblies().Distinct();

            foreach (var assembly in assemblies)
            {
                try
                {
                    Type[] typesInThisAssembly;

                    try
                    {
                        typesInThisAssembly = assembly.GetTypes();
                    }
                    catch (ReflectionTypeLoadException ex)
                    {
                        typesInThisAssembly = ex.Types;
                    }

                    if (typesInThisAssembly.IsNullOrEmpty())
                    {
                        continue;
                    }

                    allTypes.AddRange(typesInThisAssembly.Where(type => type != null));
                }
                catch (Exception ex)
                {
                    Trace.TraceWarning(ex.ToString(), ex);
                }
            }

            return allTypes;
        }
    }
}