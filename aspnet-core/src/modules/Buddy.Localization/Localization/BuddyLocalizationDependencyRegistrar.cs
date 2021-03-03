using Autofac;
using Buddy.Dependency;

namespace Buddy.Localization
{
    public class BuddyLocalizationDependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            throw new System.NotImplementedException();
        }

        public int Order => 30;
    }
}
