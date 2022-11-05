using System.Threading.Tasks;
using Buddy.Domain.Services;

namespace Buddy.Users.Domain.Services;

public interface IUserDomainService : IDomainService
{
    Task<UserLoginResult> CheckUserLoginAsync(string usernameOrEmail, string password);
}