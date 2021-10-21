using Buddy.EntityFrameworkCore;
using Buddy.Web.Mvc.Razor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Buddy.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            HostEnvironment = hostEnvironment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment HostEnvironment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BuddyDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();
            
            services.AddMvc()
                .AddRazorRuntimeCompilation();

            services.ConfigureBuddyModuleRazorRuntimeCompilation(HostEnvironment);

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new BuddyViewLocationExpander());
            });

            services.Configure<RazorPagesOptions>(options =>
            {
                options.RootDirectory = "/Web/Pages";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}