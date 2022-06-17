using Autofac.Extensions.DependencyInjection;
using Buddy;
using Buddy.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddBuddy<BuddyWebApiModule>();

var app = builder.Build();

app.UseBuddy();

app.Run();