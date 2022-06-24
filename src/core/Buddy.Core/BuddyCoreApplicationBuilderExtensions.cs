using System;
using Buddy.Dependency;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy;

public static class BuddyCoreApplicationBuilderExtensions
{
    public static void UseBuddy(this IServiceProvider serviceProvider)
    {
        // set service provider for service locator
        // force to keep this code at the beginning of this method
        BuddyServiceLocator.Instance.SetServiceProvider(serviceProvider);

        var buddyApp = serviceProvider.GetRequiredService<BuddyApplication>();
        buddyApp.InitModules(serviceProvider);
    }
}