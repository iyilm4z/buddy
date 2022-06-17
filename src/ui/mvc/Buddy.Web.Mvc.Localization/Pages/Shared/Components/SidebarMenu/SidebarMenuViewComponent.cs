using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Mvc.Pages.Shared.Components.SidebarMenu;

public class SidebarMenuViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}