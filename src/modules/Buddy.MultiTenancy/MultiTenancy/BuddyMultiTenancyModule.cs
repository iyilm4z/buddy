using System;
using Buddy.EntityFrameworkCore;
using Buddy.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.MultiTenancy;

[DependsOn(
    typeof(BuddyEntityFrameworkCoreModule)
)]
public class BuddyMultiTenancyModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
    }

    public override void Configure(IServiceProvider serviceProvider)
    {
    }
}