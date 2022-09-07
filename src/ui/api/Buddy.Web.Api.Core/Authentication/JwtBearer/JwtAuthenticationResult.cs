namespace Buddy.Web.Authentication.JwtBearer;

public class JwtAuthenticationResult
{
    public string AccessToken { get; set; }

    public RefreshToken RefreshToken { get; set; }
}