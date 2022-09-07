using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Buddy.Runtime.Security;
using Buddy.Runtime.Session;
using Buddy.Users.Domain.Repositories;
using Buddy.Web.Authentication.JwtBearer;
using Buddy.Web.Models.Account;
using Buddy.Web.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Buddy.Web.Controllers;

[Authorize]
public class AccountController : BuddyControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtAuthenticationManager _jwtAuthManager;
    private readonly IBuddySession _buddySession;

    public AccountController(IUserRepository userRepository,
        IJwtAuthenticationManager jwtAuthManager,
        IBuddySession buddySession)
    {
        _userRepository = userRepository;
        _jwtAuthManager = jwtAuthManager;
        _buddySession = buddySession;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public ActionResult Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var user = _userRepository.GetByUsername(request.UserName);
        if (user == null) // TODO compare password
        {
            return Unauthorized();
        }

        var claims = new[]
        {
            new Claim(BuddyClaimTypes.UserId, user.Id.ToString())
        };

        var jwtResult = _jwtAuthManager.GenerateTokens(user.Id, claims, DateTime.Now);

        return Ok(new LoginResult
        {
            AccessToken = jwtResult.AccessToken,
            RefreshToken = jwtResult.RefreshToken.TokenString
        });
    }

    [HttpPost("logout")]
    [Authorize]
    public ActionResult Logout()
    {
        // optionally "revoke" JWT token on the server side --> add the current token to a block-list
        // https://github.com/auth0/node-jsonwebtoken/issues/375
        
        var userId = _buddySession.UserId;

        _jwtAuthManager.RemoveRefreshTokenByUserId(userId.Value);

        return Ok();
    }

    [HttpPost("refresh-token")]
    [Authorize]
    public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.RefreshToken))
            {
                return Unauthorized();
            }

            var accessToken = await HttpContext.GetTokenAsync("Bearer", "access_token");

            var jwtResult = _jwtAuthManager.RefreshTokens(_buddySession.UserId.Value, request.RefreshToken, accessToken,
                DateTime.Now);

            return Ok(new LoginResult
            {
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }
        catch (SecurityTokenException ex)
        {
            // return 401 so that the client side can redirect the user to login page
            return Unauthorized(ex.Message);
        }
    }
}