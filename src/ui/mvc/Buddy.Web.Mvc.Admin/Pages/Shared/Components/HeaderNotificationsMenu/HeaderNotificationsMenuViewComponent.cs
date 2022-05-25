using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Pages.Shared.Components.HeaderNotificationsMenu;

public class HeaderNotificationsMenuViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}