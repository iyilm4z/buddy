using System.Collections.Generic;
using Buddy.Domain.Entities;

namespace Buddy.Users.Domain.Entities;

/// <summary>
///     Represents a permission record
/// </summary>
public class PermissionRecord : Entity
{
    private ICollection<PermissionRecordUserRoleMapping> _permissionRecordUserRoleMappings;

    /// <summary>
    ///     Gets or sets the permission name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the permission system name
    /// </summary>
    public string SystemName { get; set; }

    /// <summary>
    ///     Gets or sets the permission category
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    ///     Gets or sets the permission record-User role mappings
    /// </summary>
    public virtual ICollection<PermissionRecordUserRoleMapping> PermissionRecordUserRoleMappings
    {
        get => _permissionRecordUserRoleMappings ??= new List<PermissionRecordUserRoleMapping>();
        protected set => _permissionRecordUserRoleMappings = value;
    }
}