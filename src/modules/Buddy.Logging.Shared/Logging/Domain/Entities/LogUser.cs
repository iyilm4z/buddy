using Buddy.Domain.Entities;
using Buddy.Users.Domain.Entities;

namespace Buddy.Logging.Domain.Entities
{
    public class LogUser : Entity, IUser
    {
        public string Username { get; set; }

        public string Email { get; set; }
    }
}