﻿using System.Web;
using System.Web.Mvc;

namespace Vapers_Club
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
