using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Pages.Shared.Components.PublicThemeHeader;

public class PublicThemeHeaderViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}