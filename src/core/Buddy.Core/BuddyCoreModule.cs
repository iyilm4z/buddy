using System;
using Buddy.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy;

public class BuddyCoreModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.RegisterConventionalDependencies();
    }

    public override void Configure(IServiceProvider serviceProvider)
    {
        serviceProvider.AddAutoMapper();
        serviceProvider.RunStartupTasks();
    }
}