using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Buddy.Modularity;

namespace Buddy.Reflection
{
    public class BuddyAssemblyFinder : IAssemblyFinder
    {
        private readonly IBuddyModuleContainer _moduleContainer;

        public BuddyAssemblyFinder(IBuddyModuleContainer moduleContainer)
        {
            _moduleContainer = moduleContainer;
        }

        public List<Assembly> GetAllAssemblies()
        {
            var assemblies = new List<Assembly>();

            foreach (var module in _moduleContainer.Modules)
            {
                assemblies.Add(module.Assembly);
                assemblies.AddRange(module.Instance.GetAdditionalAssemblies());
            }

            return assemblies.Distinct().ToList();
        }
    }
}