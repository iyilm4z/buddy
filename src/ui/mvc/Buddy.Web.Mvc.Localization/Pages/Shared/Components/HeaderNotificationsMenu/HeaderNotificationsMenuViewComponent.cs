using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Mvc.Pages.Shared.Components.HeaderNotificationsMenu;

public class HeaderNotificationsMenuViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}