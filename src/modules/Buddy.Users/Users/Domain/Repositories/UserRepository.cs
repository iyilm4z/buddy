using Buddy.Domain.Repositories;
using Buddy.Users.Domain.Entities;

namespace Buddy.Users.Domain.Repositories;

public class UserRepository : EfCoreRepository<User>, IUserRepository
{
}