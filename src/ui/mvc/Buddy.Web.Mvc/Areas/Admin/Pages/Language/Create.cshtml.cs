using Buddy.Web.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Areas.Admin.Pages.Language;

public class CreateModel : BuddyPageModelBase
{
    [BindProperty] public CreateOrEditViewModel Language { get; set; }

    public void OnGet()
    {
        Language = new CreateOrEditViewModel();
    }

    public class CreateOrEditViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}