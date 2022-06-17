namespace Buddy.Users.Domain.Entities;

public interface IUser
{
    public static string UserTableName => "User";

    string Username { get; set; }

    string Email { get; set; }
}