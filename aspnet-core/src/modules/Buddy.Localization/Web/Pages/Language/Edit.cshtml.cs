using Buddy.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Buddy.Web.Pages.Language
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public LanguageModel Language { get; set; }

        public void OnGet()
        {
            Language = new LanguageModel();
        }
    }
}
