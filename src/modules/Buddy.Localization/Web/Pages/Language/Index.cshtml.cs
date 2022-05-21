using Buddy.Web.Models;
using System.Collections.Generic;
using Buddy.Web.Mvc.RazorPages;

namespace Buddy.Web.Pages.Language
{
    public class IndexModel : BuddyPageModelBase
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
