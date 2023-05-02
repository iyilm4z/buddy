using System;
using Buddy.Domain.Entities;

namespace Buddy.Users.Domain.Entities;

[Serializable]
public class UserRoleMapping : Entity
{
    private UserRoleMapping()
    {
    }

    public UserRoleMapping(int userId, int roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }

    public int UserId { get; private set; }

    public int RoleId { get; private set; }
}