using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Mvc.Pages.Shared.Components.ControlSidebar;

public class ControlSidebarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}