namespace Buddy.Web.Authentication.JwtBearer;

public class JwtTokenAuthenticationConfig
{
    public const string ConfigKey = "JwtTokenAuthentication";
   
    public string Secret { get; set; }
    
    public string Issuer { get; set; }
    
    public string Audience { get; set; }
    
    public int AccessTokenExpirationInMinutes { get; set; }
    
    public int RefreshTokenExpirationInMinutes { get; set; }
}