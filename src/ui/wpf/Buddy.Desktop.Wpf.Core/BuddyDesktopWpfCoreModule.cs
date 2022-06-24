using System;
using Buddy.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Desktop;

[DependsOn(
    typeof(BuddyCoreModule)
)]
public class BuddyDesktopWpfCoreModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
    }

    public override void Configure(IServiceProvider serviceProvider)
    {
    }
}