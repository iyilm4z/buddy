using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Pages.Shared.Components.Header;

public class HeaderViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}