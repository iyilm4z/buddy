namespace Buddy.Runtime.Session;

public abstract class BuddySessionBase : IBuddySession
{
    public abstract int? UserId { get; }
}