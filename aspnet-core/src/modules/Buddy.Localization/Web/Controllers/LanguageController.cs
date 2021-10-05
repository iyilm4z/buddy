using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
