using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}