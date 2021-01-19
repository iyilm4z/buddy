using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Buddy.Web.Mvc.Razor
{
    public class BuddyViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            return new[]
            {
                "/Web/Views/{1}/{0}.cshtml",
                "/Web/Views/Shared/{0}.cshtml"
            }.Concat(viewLocations);
        }
    }
}
