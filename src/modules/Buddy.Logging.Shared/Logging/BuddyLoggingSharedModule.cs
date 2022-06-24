using System;
using Buddy.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Logging;

[DependsOn(
    typeof(BuddyCoreModule)
)]
public class BuddyLoggingSharedModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
    }

    public override void Configure(IServiceProvider serviceProvider)
    {
    }
}