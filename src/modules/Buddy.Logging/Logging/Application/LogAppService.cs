using System;
using Buddy.Application;
using Buddy.Logging.Application.Dto;

namespace Buddy.Logging.Application;

public class LogAppService : ApplicationService, ILogAppService
{
    public LogDto Get()
    {
        throw new NotImplementedException();
    }
}