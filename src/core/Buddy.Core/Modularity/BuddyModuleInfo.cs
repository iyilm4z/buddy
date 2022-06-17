using System;
using System.Collections.Generic;
using System.Reflection;
using Buddy.Collections.Extensions;

namespace Buddy.Modularity;

public class BuddyModuleInfo
{
    public Type Type { get; }

    public BuddyModule Instance { get; }

    public Assembly Assembly { get; }

    public List<BuddyModuleInfo> Dependencies { get; }

    public BuddyModuleInfo(Type type, BuddyModule instance)
    {
        Type = type ?? throw new ArgumentNullException(nameof(type));
        Instance = instance ?? throw new ArgumentNullException(nameof(instance));

        Assembly = Type.GetTypeInfo().Assembly;
        Dependencies = new List<BuddyModuleInfo>();
    }

    public void AddDependency(BuddyModuleInfo moduleInfo)
    {
        Dependencies.AddIfNotContains(moduleInfo);
    }

    public override string ToString()
    {
        return Type.AssemblyQualifiedName ?? Type.FullName;
    }
}