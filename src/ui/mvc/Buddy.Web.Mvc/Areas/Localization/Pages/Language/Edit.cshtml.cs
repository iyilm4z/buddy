using Buddy.Web.Areas.Localization.Models;
using Buddy.Web.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Areas.Localization.Pages.Language;

public class EditModel : BuddyPageModelBase
{
    [BindProperty]
    public LanguageModel Language { get; set; }

    public void OnGet()
    {
        Language = new LanguageModel();
    }
}