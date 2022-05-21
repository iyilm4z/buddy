using System;
using System.Collections.Generic;
using Buddy.Modularity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy
{
    public class BuddyApplication : IBuddyModuleContainer
    {
        private readonly IServiceCollection _services;
        private readonly Type _startupModuleType;

        public IReadOnlyList<BuddyModuleInfo> Modules { get; private set; }

        public BuddyApplication(Type startupModuleType, IServiceCollection services)
        {
            _startupModuleType = startupModuleType ?? throw new ArgumentNullException(nameof(startupModuleType));
            _services = services ?? throw new ArgumentNullException(nameof(services));

            services.AddSingleton(this);
            services.AddSingleton<IBuddyModuleContainer>(this);
            services.AddCoreModuleServices(this);
        }

        public void LoadModules()
        {
            Modules = BuddyModuleLoader.LoadModules(_services, _startupModuleType);

            foreach (var module in Modules)
            {
                module.Instance.ConfigureServices(_services);
            }
        }

        public void InitModules(IApplicationBuilder app)
        {
            foreach (var module in Modules)
            {
                module.Instance.Configure(app);
            }
        }
    }
}