using Buddy.Domain.Repositories;
using Buddy.MultiTenancy.Domain.Entities;

namespace Buddy.MultiTenancy.Domain.Repositories
{
    public class TenantRepository : EfCoreRepository<Tenant>, ITenantRepository
    {
    }
}