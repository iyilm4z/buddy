using System;
using System.Collections.Generic;
using Autofac;
using Buddy.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Engine
{
    public interface IEngine
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration, BuddyConfig buddyConfig);

        void ConfigureRequestPipeline(IApplicationBuilder application);

        T Resolve<T>() where T : class;

        object Resolve(Type type);

        IEnumerable<T> ResolveAll<T>();

        object ResolveUnregistered(Type type);

        void RegisterDependencies(ContainerBuilder containerBuilder, BuddyConfig buddyConfig);
    }
}