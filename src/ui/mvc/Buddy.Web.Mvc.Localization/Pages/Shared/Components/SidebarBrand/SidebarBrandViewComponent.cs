using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Mvc.Pages.Shared.Components.SidebarBrand;

public class SidebarBrandViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}