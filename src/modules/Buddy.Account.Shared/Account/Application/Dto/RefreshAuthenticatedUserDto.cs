using System.ComponentModel.DataAnnotations;

namespace Buddy.Account.Application.Dto;

public class RefreshAuthenticatedUserDto
{
    [Required(ErrorMessage = "Access token is required.")]
    public string AccessToken { get; set; }

    [Required(ErrorMessage = "Refresh token is required.")]
    public string RefreshToken { get; set; }
}