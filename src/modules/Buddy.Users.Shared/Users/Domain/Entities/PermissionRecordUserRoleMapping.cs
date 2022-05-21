using Buddy.Domain.Entities;

namespace Buddy.Users.Domain.Entities
{
    /// <summary>
    ///     Represents a permission record-User role mapping class
    /// </summary>
    public class PermissionRecordUserRoleMapping : Entity
    {
        /// <summary>
        ///     Gets or sets the permission record identifier
        /// </summary>
        public int PermissionRecordId { get; set; }

        /// <summary>
        ///     Gets or sets the User role identifier
        /// </summary>
        public int UserRoleId { get; set; }

        /// <summary>
        ///     Gets or sets the permission record
        /// </summary>
        public virtual PermissionRecord PermissionRecord { get; set; }

        /// <summary>
        ///     Gets or sets the User role
        /// </summary>
        public virtual UserRole UserRole { get; set; }
    }
}