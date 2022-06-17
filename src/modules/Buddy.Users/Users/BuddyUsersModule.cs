using Buddy.EntityFrameworkCore;
using Buddy.Modularity;
using Microsoft.AspNetCore.Builder;
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

    public override void Configure(IApplicationBuilder app)
    {
    }
}