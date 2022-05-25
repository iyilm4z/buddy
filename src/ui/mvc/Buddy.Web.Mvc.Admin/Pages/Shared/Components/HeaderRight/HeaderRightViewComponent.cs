using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Pages.Shared.Components.HeaderRight;

public class HeaderRightViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}