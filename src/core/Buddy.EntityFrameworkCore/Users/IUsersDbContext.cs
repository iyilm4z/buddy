using Buddy.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buddy.Users;

public interface IUsersDbContext
{
    DbSet<User> Users { get; set; }

    DbSet<UserRole> UserRoles { get; set; }

    DbSet<UserUserRoleMapping> UserUserRoleMappings { get; set; }

    DbSet<UserPassword> UserPasswords { get; set; }

    DbSet<PermissionRecord> PermissionRecords { get; set; }

    DbSet<PermissionRecordUserRoleMapping> PermissionRecordUserRoleMappings { get; set; }
}