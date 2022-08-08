using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Areas.Admin.Pages.Shared.Components.AdminThemeControlSidebar;

public class AdminThemeControlSidebarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}