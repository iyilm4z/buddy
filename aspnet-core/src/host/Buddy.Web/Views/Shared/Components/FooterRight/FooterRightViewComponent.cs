using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Views.Shared.Components.FooterRight
{
    public class FooterRightViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}