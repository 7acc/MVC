﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labb_1.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
        public ActionResult Unauthoized()
        {
            return View();
        }

        
    }
}