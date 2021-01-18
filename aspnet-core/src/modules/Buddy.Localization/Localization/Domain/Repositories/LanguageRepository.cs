using Buddy.EntityFrameworkCore.Repositories;
using Buddy.Localization.Domain.Entities;

namespace Buddy.Localization.Domain.Repositories
{
    public class LanguageRepository : EfCoreRepository<Language>, ILanguageRepository
    {
    }
}
