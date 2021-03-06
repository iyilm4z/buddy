using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Views.Shared.Components.HeaderSearchForm
{
    public class HeaderSearchFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}