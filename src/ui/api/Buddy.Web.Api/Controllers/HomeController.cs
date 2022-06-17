using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Controllers;

// TODO: BUse base controller
public class HomeController : Controller
{
    public ActionResult Index() => Redirect("~/swagger");
}