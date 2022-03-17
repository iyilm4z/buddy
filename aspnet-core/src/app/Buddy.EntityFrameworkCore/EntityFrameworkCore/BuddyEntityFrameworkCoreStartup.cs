using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.EntityFrameworkCore
{
    public class BuddyEntityFrameworkCoreStartup : IBuddyStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
        }

        public int Order => 20;
    }
}