using System;
using Buddy.EntityFrameworkCore;
using Buddy.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Users;

[DependsOn(
    typeof(BuddyEntityFrameworkCoreModule)
)]
public class BuddyUsersModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
    }

    public override void Configure(IServiceProvider serviceProvider)
    {
    }
}