using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Buddy.Domain.Entities;

namespace Buddy.Users.Domain.Entities;

[Serializable]
public class User : AggregateRoot, IUser
{
    private ICollection<UserRoleMapping> _userRoleMappings;
    private ICollection<UserPassword> _userPasswords;

    public User()
    {
        UserGuid = Guid.NewGuid();
    }

    public Guid UserGuid { get; set; }

    [MaxLength(UserConsts.UsernameMaxLength)]
    public string Username { get; set; }

    [MaxLength(UserConsts.EmailMaxLength)] public string Email { get; set; }

    [MaxLength(UserConsts.EmailToRevalidateMaxLength)]
    public string EmailToRevalidate { get; set; }

    public string AdminComment { get; set; }

    public bool RequireReLogin { get; set; }

    public int FailedLoginAttempts { get; set; }

    public DateTime? CannotLoginUntilDateUtc { get; set; }

    public bool Active { get; set; }

    public bool Deleted { get; set; }

    public bool IsSystemAccount { get; set; }

    [MaxLength(UserConsts.SystemNameMaxLength)]
    public string SystemName { get; set; }

    public string LastIpAddress { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? LastLoginDateUtc { get; set; }

    public DateTime LastActivityDateUtc { get; set; }

    #region Navigation properties

    public virtual ICollection<UserRoleMapping> Roles
    {
        get => _userRoleMappings ??= new List<UserRoleMapping>();
        protected set => _userRoleMappings = value;
    }

    public ICollection<UserPassword> Passwords  {
        get => _userPasswords ??= new List<UserPassword>();
        protected set => _userPasswords = value;
    }

    #endregion

    #region Methods

    public void AddUserRoleMapping(UserRoleMapping role)
    {
        Roles.Add(role);
    }

    public void RemoveUserRoleMapping(UserRoleMapping role)
    {
        Roles.Remove(role);
    }

    #endregion
}