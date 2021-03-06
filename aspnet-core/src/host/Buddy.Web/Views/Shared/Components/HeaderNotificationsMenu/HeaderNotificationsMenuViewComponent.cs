using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Views.Shared.Components.HeaderNotificationsMenu
{
    public class HeaderNotificationsMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}