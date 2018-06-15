using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testtest.Models;

namespace testtest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()

        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You have enteered the system.";

            return View();
        }

        [HttpPost]
        public ActionResult Login(AutorizationModel model)
        {
            return Json("Temp");
        }
    }
}