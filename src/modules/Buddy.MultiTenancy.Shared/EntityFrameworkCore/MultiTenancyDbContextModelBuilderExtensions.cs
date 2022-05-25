using Buddy.MultiTenancy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buddy.EntityFrameworkCore;

public static class MultiTenancyDbContextModelBuilderExtensions
{
    // ReSharper disable once UnusedTypeParameter
    public static void ConfigureMultiTenancy<TDbContext>(this ModelBuilder builder)
        where TDbContext : IMultiTenancyDbContext
    {
        builder.ConfigureTenantEntity();
        builder.ConfigureTenantMappingEntity();
    }

    private static void ConfigureTenantEntity(this ModelBuilder builder)
    {
        builder.Entity<Tenant>(b =>
        {
            b.ToTable(nameof(Tenant));
            b.HasKey(tenant => tenant.Id);

            b.Property(tenant => tenant.Name).HasMaxLength(400).IsRequired();
            b.Property(tenant => tenant.Url).HasMaxLength(400).IsRequired();
            b.Property(tenant => tenant.Hosts).HasMaxLength(1000);
        });
    }

    private static void ConfigureTenantMappingEntity(this ModelBuilder builder)
    {
        builder.Entity<TenantMapping>(b =>
        {
            b.ToTable(nameof(TenantMapping));
            b.HasKey(tenantMapping => tenantMapping.Id);

            b.Property(tenantMapping => tenantMapping.EntityName).HasMaxLength(400).IsRequired();

            b.HasOne(tenantMapping => tenantMapping.Tenant)
                .WithMany()
                .HasForeignKey(tenantMapping => tenantMapping.TenantId)
                .IsRequired();
        });
    }
}