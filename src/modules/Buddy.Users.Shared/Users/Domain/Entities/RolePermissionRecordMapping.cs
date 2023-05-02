using System;
using Buddy.Domain.Entities;

namespace Buddy.Users.Domain.Entities;

[Serializable]
public class RolePermissionRecordMapping : Entity
{
    private RolePermissionRecordMapping()
    {
    }

    public RolePermissionRecordMapping(int permissionRecordId, int roleId)
    {
        PermissionRecordId = permissionRecordId;
        RoleId = roleId;
    }

    public int PermissionRecordId { get; private set; }

    public int RoleId { get; private set; }
}