using System.ComponentModel.DataAnnotations;

namespace Buddy.Account.Application.Dto;

public class AuthenticateUserDto
{
    [Required(ErrorMessage = "Username or Email is required.")]
    public string UsernameOrEmail { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }
}