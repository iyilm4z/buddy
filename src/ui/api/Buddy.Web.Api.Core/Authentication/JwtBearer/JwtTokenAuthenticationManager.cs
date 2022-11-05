using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Buddy.Runtime.Security;
using Buddy.Users.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Buddy.Web.Authentication.JwtBearer;

public class JwtTokenAuthenticationManager : IJwtTokenAuthenticationManager
{
    private readonly JwtTokenAuthenticationConfig _jwtTokenAuthenticationConfig;

    public JwtTokenAuthenticationManager(JwtTokenAuthenticationConfig jwtTokenAuthenticationConfig)
    {
        _jwtTokenAuthenticationConfig = jwtTokenAuthenticationConfig;
    }

    public JwtTokenAuthenticationResult Authenticate(IUser user)
    {
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtTokenAuthenticationConfig.Secret));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(BuddyClaimTypes.UserId, user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(_jwtTokenAuthenticationConfig.AccessTokenExpirationInMinutes),
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new JwtTokenAuthenticationResult
        {
            AccessToken = tokenHandler.WriteToken(token),
            RefreshToken = GenerateRefreshTokenString()
        };
    }

    public JwtTokenAuthenticationResult Refresh(string accessToken, string refreshToken)
    {
        throw new NotImplementedException();
    }

    public bool Revoke(string accessToken)
    {
        throw new NotImplementedException();
    }

    private static string GenerateRefreshTokenString()
    {
        var randomNumber = new byte[32];
        using var randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }
}