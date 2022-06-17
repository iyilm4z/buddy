using Buddy.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Controllers;

public class HomeController : BuddyController
{
    public ActionResult Index() => Redirect("~/swagger");
}