using Buddy.Domain.Entities;

namespace Buddy.Localization.Domain.Entities;

public class Language : Entity, ITenantMappingSupported
{
    public string Name { get; set; }

    public string LanguageCulture { get; set; }

    public string UniqueSeoCode { get; set; }

    public string FlagImageFileName { get; set; }

    public bool Rtl { get; set; }

    public bool Published { get; set; }

    public int DisplayOrder { get; set; }

    public bool LimitedToTenants { get; set; }
}