using System.ComponentModel.DataAnnotations;

namespace Buddy.Web.Models.Account;

public class RefreshTokenModel
{
    [Required] 
    public string AccessToken { get; set; }

    [Required] 
    public string RefreshToken { get; set; }
}