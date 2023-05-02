namespace Buddy.Users.Domain.Entities;

public interface IUser
{
    public const string UserTableName = "User";

    int Id { get; }

    string Username { get; set; }

    string Email { get; set; }
}