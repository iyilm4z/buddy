using Autofac;

namespace Buddy.Dependency
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder);

        public int Order { get; }
    }
}
