using Buddy.Engine;
using Microsoft.AspNetCore.Builder;

namespace Buddy.Web
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureRequestPipeline(this IApplicationBuilder application)
        {
            EngineContext.Current.ConfigureRequestPipeline(application);
        }
    }
}