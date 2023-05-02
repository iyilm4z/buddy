using Buddy.Users.Domain.Services;
using JetBrains.Annotations;

namespace Buddy.Users.Application.Dto;

public class LoginOutputDto
{
    public UserLoginResult Result { get; }

    [CanBeNull] public LoggedInUserDto LoggedInUser { get; set; }

    public LoginOutputDto(UserLoginResult result, LoggedInUserDto loggedInUser = null)
    {
        Result = result;
        LoggedInUser = loggedInUser;
    }
}