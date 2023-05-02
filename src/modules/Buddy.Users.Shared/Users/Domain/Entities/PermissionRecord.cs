using System;
using System.ComponentModel.DataAnnotations;
using Buddy.Domain.Entities;

namespace Buddy.Users.Domain.Entities;

[Serializable]
public class PermissionRecord : AggregateRoot
{
    public PermissionRecord(string name, string systemName, string category)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        SystemName = systemName ?? throw new ArgumentNullException(nameof(systemName));
        Category = category ?? throw new ArgumentNullException(nameof(category));
    }

    [Required] public string Name { get; private set; }

    [Required]
    [MaxLength(PermissionRecordConsts.SystemNameMaxLength)]
    public string SystemName { get; private set; }

    [Required]
    [MaxLength(PermissionRecordConsts.CategoryMaxLength)]
    public string Category { get; private set; }
}