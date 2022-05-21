using Buddy.Domain.Entities;

namespace Buddy.MultiTenancy.Domain.Entities
{
    /// <summary>
    ///     Represents a tenant mapping record
    /// </summary>
    public class TenantMapping : Entity
    {
        /// <summary>
        ///     Gets or sets the entity identifier
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        ///     Gets or sets the entity name
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        ///     Gets or sets the tenant identifier
        /// </summary>
        public int TenantId { get; set; }

        /// <summary>
        ///     Gets or sets the tenant
        /// </summary>
        public virtual Tenant Tenant { get; set; }
    }
}