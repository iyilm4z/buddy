using System.Threading.Tasks;
using Buddy.Account.Application.Dto;

namespace Buddy.Account.Application;

public interface ICookieAuthenticationManager
{
    Task SignIn(string usernameOrEmail, string password, bool rememberMe);

    Task SignIn(SignInDto dto);

    Task SignOut();
}