namespace Buddy.Users.Domain.Services;

public enum UserLoginResult
{
    Successful = 1,
    NotExist = 2,
    WrongPassword = 3,
    LockedOut = 4,
    Deleted = 5,
    NotActive = 6
}