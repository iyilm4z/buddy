using Autofac.Extensions.DependencyInjection;
using Buddy;
using Buddy.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddBuddy<BuddyWebMvcModule>();

var app = builder.Build();

app.UseBuddy();

app.Run();