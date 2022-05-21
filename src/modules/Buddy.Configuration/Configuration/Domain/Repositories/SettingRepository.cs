using Buddy.Configuration.Domain.Entities;
using Buddy.Domain.Repositories;

namespace Buddy.Configuration.Domain.Repositories
{
    public class SettingRepository : EfCoreRepository<Setting>, ISettingRepository
    {
    }
}