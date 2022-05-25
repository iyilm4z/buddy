using Buddy.Configuration.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buddy.EntityFrameworkCore;

public static class ConfigurationDbContextModelBuilderExtensions
{
    // ReSharper disable once UnusedTypeParameter
    public static void ConfigureConfiguration<TDbContext>(this ModelBuilder builder)
        where TDbContext : IConfigurationDbContext
    {
        builder.ConfigureSettingEntity();
    }

    private static void ConfigureSettingEntity(this ModelBuilder builder)
    {
        builder.Entity<Setting>(b =>
        {
            b.ToTable(nameof(Setting));
            b.HasKey(setting => setting.Id);

            b.Property(setting => setting.Name).HasMaxLength(200).IsRequired();
            b.Property(setting => setting.Value).IsRequired();
        });
    }
}