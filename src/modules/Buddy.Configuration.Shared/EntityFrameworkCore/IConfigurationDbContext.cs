using Buddy.Configuration.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buddy.EntityFrameworkCore
{
    public interface IConfigurationDbContext
    {
        DbSet<Setting> Settings { get; set; }
    }
}