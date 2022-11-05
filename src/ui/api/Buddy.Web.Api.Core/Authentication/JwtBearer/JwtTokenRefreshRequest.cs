using System.ComponentModel.DataAnnotations;

namespace Buddy.Web.Authentication.JwtBearer;

public class JwtTokenRefreshRequest
{
    [Required]
    public string  AccessToken  { get; set; }

    [Required]
    public string RefreshToken { get; set; }
}