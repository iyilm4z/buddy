using System.ComponentModel.DataAnnotations;

namespace Buddy.Account.Application.Dto;

public class SignInDto
{
    [Required(ErrorMessage = "Username or Email is required.")]
    public string UsernameOrEmail { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
}