using Buddy.Domain.Entities;

namespace Buddy.MultiTenancy.Domain.Entities
{
    /// <summary>
    ///     Represents a tenant
    /// </summary>
    public class Tenant : Entity, ILocalizedEntity
    {
        /// <summary>
        ///     Gets or sets the tenant name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the tenant URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether SSL is enabled
        /// </summary>
        public bool SslEnabled { get; set; }

        /// <summary>
        ///     Gets or sets the tenant secure URL (HTTPS)
        /// </summary>
        public string SecureUrl { get; set; }

        /// <summary>
        ///     Gets or sets the comma separated list of possible HTTP_HOST values
        /// </summary>
        public string Hosts { get; set; }

        /// <summary>
        ///     Gets or sets the identifier of the default language for this tenant; 0 is set when we use the default language
        ///     display order
        /// </summary>
        public int DefaultLanguageId { get; set; }

        /// <summary>
        ///     Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}