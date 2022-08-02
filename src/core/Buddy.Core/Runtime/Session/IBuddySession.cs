namespace Buddy.Runtime.Session;

public interface IBuddySession
{
    /// <summary>
    /// Gets current UserId or null.
    /// It can be null if no user logged in.
    /// </summary>
    int? UserId { get; }
}