using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWithDb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Create()
        {
            return View();
        }
    }
}