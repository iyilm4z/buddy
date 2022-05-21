using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Linq;

namespace Buddy.Web
{
    public static class ServiceCollectionExtensions
    {
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