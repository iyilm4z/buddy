using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Mvc.Pages.Shared.Components.HeaderRight;

public class HeaderRightViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}