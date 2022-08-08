using Buddy.Web.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Areas.Admin.Pages.Language;

public class EditModel : BuddyPageModelBase
{
    [BindProperty] public CreateModel.CreateOrEditViewModel Language { get; set; }

    public void OnGet()
    {
        Language = new CreateModel.CreateOrEditViewModel();
    }
}