using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Buddy.Reflection
{
    public class BuddyAssemblyProvider : IAssemblyProvider
    {
        private const string AssemblyMatchLoadingPattern = "^Buddy";

        private const string AssemblyRestrictToLoadingPattern = ".*";

        private bool _binFolderAssembliesLoaded;

        public IEnumerable<Assembly> GetAssemblies()
        {
            if (_binFolderAssembliesLoaded)
            {
                return GetAssembliesInternal();
            }

            LoadMatchingAssembliesInBinFolder(AppContext.BaseDirectory);

            _binFolderAssembliesLoaded = true;

            return GetAssembliesInternal();
        }

        public IList<string> AdditionalAssemblyNames { get; set; } = new List<string>();

        private static bool Matches(string assemblyFullName)
        {
            return Matches(assemblyFullName, AssemblyMatchLoadingPattern)
                   && Matches(assemblyFullName, AssemblyRestrictToLoadingPattern);
        }

        private static bool Matches(string assemblyFullName, string pattern)
        {
            return Regex.IsMatch(assemblyFullName, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        private void LoadMatchingAssembliesInBinFolder(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                return;
            }

            var loadedAssemblyNames = GetAssembliesInternal().Select(asm => asm.FullName).ToList();

            foreach (var dllPath in Directory.GetFiles(directoryPath, "*.dll"))
            {
                try
                {
                    var an = AssemblyName.GetAssemblyName(dllPath);
                    if (Matches(an.FullName) && !loadedAssemblyNames.Contains(an.FullName))
                    {
                        AppDomain.CurrentDomain.Load(an);
                    }
                }
                catch (BadImageFormatException ex)
                {
                    Trace.TraceError(ex.ToString());
                }
            }
        }

        private IEnumerable<Assembly> GetAssembliesInternal()
        {
            var addedAssemblyNames = new List<string>();
            var assemblies = new List<Assembly>();

            AddAssembliesInAppDomain(addedAssemblyNames, assemblies);
            AddAdditionalAssemblies(addedAssemblyNames, assemblies);

            return assemblies;
        }

        private static void AddAssembliesInAppDomain(ICollection<string> addedAssemblyNames, ICollection<Assembly> assemblies)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (!Matches(assembly.FullName))
                {
                    continue;
                }

                if (addedAssemblyNames.Contains(assembly.FullName))
                {
                    continue;
                }

                assemblies.Add(assembly);
                addedAssemblyNames.Add(assembly.FullName);
            }
        }

        private void AddAdditionalAssemblies(ICollection<string> addedAssemblyNames, ICollection<Assembly> assemblies)
        {
            foreach (var assemblyName in AdditionalAssemblyNames)
            {
                var assembly = Assembly.Load(assemblyName);
                if (addedAssemblyNames.Contains(assembly.FullName))
                {
                    continue;
                }

                assemblies.Add(assembly);
                addedAssemblyNames.Add(assembly.FullName);
            }
        }
    }
}