using Buddy.Localization.Application;
using Buddy.Localization.Application.Dto;
using Buddy.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Controllers;

public class LanguageController : BuddyControllerBase, ILanguageAppService
{
    private readonly ILanguageAppService _languageAppService;

    public LanguageController(ILanguageAppService languageAppService)
    {
        _languageAppService = languageAppService;
    }

    [HttpGet]
    public LanguageDto Get()
    {
        return _languageAppService.Get();
    }
}