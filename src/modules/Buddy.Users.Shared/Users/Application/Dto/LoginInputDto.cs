using System.ComponentModel.DataAnnotations;

namespace Buddy.Users.Application.Dto;

public class LoginInputDto
{
    [Required] public string UsernameOrEmail { get; set; }

    [Required] public string Password { get; set; }
}