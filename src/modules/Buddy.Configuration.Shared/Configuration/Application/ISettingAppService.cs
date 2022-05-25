using Buddy.Application;
using Buddy.Configuration.Application.Dto;

namespace Buddy.Configuration.Application;

public interface ISettingAppService : IApplicationService
{
    SettingDto Get();
}