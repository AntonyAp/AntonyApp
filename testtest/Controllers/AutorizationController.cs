using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testtest.Models;

namespace testtest.Controllers
{
    public class AutorizationController : Controller
    {
        // GET: Autorization
        public ActionResult Login(AutorizationModel model)
        {
            if (model.Password == "123456" && model.Login == "Nagibator228")
            {
                return RedirectToAction("Football", "Autorization");
            }
            else
            {
                return RedirectToAction("LoginPage", "Autorization");
            }

        }

        public ActionResult LoginPage()
        {
            return View();
        }

        public ActionResult Football()
        {
       
            return View();
        }
    }
}