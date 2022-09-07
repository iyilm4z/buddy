using System;
using System.Security.Claims;

namespace Buddy.Web.Authentication.JwtBearer;

public interface IJwtAuthenticationManager
{
    JwtAuthenticationResult GenerateTokens(int userId, Claim[] claims, DateTime now);
    JwtAuthenticationResult RefreshTokens(int userId, string refreshToken, string accessToken, DateTime now);
    void RemoveExpiredRefreshTokens(DateTime now);
    void RemoveRefreshTokenByUserId(int userId);
}