using System;
using System.Linq;

namespace Buddy.MultiTenancy.Domain.Entities
{
    public static class TenantExtensions
    {
        /// <summary>
        ///     Parse comma-separated Hosts
        /// </summary>
        /// <param name="tenant">Tenant</param>
        /// <returns>Comma-separated hosts</returns>
        public static string[] ParseHostValues(this Tenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }

            if (string.IsNullOrEmpty(tenant.Hosts))
            {
                return Array.Empty<string>();
            }

            var hosts = tenant.Hosts.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

            var parsedValues = hosts.Select(host => host.Trim())
                .Where(tmp => !string.IsNullOrEmpty(tmp))
                .ToArray();

            return parsedValues;
        }

        /// <summary>
        ///     Indicates whether a tenant contains a specified host
        /// </summary>
        /// <param name="tenant">Tenant</param>
        /// <param name="host">Host</param>
        /// <returns>true - contains, false - no</returns>
        public static bool ContainsHostValue(this Tenant tenant, string host)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }

            if (string.IsNullOrEmpty(host))
            {
                return false;
            }

            var contains = tenant.ParseHostValues()
                .FirstOrDefault(x => x.Equals(host, StringComparison.InvariantCultureIgnoreCase)) != null;
            return contains;
        }
    }
}