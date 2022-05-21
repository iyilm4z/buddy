using Buddy.Domain.Entities;

namespace Buddy.Logging.Domain.Entities
{
    public class ActivityLogType : Entity
    {
        public string SystemKeyword { get; set; }

        public string Name { get; set; }

        public bool Enabled { get; set; }
    }
}