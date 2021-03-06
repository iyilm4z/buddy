using Autofac;
using Buddy.Configuration;
using Buddy.Reflection;

namespace Buddy.Dependency
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder, ITypeFinder typeFinder, BuddyConfig config);

        int Order { get; }
    }
}