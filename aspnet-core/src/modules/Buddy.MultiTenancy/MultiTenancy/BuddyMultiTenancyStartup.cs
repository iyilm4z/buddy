using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.MultiTenancy
{
    public class BuddyMultiTenancyStartup : IBuddyStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
        }

        public int Order => 10;
    }
}