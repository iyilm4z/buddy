using Buddy.Logging.Application.Dto;

namespace Buddy.Logging.Application;

public interface ILogAppService
{
    LogDto Get();
}