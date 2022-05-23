using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Pages.Shared.Components.FooterLeft
{
    public class FooterLeftViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}