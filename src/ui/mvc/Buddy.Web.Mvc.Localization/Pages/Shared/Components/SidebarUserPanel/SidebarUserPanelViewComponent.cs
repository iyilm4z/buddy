using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Mvc.Pages.Shared.Components.SidebarUserPanel;

public class SidebarUserPanelViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}