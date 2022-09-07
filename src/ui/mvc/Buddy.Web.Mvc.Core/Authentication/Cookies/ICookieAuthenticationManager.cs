using System.Threading.Tasks;
using Buddy.Users.Domain.Entities;

namespace Buddy.Web.Authentication.Cookies;

public interface ICookieAuthenticationManager
{
    Task SignInAsync(IUser user, bool isPersistent);

    Task SignOutAsync();
}