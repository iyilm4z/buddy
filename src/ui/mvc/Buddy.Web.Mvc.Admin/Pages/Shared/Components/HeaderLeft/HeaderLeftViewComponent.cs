using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Pages.Shared.Components.HeaderLeft;

public class HeaderLeftViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}