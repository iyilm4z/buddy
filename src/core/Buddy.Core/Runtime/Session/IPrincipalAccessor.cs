using System.Security.Claims;

namespace Buddy.Runtime.Session;

public interface IPrincipalAccessor
{
    ClaimsPrincipal Principal { get; }
}