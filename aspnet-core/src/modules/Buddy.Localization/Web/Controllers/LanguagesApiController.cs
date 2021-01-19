using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Controllers
{
    [ApiController]
    [Route("api/languages")]
    public class LanguagesApiController : ControllerBase
    {
        public string Index()
        {
            return "Ping from Language Api!";
        }
    }
}
