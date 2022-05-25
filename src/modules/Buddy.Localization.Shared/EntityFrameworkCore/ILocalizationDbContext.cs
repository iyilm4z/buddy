using Buddy.Localization.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buddy.EntityFrameworkCore;

public interface ILocalizationDbContext
{
    DbSet<Language> Languages { get; set; }

    DbSet<LocaleStringResource> LocaleStringResources { get; set; }

    DbSet<LocalizedProperty> LocalizedProperties { get; set; }
}