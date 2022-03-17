using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Linq;
using Buddy.Engine;
using Buddy.Reflection;
using Microsoft.AspNetCore.Builder;

namespace Buddy.Web
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            // register assembly provider
            var assemblyProvider = new BuddyAssemblyProvider();
            Singleton<IAssemblyProvider>.Instance = assemblyProvider;
            services.AddSingleton<IAssemblyProvider>(assemblyProvider);

            // register type finder
            var typeFinder = new BuddyTypeFinder(assemblyProvider);
            Singleton<ITypeFinder>.Instance = typeFinder;
            services.AddSingleton<ITypeFinder>(typeFinder);

            // create engine and configure service provider
            var engine = EngineContext.Create();

            engine.ConfigureServices(services, builder.Configuration);
        }

        public static IServiceCollection ConfigureBuddyModuleRazorRuntimeCompilation(this IServiceCollection services,
            IWebHostEnvironment hostEnvironment)
        {
            return services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
            {
                var moduleFolderPath =
                    Path.GetFullPath(Path.Combine(hostEnvironment.ContentRootPath, "..", "..", "modules"));
                var modulePaths = Directory.GetDirectories(moduleFolderPath)
                    .Where(dir => !dir.EndsWith(".Shared"))
                    .ToList();

                foreach (var modulePath in modulePaths)
                {
                    options.FileProviders.Add(new PhysicalFileProvider(modulePath));
                }
            });
        }
    }
}