using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Pages.Shared.Components.Footer;

public class FooterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}