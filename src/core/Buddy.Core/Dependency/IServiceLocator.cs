using System;
using System.Collections.Generic;

namespace Buddy.Dependency;

public interface IServiceLocator
{
    void SetServiceProvider(IServiceProvider serviceProvider);

    T Resolve<T>() where T : class;

    object Resolve(Type type);

    IEnumerable<T> ResolveAll<T>();

    object ResolveUnregistered(Type type);
}