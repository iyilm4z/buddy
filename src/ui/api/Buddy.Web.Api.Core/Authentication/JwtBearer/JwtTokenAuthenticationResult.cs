namespace Buddy.Web.Authentication.JwtBearer;

public class JwtTokenAuthenticationResult
{
    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }
}