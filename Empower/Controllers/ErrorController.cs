using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Empower.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Error(string message)
        {
            ViewBag.message = message;
            return View();
        }
	}
}