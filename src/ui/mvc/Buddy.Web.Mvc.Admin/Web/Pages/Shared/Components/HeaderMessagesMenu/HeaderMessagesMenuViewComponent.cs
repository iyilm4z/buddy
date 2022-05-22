using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Views.Shared.Components.HeaderMessagesMenu
{
    public class HeaderMessagesMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}