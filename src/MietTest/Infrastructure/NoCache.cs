using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;
using System.Web.Mvc;

namespace MietTest.Controllers
{
    class NoCacheAttribute : OutputCacheAttribute
    {
        public NoCacheAttribute()
        {
            NoStore = true;
            Duration = 0;
            Location = System.Web.UI.OutputCacheLocation.None;
            VaryByParam = "none";
        }
    }
}
