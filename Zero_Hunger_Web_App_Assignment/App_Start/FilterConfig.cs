﻿using System.Web;
using System.Web.Mvc;

namespace Zero_Hunger_Web_App_Assignment
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
