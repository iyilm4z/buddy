using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Mvc.Pages.Shared.Components.Sidebar;

public class SidebarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}