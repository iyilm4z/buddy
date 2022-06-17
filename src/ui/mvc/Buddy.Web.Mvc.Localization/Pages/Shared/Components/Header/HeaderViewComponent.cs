using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Mvc.Pages.Shared.Components.Header;

public class HeaderViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}