using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy
{
    public interface IBuddyStartup
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);

        void Configure(IApplicationBuilder app);

        int Order { get; }
    }
}