using Buddy.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Buddy.Web.Pages.Language
{
    public class IndexModel : PageModel
    {
        public IEnumerable<LanguageModel> Languages { get; set; }

        public void OnGet()
        {
            Languages = new List<LanguageModel> {
                new LanguageModel { Id = 1, Name = "Turkish" },
                new LanguageModel { Id = 2, Name = "English" },
                new LanguageModel { Id = 3, Name = "Russian" }
            };
        }
    }
}
