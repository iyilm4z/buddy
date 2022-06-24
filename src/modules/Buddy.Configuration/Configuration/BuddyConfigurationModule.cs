using System;
using Buddy.EntityFrameworkCore;
using Buddy.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Configuration;

[DependsOn(
    typeof(BuddyEntityFrameworkCoreModule)
)]
public class BuddyConfigurationModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
    }

    public override void Configure(IServiceProvider serviceProvider)
    {
    }
}