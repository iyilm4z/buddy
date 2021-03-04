using System.Collections.Generic;
using Buddy.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Controllers
{
    public class LanguagesController : Controller
    {
        public IActionResult Index()
        {
            var model = new List<LanguageListModel>
            {
                new LanguageListModel
                {
                    Id = 1,
                    Name = "Turkish"
                },
                new LanguageListModel
                {
                    Id = 2,
                    Name = "English"
                },
                new LanguageListModel
                {
                    Id = 3,
                    Name = "Russian"
                }
            };

            return View(model);
        }
    }
}