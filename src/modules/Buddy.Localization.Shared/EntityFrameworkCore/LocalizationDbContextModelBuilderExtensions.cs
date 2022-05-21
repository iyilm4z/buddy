using Buddy.Localization.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buddy.EntityFrameworkCore
{
    public static class LocalizationDbContextModelBuilderExtensions
    {
        // ReSharper disable once UnusedTypeParameter
        public static void ConfigureLocalization<TDbContext>(this ModelBuilder builder)
            where TDbContext : ILocalizationDbContext
        {
            builder.ConfigureLanguageEntity();
            builder.ConfigureLocaleStringResourceEntity();
            builder.ConfigureLocalizedPropertyEntity();
        }

        private static void ConfigureLanguageEntity(this ModelBuilder builder)
        {
            builder.Entity<Language>(b =>
            {
                b.ToTable(nameof(Language));
                b.HasKey(language => language.Id);

                b.Property(language => language.Name).HasMaxLength(100).IsRequired();
                b.Property(language => language.LanguageCulture).HasMaxLength(20).IsRequired();
                b.Property(language => language.UniqueSeoCode).HasMaxLength(2);
                b.Property(language => language.FlagImageFileName).HasMaxLength(50);
            });
        }

        private static void ConfigureLocaleStringResourceEntity(this ModelBuilder builder)
        {
            builder.Entity<LocaleStringResource>(b =>
            {
                b.ToTable(nameof(LocaleStringResource));
                b.HasKey(locale => locale.Id);

                b.Property(locale => locale.ResourceName).HasMaxLength(200).IsRequired();
                b.Property(locale => locale.ResourceValue).IsRequired();

                b.HasOne(locale => locale.Language)
                    .WithMany()
                    .HasForeignKey(locale => locale.LanguageId)
                    .IsRequired();
            });
        }

        private static void ConfigureLocalizedPropertyEntity(this ModelBuilder builder)
        {
            builder.Entity<LocalizedProperty>(b =>
            {
                b.ToTable(nameof(LocalizedProperty));
                b.HasKey(property => property.Id);

                b.Property(property => property.LocaleKeyGroup).HasMaxLength(400).IsRequired();
                b.Property(property => property.LocaleKey).HasMaxLength(400).IsRequired();
                b.Property(property => property.LocaleValue).IsRequired();

                b.HasOne(property => property.Language)
                    .WithMany()
                    .HasForeignKey(property => property.LanguageId)
                    .IsRequired();
            });
        }
    }
}