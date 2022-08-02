namespace Buddy.Runtime.Session;

public class NullBuddySession : BuddySessionBase
{
    public static NullBuddySession Instance => SingletonInstance;

    private static readonly NullBuddySession SingletonInstance = new();

    public override int? UserId => null;

    private NullBuddySession()
    {
    }
}