using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Views.Shared.Components.SidebarUserPanel
{
    public class SidebarUserPanelViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}