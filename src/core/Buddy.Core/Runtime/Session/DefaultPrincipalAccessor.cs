using System.Security.Claims;
using System.Threading;
using Buddy.Dependency;

namespace Buddy.Runtime.Session;

public class DefaultPrincipalAccessor : IPrincipalAccessor, ISingletonDependency
{
    public virtual ClaimsPrincipal Principal => Thread.CurrentPrincipal as ClaimsPrincipal;

    public static DefaultPrincipalAccessor Instance => new();
}