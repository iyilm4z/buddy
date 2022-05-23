using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Pages.Shared.Components.SidebarMenu
{
    public class SidebarMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}