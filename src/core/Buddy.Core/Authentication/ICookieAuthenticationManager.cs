using System.Threading.Tasks;
using Buddy.Users.Domain.Entities;

namespace Buddy.Authentication;

public interface ICookieAuthenticationManager
{
    Task SignInAsync(IUser user, bool isPersistent);

    Task SignOutAsync();
}