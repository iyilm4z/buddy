using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Buddy.Web.Authentication.JwtBearer;

public class ClearExpiredRefreshTokensJob : IHostedService, IDisposable
{
    private Timer _timer;

    public Task StartAsync(CancellationToken stoppingToken)
    {
        // remove expired refresh tokens from cache every minute
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

        return Task.CompletedTask;
    }

    private void DoWork(object state)
    {
        // RemoveExpiredRefreshTokens(DateTime.Now);
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