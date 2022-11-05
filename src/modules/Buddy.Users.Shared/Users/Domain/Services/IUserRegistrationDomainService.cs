using System.Threading.Tasks;
using Buddy.Domain.Services;

namespace Buddy.Users.Domain.Services;

public interface IUserRegistrationDomainService : IDomainService
{
    Task<UserLoginResult> ValidateUserAsync(string usernameOrEmail, string password);
}