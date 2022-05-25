using Buddy.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buddy.EntityFrameworkCore;

public static class UsersDbContextModelBuilderExtensions
{
    // ReSharper disable once UnusedTypeParameter
    public static void ConfigureUsers<TDbContext>(this ModelBuilder builder)
        where TDbContext : IUsersDbContext
    {
        builder.ConfigureUserEntity();
        builder.ConfigureUserRoleEntity();
        builder.ConfigureUserUserRoleMappingEntity();
        builder.ConfigureUserPasswordEntity();
        builder.ConfigurePermissionRecordEntity();
        builder.ConfigurePermissionRecordUserRoleMappingEntity();
    }

    private static void ConfigureUserEntity(this ModelBuilder builder)
    {
        builder.Entity<User>(b =>
        {
            b.ToTable(IUser.UserTableName);
            b.HasKey(user => user.Id);

            b.Property(user => user.Username).HasMaxLength(1000).HasColumnName(nameof(IUser.Username));
            b.Property(user => user.Email).HasMaxLength(1000).HasColumnName(nameof(IUser.Email));
            b.Property(user => user.EmailToRevalidate).HasMaxLength(1000);
            b.Property(user => user.SystemName).HasMaxLength(400);

            b.Ignore(user => user.UserRoles);
        });
    }

    private static void ConfigureUserRoleEntity(this ModelBuilder builder)
    {
        builder.Entity<UserRole>(b =>
        {
            b.ToTable(nameof(UserRole));
            b.HasKey(role => role.Id);

            b.Property(role => role.Name).HasMaxLength(255).IsRequired();
            b.Property(role => role.SystemName).HasMaxLength(255);
        });
    }

    private static void ConfigureUserUserRoleMappingEntity(this ModelBuilder builder)
    {
        builder.Entity<UserUserRoleMapping>(b =>
        {
            b.ToTable($"{IUser.UserTableName}_{nameof(UserRole)}_Mapping");
            b.HasKey(mapping => new { mapping.UserId, mapping.UserRoleId });

            b.Property(mapping => mapping.UserId).HasColumnName($"{IUser.UserTableName}_Id");
            b.Property(mapping => mapping.UserRoleId).HasColumnName($"{nameof(UserRole)}_Id");

            b.HasOne(mapping => mapping.User)
                .WithMany(user => user.UserUserRoleMappings)
                .HasForeignKey(mapping => mapping.UserId)
                .IsRequired();

            b.HasOne(mapping => mapping.UserRole)
                .WithMany()
                .HasForeignKey(mapping => mapping.UserRoleId)
                .IsRequired();

            b.Ignore(mapping => mapping.Id);
        });
    }

    private static void ConfigureUserPasswordEntity(this ModelBuilder builder)
    {
        builder.Entity<UserPassword>(b =>
        {
            b.ToTable(nameof(UserPassword));
            b.HasKey(password => password.Id);

            b.HasOne(password => password.User)
                .WithMany()
                .HasForeignKey(password => password.UserId)
                .IsRequired();

            b.Ignore(password => password.PasswordFormat);
        });
    }

    private static void ConfigurePermissionRecordEntity(this ModelBuilder builder)
    {
        builder.Entity<PermissionRecord>(b =>
        {
            b.ToTable(nameof(PermissionRecord));
            b.HasKey(record => record.Id);

            b.Property(record => record.Name).IsRequired();
            b.Property(record => record.SystemName).HasMaxLength(255).IsRequired();
            b.Property(record => record.Category).HasMaxLength(255).IsRequired();
        });
    }

    private static void ConfigurePermissionRecordUserRoleMappingEntity(this ModelBuilder builder)
    {
        builder.Entity<PermissionRecordUserRoleMapping>(b =>
        {
            b.ToTable($"{nameof(PermissionRecord)}_{nameof(UserRole)}_Mapping");
            b.HasKey(mapping => new { mapping.PermissionRecordId, mapping.UserRoleId });

            b.Property(mapping => mapping.PermissionRecordId).HasColumnName($"{nameof(PermissionRecord)}_Id");
            b.Property(mapping => mapping.UserRoleId).HasColumnName($"{nameof(UserRole)}_Id");

            b.HasOne(mapping => mapping.UserRole)
                .WithMany(role => role.PermissionRecordUserRoleMappings)
                .HasForeignKey(mapping => mapping.UserRoleId)
                .IsRequired();

            b.HasOne(mapping => mapping.PermissionRecord)
                .WithMany(record => record.PermissionRecordUserRoleMappings)
                .HasForeignKey(mapping => mapping.PermissionRecordId)
                .IsRequired();

            b.Ignore(mapping => mapping.Id);
        });
    }
}