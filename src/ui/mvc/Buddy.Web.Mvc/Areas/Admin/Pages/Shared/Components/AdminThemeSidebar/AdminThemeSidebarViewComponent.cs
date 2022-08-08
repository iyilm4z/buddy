using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Areas.Admin.Pages.Shared.Components.AdminThemeSidebar;

public class AdminThemeSidebarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}