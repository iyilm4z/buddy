using Buddy.MultiTenancy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buddy.EntityFrameworkCore
{
    public interface IMultiTenancyDbContext
    {
        DbSet<Tenant> Tenants { get; set; }

        DbSet<TenantMapping> TenantMappings { get; set; }
    }
}