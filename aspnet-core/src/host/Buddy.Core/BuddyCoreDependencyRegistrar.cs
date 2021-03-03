using Autofac;
using Buddy.Dependency;

namespace Buddy
{
    public class BuddyCoreDependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
        }

        public int Order => int.MinValue;
    }
}
