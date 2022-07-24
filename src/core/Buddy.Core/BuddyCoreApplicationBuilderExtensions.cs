using System;
using System.Linq;
using AutoMapper;
using Buddy.Dependency;
using Buddy.ObjectMapping;
using Buddy.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy;

public static class BuddyCoreApplicationBuilderExtensions
{
    public static void UseBuddy(this IServiceProvider serviceProvider)
    {
        var buddyApp = serviceProvider.GetRequiredService<BuddyApplication>();
        buddyApp.InitModules(serviceProvider);
    }

    public static void AddAutoMapper(this IServiceProvider serviceProvider)
    {
        var typeFinder = serviceProvider.GetTypeFinder();
        var mapperConfigurations = typeFinder.FindClassesOfType<IOrderedMapperProfile>();

        var instances = mapperConfigurations
            .Select(mapperConfiguration => (IOrderedMapperProfile)Activator.CreateInstance(mapperConfiguration))
            .OrderBy(mapperConfiguration => mapperConfiguration.Order);

        var config = new MapperConfiguration(cfg =>
        {
            foreach (var instance in instances)
            {
                cfg.AddProfile(instance.GetType());
            }
        });

        AutoMapperConfiguration.Init(config);
    }

    public static void RunStartupTasks(this IServiceProvider serviceProvider)
    {
        var typeFinder = serviceProvider.GetTypeFinder();
        var startupTasks = typeFinder.FindClassesOfType<IStartupTask>();

        var instances = startupTasks
            .Select(startupTask => (IStartupTask)Activator.CreateInstance(startupTask))
            .OrderBy(startupTask => startupTask.Order);

        foreach (var task in instances)
        {
            task.Execute();
        }
    }
}