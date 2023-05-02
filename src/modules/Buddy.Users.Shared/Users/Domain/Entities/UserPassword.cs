using System;
using Buddy.Domain.Entities;

namespace Buddy.Users.Domain.Entities;

[Serializable]
public class UserPassword : Entity
{
    public UserPassword()
    {
        PasswordFormat = PasswordFormat.Clear;
    }

    public int UserId { get; set; }

    public string Password { get; set; }

    public int PasswordFormatId { get; set; }

    public string PasswordSalt { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public PasswordFormat PasswordFormat
    {
        get => (PasswordFormat)PasswordFormatId;
        set => PasswordFormatId = (int)value;
    }
}