using Autofac;
using Buddy.Configuration;
using Buddy.Dependency;
using Buddy.Reflection;

namespace Buddy.Logging
{
    public class BuddyLoggingDependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, BuddyConfig config)
        {
        }

        public int Order => 10;
    }
}