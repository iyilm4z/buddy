using System.Security.Claims;

namespace Buddy.Runtime.Security;

public static class BuddyClaimTypes
{
    public static string UserId => ClaimTypes.NameIdentifier;
}