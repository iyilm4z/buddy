using System.ComponentModel.DataAnnotations;

namespace Buddy.Web.Authentication.JwtBearer;

public class JwtTokenAuthenticateRequest
{
    [Required]
    public string UsernameOrEmail { get; set; }

    [Required]
    public string Password { get; set; }
}