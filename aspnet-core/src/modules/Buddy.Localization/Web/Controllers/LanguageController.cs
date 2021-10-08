using Buddy.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Buddy.Web.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult Index()
        {
            var languages = new List<LanguageModel>
            {
                new LanguageModel{Id = 1, Name = "Foo"},
                new LanguageModel{Id = 1, Name = "Bar"},
                new LanguageModel{Id = 1, Name = "Baz"}
            };

            return View(languages);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
