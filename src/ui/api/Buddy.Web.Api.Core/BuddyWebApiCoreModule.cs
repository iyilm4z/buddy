﻿using Buddy.Modularity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Web;

[DependsOn(
    typeof(BuddyWebCoreModule)
)]
public class BuddyWebApiCoreModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
    }

    public override void Configure(IApplicationBuilder app)
    {
    }
}