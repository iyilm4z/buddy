using Buddy.Dependency;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseBuddy(this IApplicationBuilder app)
        {
            // set service provider for service locator
            // force to keep this code at the beginning of this method
            BuddyServiceLocator.Instance.SetServiceProvider(app.ApplicationServices);

            var buddyApp = app.ApplicationServices.GetRequiredService<BuddyApplication>();
            buddyApp.InitModules(app);

            return app;
        }
    }
}