using Autofac.Extensions.DependencyInjection;
using Buddy;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddBuddy<BuddyUIMvcRazorPagesModule>();

var app = builder.Build();

app.UseBuddy();

app.Run();