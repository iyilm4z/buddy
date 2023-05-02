using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Buddy.Domain.Entities;

namespace Buddy.Users.Domain.Entities;

[Serializable]
public class Role : AggregateRoot
{
    private ICollection<RolePermissionRecordMapping> _rolePermissionRecordMappings;

    private Role()
    {
    }

    public Role(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    [Required]
    [MaxLength(RoleConsts.NameMaxLength)]
    public string Name { get; private set; }

    public bool Active { get; set; }

    public bool IsSystemRole { get; set; }

    [MaxLength(RoleConsts.SystemNameMaxLength)]
    public string SystemName { get; set; }

    public bool EnablePasswordLifetime { get; set; }

    public virtual ICollection<RolePermissionRecordMapping> PermissionRecords
    {
        get => _rolePermissionRecordMappings ??= new List<RolePermissionRecordMapping>();
        protected set => _rolePermissionRecordMappings = value;
    }
}