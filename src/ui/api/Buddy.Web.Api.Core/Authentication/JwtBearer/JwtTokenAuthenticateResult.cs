namespace Buddy.Web.Authentication.JwtBearer;

public class JwtTokenAuthenticateResult
{
    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }
}