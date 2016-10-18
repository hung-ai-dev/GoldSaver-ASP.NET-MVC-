using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoldSaver.Controllers
{
    [Authorize]
    public class ActivityLogController : Controller
    {
        // GET: ActivityLog
        public ActionResult Index()
        {
            ViewBag.title = "Activity Log";
            return View();
        }
    }
}