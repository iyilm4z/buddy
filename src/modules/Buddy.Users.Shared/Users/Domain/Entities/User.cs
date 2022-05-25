using System;
using System.Collections.Generic;
using System.Linq;
using Buddy.Domain.Entities;

namespace Buddy.Users.Domain.Entities;

public class User : Entity, IUser
{
    private IList<UserRole> _userRoles;
    private ICollection<UserUserRoleMapping> _userUserRoleMappings;

    public User()
    {
        UserGuid = Guid.NewGuid();
    }

    public Guid UserGuid { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public string EmailToRevalidate { get; set; }

    public string AdminComment { get; set; }

    public bool RequireReLogin { get; set; }

    public int FailedLoginAttempts { get; set; }

    public DateTime? CannotLoginUntilDateUtc { get; set; }

    public bool Active { get; set; }

    public bool Deleted { get; set; }

    public bool IsSystemAccount { get; set; }

    public string SystemName { get; set; }

    public string LastIpAddress { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? LastLoginDateUtc { get; set; }

    public DateTime LastActivityDateUtc { get; set; }

    #region Navigation properties

    public virtual IList<UserRole> UserRoles => _userRoles ??= UserUserRoleMappings
        .Select(mapping => mapping.UserRole)
        .ToList();

    public virtual ICollection<UserUserRoleMapping> UserUserRoleMappings
    {
        get => _userUserRoleMappings ??= new List<UserUserRoleMapping>();
        protected set => _userUserRoleMappings = value;
    }

    #endregion

    #region Methods

    public void AddUserRoleMapping(UserUserRoleMapping role)
    {
        UserUserRoleMappings.Add(role);
        _userRoles = null;
    }

    public void RemoveUserRoleMapping(UserUserRoleMapping role)
    {
        UserUserRoleMappings.Remove(role);
        _userRoles = null;
    }

    #endregion
}