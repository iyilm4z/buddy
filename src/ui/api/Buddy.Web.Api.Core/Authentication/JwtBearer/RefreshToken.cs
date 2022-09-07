using System;

namespace Buddy.Web.Authentication.JwtBearer;

public class RefreshToken
{
    public int UserId { get; set; }

    public string TokenString { get; set; }

    public DateTime ExpireAt { get; set; }
}