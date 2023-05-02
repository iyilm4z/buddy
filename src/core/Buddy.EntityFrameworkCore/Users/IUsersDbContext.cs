using Buddy.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buddy.Users;

public interface IUsersDbContext
{
    DbSet<User> Users { get; set; }

    DbSet<Role> Roles { get; set; }

    DbSet<UserRoleMapping> UserUserRoleMappings { get; set; }

    DbSet<UserPassword> UserPasswords { get; set; }

    DbSet<PermissionRecord> PermissionRecords { get; set; }

    DbSet<RolePermissionRecordMapping> PermissionRecordUserRoleMappings { get; set; }
}