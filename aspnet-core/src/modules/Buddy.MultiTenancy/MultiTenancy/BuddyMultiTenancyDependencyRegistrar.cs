using Autofac;
using Buddy.Configuration;
using Buddy.Dependency;
using Buddy.Reflection;

namespace Buddy.MultiTenancy
{
    public class BuddyMultiTenancyDependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, BuddyConfig config)
        {
        }

        public int Order => 10;
    }
}