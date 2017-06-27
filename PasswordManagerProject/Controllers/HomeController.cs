﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasswordManagerProject.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index(bool logout = false)
        {
            if(logout)
            {
                HttpContext.Session["userId"] = null;
            }

            return View();
        }
    }
}
