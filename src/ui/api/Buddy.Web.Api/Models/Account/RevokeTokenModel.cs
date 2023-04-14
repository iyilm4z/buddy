using System.ComponentModel.DataAnnotations;

namespace Buddy.Web.Models.Account;

public class RevokeTokenModel
{
    [Required] 
    public string AccessToken { get; set; }
}