using Buddy.Domain.Repositories;
using Buddy.Logging.Domain.Entities;
using Buddy.Logging.Domain.Repositories;

namespace Buddy.Logging.Repositories
{
    public class LogRepository : EfCoreRepository<Log>, ILogRepository
    {
    }
}