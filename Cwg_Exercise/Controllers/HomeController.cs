using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cwg_Exercise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string applicationMessage="")
        {
            ViewBag.applicationmessage = applicationMessage;
            return View();
        }

       
    }
}