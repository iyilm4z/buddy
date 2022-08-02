using System.Linq;
using Buddy.Dependency;
using Buddy.Runtime.Security;

namespace Buddy.Runtime.Session;

public class ClaimsBuddySession : BuddySessionBase, ISingletonDependency
{
    public override int? UserId
    {
        get
        {
            var userIdClaim = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == BuddyClaimTypes.UserId);
            if (string.IsNullOrEmpty(userIdClaim?.Value))
            {
                return null;
            }

            if (!int.TryParse(userIdClaim.Value, out var userId))
            {
                return null;
            }

            return userId;
        }
    }

    public IPrincipalAccessor PrincipalAccessor { get; }

    public ClaimsBuddySession(IPrincipalAccessor principalAccessor)
    {
        PrincipalAccessor = principalAccessor;
    }
}