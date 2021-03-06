using Buddy.Configuration.Domain.Entities;
using Buddy.Localization.Domain.Entities;
using Buddy.Logging.Domain;
using Buddy.Logging.Domain.Entities;
using Buddy.MultiTenancy.Domain.Entities;
using Buddy.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buddy.EntityFrameworkCore
{
    public class BuddyDbContext : DbContext,
        IConfigurationDbContext,
        ILocalizationDbContext,
        ILoggingDbContext,
        IMultiTenancyDbContext,
        IUsersDbContext
    {
        public DbSet<TenantMapping> TenantMappings { get; set; }

        // Configuration
        public DbSet<Setting> Settings { get; set; }

        // Localization
        public DbSet<Language> Languages { get; set; }
        public DbSet<LocaleStringResource> LocaleStringResources { get; set; }
        public DbSet<LocalizedProperty> LocalizedProperties { get; set; }

        // Logging
        public DbSet<Log> Logs { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<ActivityLogType> ActivityLogTypes { get; set; }

        // MultiTenancy
        public DbSet<Tenant> Tenants { get; set; }

        // Users
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserUserRoleMapping> UserUserRoleMappings { get; set; }
        public DbSet<UserPassword> UserPasswords { get; set; }
        public DbSet<PermissionRecord> PermissionRecords { get; set; }
        public DbSet<PermissionRecordUserRoleMapping> PermissionRecordUserRoleMappings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureConfiguration<BuddyDbContext>();
            modelBuilder.ConfigureLocalization<BuddyDbContext>();
            modelBuilder.ConfigureLogging<BuddyDbContext>();
            modelBuilder.ConfigureMultiTenancy<BuddyDbContext>();
            modelBuilder.ConfigureUsers<BuddyDbContext>();
        }
    }
}