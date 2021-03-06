using System;
using Autofac;
using Buddy.Configuration;
using Buddy.Dependency;
using Buddy.Reflection;

namespace Buddy.Users
{
    public class BuddyUsersDependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, BuddyConfig config)
        {
            throw new NotImplementedException();
        }

        public int Order => 10;
    }
}