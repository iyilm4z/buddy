using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Buddy.Domain.Repositories;
using Buddy.Runtime.Security;
using Buddy.Users.Domain.Entities;
using Buddy.Users.Domain.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace Buddy.Web.Authentication.JwtBearer;

public class JwtTokenAuthenticationManager : IJwtTokenAuthenticationManager
{
    private readonly IRepository<User> _userRepository;
    private readonly JwtTokenAuthenticationConfig _jwtTokenAuthenticationConfig;

    public JwtTokenAuthenticationManager(IRepository<User> userRepository,
        JwtTokenAuthenticationConfig jwtTokenAuthenticationConfig)
    {
        _userRepository = userRepository;
        _jwtTokenAuthenticationConfig = jwtTokenAuthenticationConfig;
    }

    public JwtTokenAuthenticateResult Authenticate(JwtTokenAuthenticateRequest authenticateRequest)
    {
        var user = _userRepository.GetByUsernameAsync(authenticateRequest.UsernameOrEmail);

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

        return new JwtTokenAuthenticateResult
        {
            AccessToken = tokenHandler.WriteToken(token),
            RefreshToken = GenerateRefreshTokenString()
        };
    }

    public JwtTokenAuthenticateResult Refresh(JwtTokenRefreshRequest refreshRequest)
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