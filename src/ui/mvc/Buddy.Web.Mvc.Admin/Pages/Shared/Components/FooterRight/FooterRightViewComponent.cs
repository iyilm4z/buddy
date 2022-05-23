using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Pages.Shared.Components.FooterRight
{
    public class FooterRightViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}