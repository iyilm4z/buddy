using Buddy.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buddy.EntityFrameworkCore;

public class BuddyDbContext : DbContext,
    IUsersDbContext
{
    public BuddyDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureUsers<BuddyDbContext>();
    }

    // Users
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserUserRoleMapping> UserUserRoleMappings { get; set; }
    public DbSet<UserPassword> UserPasswords { get; set; }
    public DbSet<PermissionRecord> PermissionRecords { get; set; }
    public DbSet<PermissionRecordUserRoleMapping> PermissionRecordUserRoleMappings { get; set; }
}