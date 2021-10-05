using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Views.Shared.Components.HeaderLeft
{
    public class HeaderLeftViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}