using Buddy.Localization.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buddy.EntityFrameworkCore
{
    public class BuddyDbContext : DbContext, ILocalizationDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureLocalization<BuddyDbContext>();
        }

        public DbSet<Language> Languages { get; set; }

        public DbSet<LanguageText> LanguageTexts { get; set; }
    }
}
