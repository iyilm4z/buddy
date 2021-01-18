using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Controllers
{
    [ApiController]
    [Route("api/v1/languages")]
    public class LanguageApiController : ControllerBase
    {
        public string Index()
        {
            return "Ping Language Api!";
        }
    }
}
