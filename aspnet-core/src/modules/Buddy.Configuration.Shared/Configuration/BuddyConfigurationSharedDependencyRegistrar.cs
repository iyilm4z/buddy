﻿using Autofac;
using Buddy.Dependency;
using Buddy.Reflection;

namespace Buddy.Configuration
{
    public class BuddyConfigurationSharedDependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, BuddyConfig config)
        {
        }

        public int Order => 10;
    }
}