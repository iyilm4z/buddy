using Buddy.Logging.Domain;
using Buddy.Logging.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buddy.EntityFrameworkCore
{
    public interface ILoggingDbContext
    {
        DbSet<Log> Logs { get; set; }

        DbSet<ActivityLog> ActivityLogs { get; set; }

        DbSet<ActivityLogType> ActivityLogTypes { get; set; }
    }
}