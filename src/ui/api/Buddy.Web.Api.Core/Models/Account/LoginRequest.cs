using System.ComponentModel.DataAnnotations;

namespace Buddy.Web.Models.Account;

public class LoginRequest
{
    [Required] 
    public string UserName { get; set; }

    [Required] 
    public string Password { get; set; }
}