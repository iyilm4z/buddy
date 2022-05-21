using Buddy.Domain.Entities;

namespace Buddy.Users.Domain.Entities
{
    /// <summary>
    ///     Represents a User-User role mapping class
    /// </summary>
    public class UserUserRoleMapping : Entity
    {
        /// <summary>
        ///     Gets or sets the User identifier
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        ///     Gets or sets the User role identifier
        /// </summary>
        public int UserRoleId { get; set; }

        /// <summary>
        ///     Gets or sets the User
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        ///     Gets or sets the User role
        /// </summary>
        public virtual UserRole UserRole { get; set; }
    }
}