using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoldSaver.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}