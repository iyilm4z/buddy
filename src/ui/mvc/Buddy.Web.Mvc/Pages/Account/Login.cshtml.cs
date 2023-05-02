using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Buddy.Users.Application;
using Buddy.Users.Application.Dto;
using Buddy.Users.Domain.Services;
using Buddy.Web.Authentication.Cookies;
using Buddy.Web.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Pages.Account;

public class LoginModel : BuddyPageModelBase
{
    private readonly ICookieAuthenticationManager _cookieAuthenticationManager;
    private readonly IAccountAppService _accountAppService;

    public LoginModel(ICookieAuthenticationManager cookieAuthenticationManager,
        IAccountAppService accountAppService)
    {
        _cookieAuthenticationManager = cookieAuthenticationManager;
        _accountAppService = accountAppService;
    }

    [BindProperty] public LoginPageViewModel ViewModel { get; set; }

    public string ReturnUrl { get; private set; }

    [TempData] public string ErrorMessage { get; set; }

    public class LoginPageViewModel
    {
        [Required] public string UsernameOrEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

    public async Task OnGetAsync(string returnUrl = null)
    {
        await _cookieAuthenticationManager.SignOutAsync();

        ReturnUrl = returnUrl;
    }

    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
        ReturnUrl = returnUrl;

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var loginOutput = await _accountAppService.LoginAsync(new LoginInputDto
        {
            UsernameOrEmail = ViewModel.UsernameOrEmail,
            Password = ViewModel.Password
        });

        switch (loginOutput.Result)
        {
            case UserLoginResult.Successful:
                await _cookieAuthenticationManager.SignInAsync(loginOutput.LoggedInUser, ViewModel.RememberMe);
                return Redirect(returnUrl ?? "/");
            case UserLoginResult.NotExist:
                return StatusCode(StatusCodes.Status401Unauthorized, "NotExist");
            case UserLoginResult.LockedOut:
                return StatusCode(StatusCodes.Status401Unauthorized, "LockedOut");
            case UserLoginResult.Deleted:
                return StatusCode(StatusCodes.Status401Unauthorized, "Deleted");
            case UserLoginResult.NotActive:
                return StatusCode(StatusCodes.Status401Unauthorized, "NotActive");
            case UserLoginResult.WrongPassword:
            default:
                return StatusCode(StatusCodes.Status401Unauthorized, "WrongPassword");
        }
    }
}