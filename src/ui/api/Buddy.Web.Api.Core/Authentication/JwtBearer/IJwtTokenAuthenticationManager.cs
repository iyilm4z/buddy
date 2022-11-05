namespace Buddy.Web.Authentication.JwtBearer;

public interface IJwtTokenAuthenticationManager
{
    JwtTokenAuthenticateResult Authenticate(JwtTokenAuthenticateRequest authenticateRequest);

    JwtTokenAuthenticateResult Refresh(JwtTokenRefreshRequest refreshRequest);

    bool Revoke(string accessToken);
}