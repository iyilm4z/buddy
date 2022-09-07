using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Buddy.Web.Authentication.JwtBearer;

public class JwtRefreshTokenCache : IHostedService, IDisposable
{
    private Timer _timer;
    private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

    public JwtRefreshTokenCache(IJwtAuthenticationManager jwtAuthenticationManager)
    {
        _jwtAuthenticationManager = jwtAuthenticationManager;
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        // remove expired refresh tokens from cache every minute
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

        return Task.CompletedTask;
    }

    private void DoWork(object state)
    {
        _jwtAuthenticationManager.RemoveExpiredRefreshTokens(DateTime.Now);
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}