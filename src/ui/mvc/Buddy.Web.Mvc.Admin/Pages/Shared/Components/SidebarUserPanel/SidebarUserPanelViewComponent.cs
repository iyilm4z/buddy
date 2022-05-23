using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Pages.Shared.Components.SidebarUserPanel
{
    public class SidebarUserPanelViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}