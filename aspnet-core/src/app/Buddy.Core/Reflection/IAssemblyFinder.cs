using System.Collections.Generic;
using System.Reflection;

namespace Buddy.Reflection
{
    public interface IAssemblyFinder
    {
        List<Assembly> GetAllAssemblies();
    }
}