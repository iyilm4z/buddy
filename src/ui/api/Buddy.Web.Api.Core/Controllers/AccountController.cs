using System.Threading.Tasks;
using Buddy.Domain.Repositories;
using Buddy.Users.Configurations;
using Buddy.Users.Domain.Entities;
using Buddy.Users.Domain.Repositories;
using Buddy.Users.Domain.Services;
using Buddy.Web.Authentication.JwtBearer;
using Buddy.Web.Models.Account;
using Buddy.Web.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Controllers;

public class AccountController : BuddyControllerBase
{
    private readonly IUserDomainService _userDomainService;
    private readonly IRepository<User> _userRepository;
    private readonly IJwtTokenAuthenticationManager _jwtTokenAuthenticationManager;

    public AccountController(IUserDomainService userDomainService,
        IRepository<User> userRepository,
        IJwtTokenAuthenticationManager jwtTokenAuthenticationManager)
    {
        _userDomainService = userDomainService;
        _userRepository = userRepository;
        _jwtTokenAuthenticationManager = jwtTokenAuthenticationManager;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var userLoginResult = await _userDomainService.CheckUserLoginAsync(model.UsernameOrEmail, model.Password);

            switch (userLoginResult)
            {
                case UserLoginResult.Successful:
                    var user = UserSettings.UsernamesEnabled
                        ? await _userRepository.GetByUsernameAsync(model.UsernameOrEmail)
                        : await _userRepository.GetByEmailAsync(model.UsernameOrEmail);

                    return Ok(_jwtTokenAuthenticationManager.Authenticate(user));
                case UserLoginResult.NotExist:
                    return Unauthorized("NotExist");
                case UserLoginResult.LockedOut:
                    return Unauthorized("LockedOut");
                case UserLoginResult.Deleted:
                    return Unauthorized("Deleted");
                case UserLoginResult.NotActive:
                    return Unauthorized("NotActive");
                case UserLoginResult.WrongPassword:
                default:
                    return Unauthorized("WrongPassword");
            }
        }

        return Unauthorized("ModelNotValid");
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