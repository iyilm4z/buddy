using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Mvc.Pages.Shared.Components.HeaderMessagesMenu;

public class HeaderMessagesMenuViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}