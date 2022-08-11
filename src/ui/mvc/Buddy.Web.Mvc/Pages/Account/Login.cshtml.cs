using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Buddy.Authentication;
using Buddy.Users.Domain.Entities;
using Buddy.Users.Domain.Repositories;
using Buddy.Web.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Pages.Account;

public class LoginModel : BuddyPageModelBase
{
    private readonly ICookieAuthenticationManager _cookieAuthenticationManager;
    private readonly IUserRepository _userRepository;

    public LoginModel(ICookieAuthenticationManager cookieAuthenticationManager, 
        IUserRepository userRepository)
    {
        _cookieAuthenticationManager = cookieAuthenticationManager;
        _userRepository = userRepository;
    }

    [BindProperty] public LoginPageViewModel ViewModel { get; set; }

    public string ReturnUrl { get; private set; }

    [TempData] public string ErrorMessage { get; set; }

    public class LoginPageViewModel
    {
        [Required] public string Username { get; set; }

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

        var user = _userRepository.GetByUsername(ViewModel.Username);

        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }

        await _cookieAuthenticationManager.SignInAsync(user, ViewModel.RememberMe);

        return Redirect(returnUrl ?? "/");
    }
}