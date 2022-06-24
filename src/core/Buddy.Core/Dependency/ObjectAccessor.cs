using JetBrains.Annotations;

namespace Buddy.Dependency;

public class ObjectAccessor<T>
{
    public T Value { get; set; }

    public ObjectAccessor()
    {
    }

    public ObjectAccessor([CanBeNull] T obj)
    {
        Value = obj;
    }
}