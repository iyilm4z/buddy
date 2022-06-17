using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Mvc.Pages.Shared.Components.FooterRight;

public class FooterRightViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}