using System;
using Buddy.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.MultiTenancy;

[DependsOn(
    typeof(BuddyCoreModule)
)]
public class BuddyMultiTenancySharedModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
    }

    public override void Configure(IServiceProvider serviceProvider)
    {
    }
}