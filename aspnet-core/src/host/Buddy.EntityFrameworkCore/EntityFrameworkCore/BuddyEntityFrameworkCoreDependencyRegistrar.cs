using Autofac;
using Buddy.Dependency;

namespace Buddy.EntityFrameworkCore
{
    public class BuddyEntityFrameworkCoreDependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
        }

        public int Order => 20;
    }
}