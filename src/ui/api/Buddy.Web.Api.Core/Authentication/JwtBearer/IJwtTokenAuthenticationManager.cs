using Buddy.Users.Domain.Entities;

namespace Buddy.Web.Authentication.JwtBearer;

public interface IJwtTokenAuthenticationManager
{
    JwtTokenAuthenticationResult Authenticate(IUser user);

    JwtTokenAuthenticationResult Refresh(string accessToken, string refreshToken);

    bool Revoke(string accessToken);
}