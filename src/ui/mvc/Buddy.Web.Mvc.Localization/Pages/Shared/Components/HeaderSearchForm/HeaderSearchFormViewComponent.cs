using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Mvc.Pages.Shared.Components.HeaderSearchForm;

public class HeaderSearchFormViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}