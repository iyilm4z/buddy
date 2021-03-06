using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Views.Shared.Components.FooterLeft
{
    public class FooterLeftViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}