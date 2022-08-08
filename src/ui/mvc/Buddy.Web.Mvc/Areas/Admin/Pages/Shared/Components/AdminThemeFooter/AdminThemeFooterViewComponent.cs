using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Areas.Admin.Pages.Shared.Components.AdminThemeFooter;

public class AdminThemeFooterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}