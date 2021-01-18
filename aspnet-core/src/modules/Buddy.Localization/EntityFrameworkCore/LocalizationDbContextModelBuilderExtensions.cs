using Microsoft.EntityFrameworkCore;

namespace Buddy.EntityFrameworkCore
{
    public static class LocalizationDbContextModelBuilderExtensions
    {
        public static ModelBuilder ConfigureLocalization<TDbContext>(this ModelBuilder builder) 
            where TDbContext : ILocalizationDbContext
        {

            return builder;
        }
    }
}
