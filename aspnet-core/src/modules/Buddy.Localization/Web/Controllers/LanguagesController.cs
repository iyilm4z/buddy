using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Controllers
{
    public class LanguagesController : Controller
    {
        public string Index()
        {
            return "Ping from Language Controller!";
        }
    }
}