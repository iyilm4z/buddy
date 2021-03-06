using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Views.Shared.Components.SidebarMenu
{
    public class SidebarMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}