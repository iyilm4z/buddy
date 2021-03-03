using Buddy.Localization.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buddy.EntityFrameworkCore
{
    public static class LocalizationDbContextModelBuilderExtensions
    {
        public static void ConfigureLocalization<TDbContext>(this ModelBuilder builder)
            where TDbContext : ILocalizationDbContext
        {
            builder.Entity<Language>(b =>
            {

            });

            builder.Entity<LanguageText>(b =>
            {

            });
        }
    }
}
