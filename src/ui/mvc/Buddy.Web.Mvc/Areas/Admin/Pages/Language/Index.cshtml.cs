using System.Collections.Generic;
using Buddy.Web.Mvc.RazorPages;

namespace Buddy.Web.Areas.Admin.Pages.Language;

public class IndexModel : BuddyPageModelBase
{
    public IEnumerable<LanguageViewModel> Languages { get; set; }

    public void OnGet()
    {
        Languages = new List<LanguageViewModel>
        {
            new() { Id = 1, Name = "Turkish" },
            new() { Id = 2, Name = "English" },
            new() { Id = 3, Name = "Russian" }
        };
    }

    public class LanguageViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}