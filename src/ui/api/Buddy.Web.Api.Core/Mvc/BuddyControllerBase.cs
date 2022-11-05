using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BuddyControllerBase : ControllerBase
{
    //public IBuddySession BuddySession { get; set; }

    public BuddyControllerBase()
    {
        //BuddySession = NullBuddySession.Instance;
    }
}