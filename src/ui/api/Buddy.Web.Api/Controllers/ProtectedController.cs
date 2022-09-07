using Buddy.Web.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Controllers;

[Authorize]
public class ProtectedController : BuddyControllerBase
{
    [HttpPost("ping")]
    public ActionResult Login()
    {
        return Ok();
    }
}