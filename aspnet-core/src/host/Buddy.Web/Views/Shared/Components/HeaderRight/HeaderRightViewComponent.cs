using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Views.Shared.Components.HeaderRight
{
    public class HeaderRightViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}