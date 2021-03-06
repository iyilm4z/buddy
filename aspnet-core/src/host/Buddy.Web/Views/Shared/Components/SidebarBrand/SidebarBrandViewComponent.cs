using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Views.Shared.Components.SidebarBrand
{
    public class SidebarBrandViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}