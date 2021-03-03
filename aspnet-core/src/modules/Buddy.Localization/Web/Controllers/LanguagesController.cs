using Buddy.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Controllers
{
    public class LanguagesController : Controller
    {
        public IActionResult Index()
        {
            var model = new LanguageListModel
            {
                Name = "Turkish"
            };

            return View(model);
        }
    }
}