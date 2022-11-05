namespace Buddy.Users.Configurations;

public class UserSettings
{
    public const int FailedPasswordAllowedAttempts = 10;

    public const int FailedPasswordLockoutMinutes = 10;

    public const string HashedPasswordFormat = "SHA1";
}