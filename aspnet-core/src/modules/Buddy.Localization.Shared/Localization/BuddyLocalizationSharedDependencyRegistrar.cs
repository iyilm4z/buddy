using Autofac;
using Buddy.Configuration;
using Buddy.Dependency;
using Buddy.Reflection;

namespace Buddy.Localization
{
    public class BuddyLocalizationSharedDependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, BuddyConfig config)
        {
        }

        public int Order => 10;
    }
}