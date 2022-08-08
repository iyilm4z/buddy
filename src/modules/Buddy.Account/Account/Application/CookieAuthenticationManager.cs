using System.Threading.Tasks;
using Buddy.Account.Application.Dto;
using Buddy.Dependency;

namespace Buddy.Account.Application;

public class CookieAuthenticationManager : ICookieAuthenticationManager, ITransientDependency
{
    public Task SignIn(string usernameOrEmail, string password, bool rememberMe)
    {
        throw new System.NotImplementedException();
    }

    public Task SignIn(SignInDto dto)
    {
        throw new System.NotImplementedException();
    }

    public Task SignOut()
    {
        throw new System.NotImplementedException();
    }
}