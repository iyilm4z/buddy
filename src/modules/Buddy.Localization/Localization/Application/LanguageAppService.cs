using Buddy.Application;
using Buddy.Localization.Application.Dto;

namespace Buddy.Localization.Application;

public class LanguageAppService : ApplicationService, ILanguageAppService
{
    public LanguageDto Get()
    {
        return new LanguageDto
        {
            Id = 1,
            Name = "Turkish"
        };
    }
}