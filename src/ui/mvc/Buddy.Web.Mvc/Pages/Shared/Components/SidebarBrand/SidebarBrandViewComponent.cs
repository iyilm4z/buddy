﻿using Microsoft.AspNetCore.Mvc;

namespace Buddy.Web.Pages.Shared.Components.SidebarBrand;

public class SidebarBrandViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}