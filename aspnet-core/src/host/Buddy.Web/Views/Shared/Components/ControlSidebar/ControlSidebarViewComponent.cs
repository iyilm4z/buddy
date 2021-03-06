using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Views.Shared.Components.ControlSidebar
{
    public class ControlSidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}