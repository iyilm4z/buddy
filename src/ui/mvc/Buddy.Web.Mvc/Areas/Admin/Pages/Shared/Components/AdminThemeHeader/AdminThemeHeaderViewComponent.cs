using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Areas.Admin.Pages.Shared.Components.AdminThemeHeader;

public class AdminThemeHeaderViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}