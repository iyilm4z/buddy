using Buddy.Localization.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buddy.EntityFrameworkCore
{
    public interface ILocalizationDbContext
    {
        DbSet<Language> Languages { get; set; }

        DbSet<LanguageText> LanguageTexts { get; set; }
    }
}