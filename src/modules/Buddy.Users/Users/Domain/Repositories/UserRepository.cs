using Buddy.Domain.Repositories;
using Buddy.EntityFrameworkCore;
using Buddy.Users.Domain.Entities;

namespace Buddy.Users.Domain.Repositories;

public class UserRepository : EfCoreRepository<User>, IUserRepository
{
    public User GetByUsername(string username)
    {
        return FirstOrDefault(x => x.Username == username);
    }

    public UserRepository(BuddyDbContext dbContext) : base(dbContext)
    {
    }
}