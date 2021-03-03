using Autofac;
using Buddy.Dependency;

namespace Buddy.Web
{
    public class BuddyWebDependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
        }

        public int Order => int.MaxValue;
    }
}