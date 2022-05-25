using Buddy.Domain.Entities;

namespace Buddy.Configuration.Domain.Entities;

public class Setting : Entity, ILocalizedEntity
{
    public Setting()
    {
    }

    public Setting(string name, string value, int tenantId = 0)
    {
        Name = name;
        Value = value;
        TenantId = tenantId;
    }

    public string Name { get; set; }

    public string Value { get; set; }

    public int TenantId { get; set; }

    public override string ToString()
    {
        return Name;
    }
}