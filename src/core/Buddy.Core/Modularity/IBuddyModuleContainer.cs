using System.Collections.Generic;

namespace Buddy.Modularity;

public interface IBuddyModuleContainer
{
    IReadOnlyList<BuddyModuleInfo> Modules { get; }
}