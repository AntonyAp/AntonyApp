using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testtest.Models;

namespace testtest.Controllers
{
    public class RegistrationController : Controller
    {
        private UserContext db = new UserContext();
        // GET: Registration
        public ActionResult RegistrationPage()
        {
            return View();
        }
        public ActionResult Registration( User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("LoginPage", "Autorization");
        }
    }
}