using Buddy.Domain.Entities;

namespace Buddy.Localization.Domain.Entities;

public class LocalizedProperty : Entity
{
    public int EntityId { get; set; }

    public int LanguageId { get; set; }

    public string LocaleKeyGroup { get; set; }

    public string LocaleKey { get; set; }

    public string LocaleValue { get; set; }

    public virtual Language Language { get; set; }
}