using System.Threading.Tasks;
using Buddy.Web.Models.Account;
using Buddy.Web.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Controllers;

public class AccountController : BuddyControllerBase
{
    [AllowAnonymous]
    [HttpPost("login")]
    public ActionResult Login([FromBody] LoginModel model)
    {
        // TODO 
        return Ok();
    }

    [Authorize]
    [HttpPost("logout")]
    public ActionResult Logout()
    {
        // TODO 
        return Ok();
    }

    [Authorize]
    [HttpPost("refresh-token")]
    public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenModel model)
    {
        // TODO 
        return Ok();
    }

    [Authorize]
    [HttpPost("revoke")]
    public IActionResult Revoke()
    {
        // TODO 
        return Ok();
    }
}