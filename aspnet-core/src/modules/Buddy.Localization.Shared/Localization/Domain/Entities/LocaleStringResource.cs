using Buddy.Domain.Entities;

namespace Buddy.Localization.Domain.Entities
{
    public class LocaleStringResource : Entity
    {
        public int LanguageId { get; set; }

        public string ResourceName { get; set; }

        public string ResourceValue { get; set; }

        public virtual Language Language { get; set; }
    }
}