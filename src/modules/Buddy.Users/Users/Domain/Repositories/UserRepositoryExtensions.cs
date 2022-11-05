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

    public static async Task<User> GetByEmailAsync(this IRepository<User> repository, string email)
    {
        return await repository.FirstOrDefaultAsync(x => x.Email == email);
    }
}