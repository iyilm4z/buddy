using System;
using Buddy.EntityFrameworkCore;
using Buddy.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Logging;

[DependsOn(
    typeof(BuddyEntityFrameworkCoreModule)
)]
public class BuddyLoggingModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
    }

    public override void Configure(IServiceProvider serviceProvider)
    {
    }
}