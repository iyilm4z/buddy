using System.Threading.Tasks;
using Buddy.Account.Application.Dto;

namespace Buddy.Account.Application;

public interface ITokenAuthenticationManager
{
    Task Authenticate(AuthenticateUserDto dto);
    
    
    Task Refresh(RefreshAuthenticatedUserDto dto);
}