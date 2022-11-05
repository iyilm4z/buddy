using System.Threading.Tasks;
using Buddy.Web.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Buddy.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ICookieAuthenticationManager _cookieAuthenticationManager;
    
    public IndexModel(ICookieAuthenticationManager cookieAuthenticationManager)
    {
        _cookieAuthenticationManager = cookieAuthenticationManager;
    }
    
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnGetLogoutAsync()
    {
        await _cookieAuthenticationManager.SignOutAsync();

        return RedirectToPage("/Index");
    }
}