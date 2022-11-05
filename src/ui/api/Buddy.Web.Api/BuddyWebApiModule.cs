using System;
using System.Text;
using Buddy.EntityFrameworkCore;
using Buddy.Modularity;
using Buddy.Web.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Buddy.Web;

[DependsOn(
    typeof(BuddyWebApiCoreModule)
)]
public class BuddyWebApiModule : BuddyModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        // TODO remove this line
        var serviceProvider = services.BuildServiceProvider();

        var env = serviceProvider.GetService<IWebHostEnvironment>();
        var configuration = serviceProvider.GetService<IConfiguration>();

        services.AddDbContext<BuddyDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddMvc();
        services.AddSwaggerGen();

        var jwtTokenAuthConfig = configuration.GetSection(JwtTokenAuthenticationConfig.ConfigKey)
            .Get<JwtTokenAuthenticationConfig>();

        services.AddSingleton(jwtTokenAuthConfig);

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = true;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtTokenAuthConfig.Issuer,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenAuthConfig.Secret)),
                ValidAudience = jwtTokenAuthConfig.Audience,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(1)
            };
        });
    }

    public override void Configure(IServiceProvider serviceProvider)
    {
        var app = serviceProvider.GetRequiredApplicationBuilder();
        var env = serviceProvider.GetRequiredWebHostEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
            endpoints.MapControllers();
        });
    }
}