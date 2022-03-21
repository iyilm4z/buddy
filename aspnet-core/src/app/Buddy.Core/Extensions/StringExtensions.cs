using System;
using JetBrains.Annotations;

namespace Buddy.Extensions;

public static class StringExtensions
{
    [ContractAnnotation("null => true")]
    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }

    [ContractAnnotation("null => true")]
    public static bool IsNullOrWhiteSpace(this string str)
    {
        return string.IsNullOrWhiteSpace(str);
    }

    public static T ToEnum<T>(this string value)
        where T : struct
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return (T)Enum.Parse(typeof(T), value);
    }

    public static T ToEnum<T>(this string value, bool ignoreCase)
        where T : struct
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return (T)Enum.Parse(typeof(T), value, ignoreCase);
    }
}