using System.Threading.Tasks;
using Buddy.Account.Application.Dto;
using Buddy.Dependency;

namespace Buddy.Account.Application;

public class JwtTokenAuthenticationManager : ITokenAuthenticationManager, ITransientDependency
{
    public Task Authenticate(AuthenticateUserDto dto)
    {
        throw new System.NotImplementedException();
    }

    public Task Refresh(RefreshAuthenticatedUserDto dto)
    {
        throw new System.NotImplementedException();
    }
}