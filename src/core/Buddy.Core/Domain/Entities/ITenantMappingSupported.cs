namespace Buddy.Domain.Entities;

public interface ITenantMappingSupported
{
    public bool LimitedToTenants { get; set; }
}