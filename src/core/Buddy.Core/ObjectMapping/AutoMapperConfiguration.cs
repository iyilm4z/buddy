using AutoMapper;

namespace Buddy.ObjectMapping;

public static class AutoMapperConfiguration
{
    public static IMapper Mapper { get; private set; }

    public static MapperConfiguration MapperConfiguration { get; private set; }

    public static void Init(MapperConfiguration config)
    {
        MapperConfiguration = config;
        Mapper = config.CreateMapper();
    }
}