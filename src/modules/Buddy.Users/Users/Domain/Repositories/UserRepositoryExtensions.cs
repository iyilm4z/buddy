using System.Threading.Tasks;
using Buddy.Domain.Repositories;
using Buddy.Users.Domain.Entities;

namespace Buddy.Users.Domain.Repositories;

public static class UserRepositoryExtensions
{
    public static async Task<User> GetByUsernameAsync(this IRepository<User> repository, string username)
    {
        return await repository.FirstOrDefaultAsync(x => x.Username == username);
    }
}