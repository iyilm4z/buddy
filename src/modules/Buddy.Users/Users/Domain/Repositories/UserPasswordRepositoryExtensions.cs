using System.Threading.Tasks;
using Buddy.Domain.Repositories;
using Buddy.Users.Domain.Entities;

namespace Buddy.Users.Domain.Repositories;

public static class UserPasswordRepositoryExtensions
{
    public static async Task<UserPassword> GetCurrentPasswordAsync(this IRepository<UserPassword> repository, int userId)
    {
        return await repository.FirstOrDefaultAsync(x => x.UserId == userId);
    }
}