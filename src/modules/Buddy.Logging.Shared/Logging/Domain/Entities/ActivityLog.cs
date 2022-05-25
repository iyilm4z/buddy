using System;
using Buddy.Domain.Entities;

namespace Buddy.Logging.Domain.Entities;

public class ActivityLog : Entity
{
    public int ActivityLogTypeId { get; set; }

    public int UserId { get; set; }

    public int? EntityId { get; set; }

    public string EntityName { get; set; }

    public string Comment { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual string IpAddress { get; set; }

    public virtual ActivityLogType ActivityLogType { get; set; }

    //TODO
    public virtual LogUser User { get; set; }
}