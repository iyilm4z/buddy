using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

namespace Buddy.Dependency;

public class BuddyServiceLocator : IServiceLocator
{
    private IServiceProvider _serviceProvider;

    private BuddyServiceLocator()
    {
    }

    private IServiceProvider GetServiceProvider(IServiceScope scope = null)
    {
        if (scope != null)
        {
            return scope.ServiceProvider;
        }

        //Todo check this for webapps
        // var accessor = _serviceProvider?.GetService<IHttpContextAccessor>();
        // var context = accessor?.HttpContext;
        //
        // return context?.RequestServices ?? _serviceProvider;

        return _serviceProvider;
    }

    public static IServiceLocator Instance
    {
        get
        {
            if (Singleton<IServiceLocator>.Instance == null)
            {
                Create();
            }

            return Singleton<IServiceLocator>.Instance;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static IServiceLocator Create()
    {
        return Singleton<IServiceLocator>.Instance
               ?? (Singleton<IServiceLocator>.Instance = new BuddyServiceLocator());
    }

    public static void Replace(IServiceLocator serviceLocator)
    {
        Singleton<IServiceLocator>.Instance = serviceLocator;
    }

    public void SetServiceProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public T Resolve<T>() where T : class
    {
        return (T)Resolve(typeof(T));
    }

    public object Resolve(Type type)
    {
        return GetServiceProvider().GetService(type);
    }

    public IEnumerable<T> ResolveAll<T>()
    {
        return (IEnumerable<T>)GetServiceProvider().GetServices(typeof(T));
    }

    public object ResolveUnregistered(Type type)
    {
        Exception innerException = null;

        foreach (var constructor in type.GetConstructors())
        {
            try
            {
                var parameters = constructor.GetParameters().Select(parameter =>
                {
                    var service = Resolve(parameter.ParameterType);
                    if (service == null)
                    {
                        throw new Exception("Unknown dependency");
                    }

                    return service;
                });

                return Activator.CreateInstance(type, parameters.ToArray());
            }
            catch (Exception ex)
            {
                innerException = ex;
            }
        }

        throw new Exception("No constructor was found that had all the dependencies satisfied.", innerException);
    }
}