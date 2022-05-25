using System;

namespace Buddy.Reflection;

public interface ITypeFinder
{
    Type[] Find(Func<Type, bool> predicate);

    Type[] FindAll();
}