using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Pages.Shared.Components.ControlSidebar
{
    public class ControlSidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}