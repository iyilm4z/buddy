using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Pages.Shared.Components.PublicThemeFooter;

public class PublicThemeFooterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}