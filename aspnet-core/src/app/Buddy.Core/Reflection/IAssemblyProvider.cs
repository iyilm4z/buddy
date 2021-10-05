using System.Collections.Generic;
using System.Reflection;

namespace Buddy.Reflection
{
    public interface IAssemblyProvider
    {
        IList<string> AdditionalAssemblyNames { get; set; }

        IEnumerable<Assembly> GetAssemblies();
    }
}