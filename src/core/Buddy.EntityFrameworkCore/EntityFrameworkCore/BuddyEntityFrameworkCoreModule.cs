using System;
using Buddy.Domain.Repositories;
using Buddy.Modularity;
using Buddy.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.EntityFrameworkCore;

[DependsOn(
    typeof(BuddyUsersSharedModule)
)]
public class BuddyEntityFrameworkCoreModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<>), typeof(EfCoreRepository<>));
    }

    public override void Configure(IServiceProvider serviceProvider)
    {
    }
}