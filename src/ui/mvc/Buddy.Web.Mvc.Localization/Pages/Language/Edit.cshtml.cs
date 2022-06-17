using Buddy.Web.Mvc.Models;
using Buddy.Web.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Mvc.Pages.Language;

public class EditModel : BuddyPageModelBase
{
    [BindProperty]
    public LanguageModel Language { get; set; }

    public void OnGet()
    {
        Language = new LanguageModel();
    }
}