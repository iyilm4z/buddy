using Buddy.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buddy.Users;

public static class UsersDbContextModelBuilderExtensions
{
    // ReSharper disable once UnusedTypeParameter
    public static void ConfigureUsers<TDbContext>(this ModelBuilder builder)
        where TDbContext : IUsersDbContext
    {
        builder.ConfigureUserEntity();
        builder.ConfigureRoleEntity();
        builder.ConfigureUserRoleMappingEntity();
        builder.ConfigureUserPasswordEntity();
        builder.ConfigurePermissionRecordEntity();
        builder.ConfigureRolePermissionRecordMappingEntity();
    }

    private static void ConfigureUserEntity(this ModelBuilder builder)
    {
        builder.Entity<User>(b =>
        {
            b.ToTable(IUser.UserTableName);
            b.HasKey(user => user.Id);

            b.Property(user => user.Username).HasColumnName(nameof(IUser.Username));
            b.Property(user => user.Email).HasColumnName(nameof(IUser.Email));
            b.Property(user => user.EmailToRevalidate);
            b.Property(user => user.SystemName);

            b.HasMany(x => x.Passwords)
                .WithOne()
                .HasForeignKey(password => password.UserId)
                .IsRequired();
        });
    }

    private static void ConfigureRoleEntity(this ModelBuilder builder)
    {
        builder.Entity<Role>(b =>
        {
            b.ToTable(nameof(Role));
            b.HasKey(role => role.Id);

            b.Property(role => role.Name);
            b.Property(role => role.SystemName);
        });
    }

    private static void ConfigureUserRoleMappingEntity(this ModelBuilder builder)
    {
        builder.Entity<UserRoleMapping>(b =>
        {
            b.ToTable($"{IUser.UserTableName}_{nameof(Role)}_Mapping");
            b.HasKey(mapping => new { mapping.UserId, UserRoleId = mapping.RoleId });

            b.Property(mapping => mapping.UserId).HasColumnName($"{IUser.UserTableName}_Id");
            b.Property(mapping => mapping.RoleId).HasColumnName($"{nameof(Role)}_Id");

            b.HasOne<User>()
                .WithMany(x => x.Roles)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            b.HasOne<Role>()
                .WithMany()
                .HasForeignKey(x => x.RoleId)
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

            b.Ignore(password => password.PasswordFormat);
        });
    }

    private static void ConfigurePermissionRecordEntity(this ModelBuilder builder)
    {
        builder.Entity<PermissionRecord>(b =>
        {
            b.ToTable(nameof(PermissionRecord));
            b.HasKey(record => record.Id);

            b.Property(record => record.Name);
            b.Property(record => record.SystemName);
            b.Property(record => record.Category);
        });
    }

    private static void ConfigureRolePermissionRecordMappingEntity(this ModelBuilder builder)
    {
        builder.Entity<RolePermissionRecordMapping>(b =>
        {
            b.ToTable($"{nameof(PermissionRecord)}_{nameof(Role)}_Mapping");
            b.HasKey(mapping => new { mapping.PermissionRecordId, UserRoleId = mapping.RoleId });

            b.Property(mapping => mapping.PermissionRecordId).HasColumnName($"{nameof(PermissionRecord)}_Id");
            b.Property(mapping => mapping.RoleId).HasColumnName($"{nameof(Role)}_Id");

            b.HasOne<Role>()
                .WithMany(x => x.PermissionRecords)
                .HasForeignKey(x => x.RoleId)
                .IsRequired();

            b.HasOne<PermissionRecord>()
                .WithMany()
                .HasForeignKey(x => x.PermissionRecordId)
                .IsRequired();

            b.Ignore(mapping => mapping.Id);
        });
    }
}