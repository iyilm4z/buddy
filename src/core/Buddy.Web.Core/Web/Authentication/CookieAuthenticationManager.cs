using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Buddy.Authentication;
using Buddy.Dependency;
using Buddy.Runtime.Security;
using Buddy.Users.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Buddy.Web.Authentication;

public class CookieAuthenticationManager : ICookieAuthenticationManager, ITransientDependency
{
    private readonly HttpContext _httpContext;

    public CookieAuthenticationManager(IHttpContextAccessor httpContextAccessor)
    {
        _httpContext = httpContextAccessor.HttpContext;
    }

    public async Task SignInAsync(IUser user, bool isPersistent)
    {
        var claims = new List<Claim>
        {
            new(BuddyClaimTypes.UserId, user.Id.ToString())
        };

        var id = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await _httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
    }

    public async Task SignOutAsync()
    {
        await _httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}