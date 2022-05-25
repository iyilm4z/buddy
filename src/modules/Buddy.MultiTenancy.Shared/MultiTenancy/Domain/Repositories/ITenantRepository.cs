using Buddy.Domain.Repositories;
using Buddy.MultiTenancy.Domain.Entities;

namespace Buddy.MultiTenancy.Domain.Repositories;

public interface ITenantRepository : IRepository<Tenant>
{
}